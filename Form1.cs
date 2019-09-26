﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class FormGame : Form
    {
        public Bitmap Circle_cursor = Resource1.Circle_cursor,
                      Circle_run = Resource1.Img_run;
        private Point _targetPosition = new Point(300, 300);
        private Point _direction = Point.Empty;

        public FormGame()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
        }

        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            var localPosition = this.PointToClient(Cursor.Position);

            _targetPosition.X += _direction.X;
            _targetPosition.Y += _direction.Y;

            if (_targetPosition.X < 0 || _targetPosition.X > 500)
            {
                _targetPosition.X = 200;            
            }

            if (_targetPosition.Y < 0 || _targetPosition.Y > 500)
            {
                _targetPosition.Y = 200; 
            }

            var handlerRect = new Rectangle(localPosition.X - 50, localPosition.Y - 50, 100, 100);
            var targetRect = new Rectangle(_targetPosition.X - 50, _targetPosition.Y - 50, 100, 100);
     
            g.DrawImage(Circle_cursor, handlerRect);
            g.DrawImage(Circle_run, targetRect);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            timer2.Interval = r.Next(25, 1000);
            _direction.X = r.Next(-1, 2);
            _direction.Y = r.Next(-1, 2);
        }
        
    }
}
