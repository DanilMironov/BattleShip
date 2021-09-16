using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Battleship.Entities;

namespace Battleship.Views
{
    public partial class FieldControl : UserControl
    {
        private IField field;
        private bool fogOfWar;
        private Dictionary<Entities.Point, Rectangle> pointToRectangle;
        private IShip selectedShip = null;
        private bool configured = false;

        public event Action<Entities.Point, MouseEventArgs> ClickOnPoint;


        public FieldControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Resize += ResizeHandler;
            Click += ClickHandler;
            DoubleClick += ClickHandler;
        }

        public void Configure(IField field, bool fogOfWar)
        {
            if (configured)
                throw new InvalidOperationException();
            this.field = field;
            this.fogOfWar = fogOfWar;
            this.field.Updated += () => Invalidate();
            pointToRectangle = PointToRectangle(Width, Height, this.field);
            configured = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawBackground(Width, Height);

            if (!configured)
                return;

            foreach (var p in pointToRectangle)
                e.Graphics.DrawEmptyCell(p.Value);

            var conflictedPoints = field.GetConflictPoints();
            var shots = field.GetShots();

            foreach (var ship in field.GetShips().Where(s => !s.Equals(selectedShip)))
                PaintShip(e.Graphics, ship, conflictedPoints, shots, false);

            foreach (var shot in shots)
                e.Graphics.DrawShotCell(pointToRectangle[shot]);

            if (selectedShip != null)
                PaintShip(e.Graphics, selectedShip, conflictedPoints, shots, true);
        }

        private void PaintShip(Graphics graphics, IShip ship, ISet<Entities.Point> conflictPoint,
            ISet<Entities.Point> shots, bool useLight)
        {
            foreach (var point in ship.GetPositionPoints())
            {
                if (!fogOfWar || shots.Contains(point))
                {
                    graphics.DrawShipCell(pointToRectangle[point], useLight: useLight,
                        inConflict: conflictPoint.Contains(point), isShot: shots.Contains(point));
                }
            }
        }

        private void ResizeHandler(object sender, EventArgs e)
        {
            if (!configured)
                return;
            pointToRectangle = PointToRectangle(Width, Height, field);
            Invalidate();
        }

        private void ClickHandler(object sender, EventArgs e)
        {
            if (!configured)
                return;
            var args = e as MouseEventArgs;
            var pairs = pointToRectangle.Where(p => p.Value.Contains(args.Location)).ToList();
            if (pairs.Any())
                ClickOnPoint?.Invoke(pairs[0].Key, args);
        }

        private Dictionary<Entities.Point, Rectangle> PointToRectangle(int width, int height, IField field)
        {
            var res = new Dictionary<Entities.Point, Rectangle>();
            for (var dx = 0; dx < width; dx++)
            {
                for (var dy = 0; dy < height; dy++)
                {
                    var point = new Entities.Point(dx, dy);
                    var left = (width - 2) * dx / field.Width + 1;
                    var right = (width - 2) * (dx + 1) / field.Width + 1;
                    var top = (height - 2) * dy / field.Height + 1;
                    var bottom = (height - 2) * (dy + 1) / field.Height + 1;
                    var rectangle = new Rectangle(left, top, right - left, bottom - top);
                    res.Add(point, rectangle);
                }
            }
            return res;
        }

        public void SelectShip(IShip ship)
        {
            this.selectedShip = ship;
            Invalidate();
        }

        public IShip SelectedShip => selectedShip;
    }
}
