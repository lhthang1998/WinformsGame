using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelicopterShooting
{
    class Enemy
    {
        #region Thuoc tinh
        Image image;
        Graphics g;
        Rectangle rect;
        int index;
        int speed =6;
        int type;
        #endregion

        #region Constructor
        public Enemy(int x,int y)
        {
            Random rnd = new Random();
            type = rnd.Next(1,4);
            rect = new Rectangle(x, y, 100, 60);
            index = 0;
        }
        #endregion

        #region Draw
        public void Draw(PaintEventArgs e)
        {
            
            if (type ==1)
            {
                ++index;
                if (index == 0) image = Properties.Resources.alien1_1;
                if (index == 1) image = Properties.Resources.alien1_2;
                if (index == 2) image = Properties.Resources.alien1_3;
                if (index == 3) image = Properties.Resources.alien1_4;
                if (index > 4) index = 0;
            }
            if(type==2)
            {
                ++index;
                if (index == 0) image = Properties.Resources.alien2_1;
                if (index == 1) image = Properties.Resources.alien2_2;
                if (index == 2) image = Properties.Resources.alien2_3;
                if (index == 3) image = Properties.Resources.alien2_4;
                if (index == 4) image = Properties.Resources.alien2_5;
                if (index > 4) index = 0;
            }
            if(type==3)
            {
                ++index;
                if (index == 0) image = Properties.Resources.alien3_1;
                if (index == 1) image = Properties.Resources.alien3_2;
                if (index == 2) image = Properties.Resources.alien3_3;
                if (index == 3) image = Properties.Resources.alien3_4;
                if (index == 4) image = Properties.Resources.alien3_5;
                if (index > 4) index = 0;
            }
            g = e.Graphics;
            g.DrawImage(image, rect);

        }
        #endregion

        #region Move
        public void Move()
        {
            rect.X -= speed;
        }
        #endregion


        #region Get cac thuoc tinh
        public int getHeigth()
        {
            return rect.Height;
        }
      

        public int getLeft()
        {
            return rect.Left;
        }
        public Image Image()
        {
            return image;
        }

        public Rectangle Rectangle()
        {
            return rect;
        }
        public void SetLeft(int x)
        {
            rect.Location = new Point(x, 0);
        }
        public Graphics graphics()
        {
            return g;
        }
        #endregion
    }
}
