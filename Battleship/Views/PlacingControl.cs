using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battleship.Entities;
using Battleship.Opponent;

namespace Battleship.Views
{
    public partial class PlacingControl : UserControl
    {
        private Game game;

        public PlacingControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            endButton.Click += EndButtonClick;
            endButton.Enabled = game.CanFinishPlacingCurrentPlayerShips;
            game.FirstPlayer.Field.Updated += () =>
            {
                endButton.Enabled = game.CanFinishPlacingCurrentPlayerShips;
            };

            fieldControl.Configure(game.FirstPlayer.Field, false);
            fieldControl.ClickOnPoint += FieldControlClickOnPoint;
        }

        private void EndButtonClick(object sender, EventArgs e)
        {
            if (game.CurrentPlayer.Equals(game.FirstPlayer))
                game.EndPlacingCurrentPlayerShips();
            
            if (!game.CurrentPlayer.Equals(game.FirstPlayer))
            {
                if (game.CurrentPlayer.Field.RandomShipPlacing())
                    game.EndPlacingCurrentPlayerShips();
                else
                    MessageBox.Show("Попробуйте еще раз");
            }
        }

        private void FieldControlClickOnPoint(Entities.Point point, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                fieldControl.SelectShip(null);
                return;
            }
            
            if (e.Button == MouseButtons.Left)
            {
                var selectedShip = fieldControl.SelectedShip;
                if (selectedShip != null)
                {
                    if (selectedShip.GetPositionPoints().Contains(point))
                        game.CurrentPlayer.Field.ChangeDirection(selectedShip);
                    else
                        game.CurrentPlayer.Field.PutShip(selectedShip, point);
                    fieldControl.SelectShip(null);
                    return;
                }

                var shipAt = game.CurrentPlayer.Field.GetShipsAtPoint(point).FirstOrDefault();
                if (shipAt != null)
                {
                    fieldControl.SelectShip(shipAt);
                    return;
                }

                var shipToPut = game.CurrentPlayer.Field.GetShipToPutOrNull();
                if (shipToPut != null)
                {
                    game.CurrentPlayer.Field.PutShip(shipToPut, point);
                    return;
                }
            }
        }
    }

}
