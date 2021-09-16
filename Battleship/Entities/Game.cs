using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Entities
{

    public class Game
    {
        private GameStatus currentStatus = GameStatus.NotStarted;
        private Player firstPlayer = null;
        private Player secondPlayer = null;
        private bool isFirstPlayerCurrent = false;
        private GameOptions options = new GameOptions();

        public Game(Action<GameOptions> configureOptions = null)
        {
            configureOptions?.Invoke(options);
        }

        public GameStatus Status => currentStatus;
        public event Action<GameStatus> StatusChanged;

        public IPlayer FirstPlayer => firstPlayer;
        public IPlayer SecondPlayer => secondPlayer;
        public IPlayer CurrentPlayer => isFirstPlayerCurrent ? firstPlayer : secondPlayer;
        public event Action<IPlayer> CurrentPlayerChanged;

        public event Action ReadyToShoot;

        public void Start(string firstPlayerName, string secondPlayerName)
        {
            firstPlayer = CreatePlayer(firstPlayerName);
            secondPlayer = CreatePlayer(secondPlayerName);
            isFirstPlayerCurrent = true;
            CurrentPlayerChanged?.Invoke(CurrentPlayer);
            ChangeStage(GameStatus.PlacingShips);
        }

        public bool CanFinishPlacingCurrentPlayerShips =>
            Status == GameStatus.PlacingShips && IsReadyForBattle(CurrentPlayer);

        public void EndPlacingCurrentPlayerShips()
        {
            if (!CanFinishPlacingCurrentPlayerShips)
                return;

            if (!CanBeginBattle)
            {
                MoveToNextPlayer();
                return;
            }

            MoveToNextPlayer();
            ChangeStage(GameStatus.Battle);
        }

        public bool CanBeginBattle =>
            Status == GameStatus.PlacingShips
            && IsReadyForBattle(FirstPlayer) && IsReadyForBattle(SecondPlayer);

        public void Shoot(Point point)
        {
            if (Status != GameStatus.Battle)
                throw new InvalidOperationException();

            var shotResult = GetNextPlayer().Field.Shoot(point);
            switch (shotResult)
            {
                case ShotResult.Hit:
                    if (IsCurrentPlayerWin())
                        ChangeStage(GameStatus.Ending);
                    else
                        ReadyToShoot?.Invoke();
                    return;
                case ShotResult.Miss:
                    MoveToNextPlayer();
                    ReadyToShoot?.Invoke();
                    return;
                case ShotResult.Triggered:
                    return;
                default:
                    throw new InvalidOperationException();
            }
        }

        private Player CreatePlayer(string name)
        {
            var field = new Field(options.Width, options.Height);
            foreach (var ship in CreateShips(options))
                field.AddShip(ship);
            return new Player(name, field);
        }

        private IEnumerable<Ship> CreateShips(GameOptions options)
        {
            var sizes = options.Sizes;
            foreach (var size in sizes)
                yield return new Ship(size);
        } 

        private void ChangeStage(GameStatus currentStatus)
        {
            this.currentStatus = currentStatus;
            StatusChanged?.Invoke(currentStatus);
        }

        private Player GetNextPlayer() => isFirstPlayerCurrent ? secondPlayer : firstPlayer;

        private void MoveToNextPlayer()
        {
            isFirstPlayerCurrent = !isFirstPlayerCurrent;
            CurrentPlayerChanged?.Invoke(CurrentPlayer);
        }

        private static bool IsReadyForBattle(IPlayer player)
        {
            return player.Field.GetShipToPutOrNull() == null && !player.Field.GetConflictPoints().Any();
        }

        private bool IsCurrentPlayerWin()
        {
            var nextPlayer = GetNextPlayer();
            return nextPlayer != null
                ? !nextPlayer.Field.HasAliveShips()
                : false;
        }
    }
}
