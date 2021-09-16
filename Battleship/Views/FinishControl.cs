using Battleship.Entities;
using System.Windows.Forms;

namespace Battleship.Views
{
    public partial class FinishControl : UserControl
    {
        private Game game;

        public FinishControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            humanFieldControl.Configure(game.FirstPlayer.Field, false);
            opponentFieldControl.Configure(game.SecondPlayer.Field, false);

            if (game.FirstPlayer.Field.HasAliveShips())
                winLabel.Text = "Победа";
            else
                winLabel.Text = "Проиграл";
        }
    }
}
