using Battleship.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Views
{
    public partial class StartControl : UserControl
    {
        private Game game;

        public StartControl()
        {
            InitializeComponent();

        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;
            this.game = game;

            startButton.Click += StartClick;
        }

        private void StartClick(object sender, EventArgs e)
        {
            game.Start("Player1", "Player2");
        }
    }
}
