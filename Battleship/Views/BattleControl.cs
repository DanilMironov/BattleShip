using System.Windows.Forms;
using Battleship.Entities;
using Battleship.Opponent;

namespace Battleship.Views
{
    public partial class BattleControl : UserControl
    {
        private Game game;

        public BattleControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;
            this.game = game;

            hFieldControl.Configure(game.FirstPlayer.Field, false);
            aIFieldControl.Configure(game.SecondPlayer.Field, true);

            aIFieldControl.ClickOnPoint += HumanClick;

            game.ReadyToShoot += GameReadyToShoot;
            
        }

        private void HumanClick(Point point, MouseEventArgs args)
        {
            if (args.Button == MouseButtons.Left)
                if (game.CurrentPlayer.Equals(game.FirstPlayer))
                    game.Shoot(point);
        }

        private void GameReadyToShoot()
        {
            var player = game.FirstPlayer;
            var aIPlayer = game.SecondPlayer;
            //if (game.Status == GameStatus.Battle && game.CurrentPlayer.Equals(aIPlayer))
            //var randomShot = дописать расширение для игрока чтобы стрелял рандомно 

            if (game.Status == GameStatus.Battle && game.CurrentPlayer.Equals(aIPlayer))
            {
                var rndPointToShot = player.Field.GenerateRandomPointToShoot();
                game.Shoot(rndPointToShot);
            }
        }
    }
}
