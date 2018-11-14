using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelicopterShooting
{
    class Sprites
    {
        #region Thuoc tinh
        Graphics g;
        int speed;
        Image image;
        Rectangle rect;
        PictureBox bullet;
        int index;
        int healthpoint;
        #endregion

        #region Constructor
        public Sprites()
        {
            healthpoint = 3;
            image = Properties.Resources.heli1;
            rect = new Rectangle(0, 50, 100, 54);
            speed = 10;
            index = 0;
        }
        #endregion

        #region Draw
        public void Draw(PaintEventArgs e)
        {
            ++index;
            if (index == 0) image = Properties.Resources.heli1;
            if (index == 1) image = Properties.Resources.heli2;
            if (index == 3) image = Properties.Resources.heli3;
            if (index == 4) image = Properties.Resources.heli4;
            if (index > 4) index = 0;
            g = e.Graphics;
            g.DrawImage(image, rect);
        }
        #endregion


        #region Move
        public void setRecUp()
        {
            rect.Y -= speed;
        }
        public void setRecDown()
        {
            rect.Y += speed;
        }
        #endregion

        #region MakeBullet
        public void MakeBullet(Form f1)
        {
            bullet = new PictureBox();
            bullet.BackColor = System.Drawing.Color.DarkOrange;
            bullet.Height = 5;
            bullet.Width = 10;
            bullet.Tag = "bullet";
            bullet.Location = new Point(rect.X+80, rect.Y + 54 / 2) ;
            f1.Controls.Add(bullet);
        }
        #endregion

        #region Get/Set cac thuoc tinh

        public Rectangle Rectangle()
        {
            return rect;
        }
        public PictureBox getbullet()
        {
            return bullet;
        }

        public int Healpoint()
        {
            return healthpoint;
        }
        public void Healpoint(int a)
        {
            healthpoint -= a;
        }

        public Graphics graphics()
        {
            return g;
        }
        #endregion
    }
}
