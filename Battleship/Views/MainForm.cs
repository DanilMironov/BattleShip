using System.Windows.Forms;
using Battleship.Entities;

namespace Battleship.Views
{
    public partial class MainForm : Form
    {
        private Game game;

        public MainForm()
        {
            InitializeComponent();
            game = new Game();
            game.StatusChanged += GameStatusChanged;
            //var fieldControl = new FieldControl();
            //fieldControl.Configure(new Field(10, 10), true);
            //fieldControl.BackColor = Color.Gray;
            //Controls.Add(fieldControl);
            ShowStartScreen();
        }

        private void GameStatusChanged(GameStatus gameStatus)
        {
            switch (gameStatus)
            {
                case GameStatus.Battle:
                    ShowBattleScreen();
                    break;

                case GameStatus.Ending:
                    ShowFinishScreen();
                    break;

                case GameStatus.PlacingShips:
                    ShowPlacingScreen();
                    break;

                case GameStatus.NotStarted:
                default:
                    ShowStartScreen();
                    break;
            }
        }

        private void ShowStartScreen()
        {
            HideAll();
            startControl.Configure(this.game);
            startControl.Show();
        }

        private void ShowBattleScreen()
        {
            HideAll();
            battleControl.Configure(this.game);
            battleControl.Show();
        }

        private void ShowPlacingScreen()
        {
            HideAll();
            placingControl.Configure(this.game);
            placingControl.Show();
        }

        private void ShowFinishScreen()
        {
            HideAll();
            finishControl.Configure(this.game);
            finishControl.Show();
        }

        private void HideAll()
        {
            startControl.Hide();
            placingControl.Hide();
            battleControl.Hide();
            finishControl.Hide();
        }
    }
}
