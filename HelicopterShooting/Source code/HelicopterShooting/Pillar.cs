using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelicopterShooting
{
    class Pillar
    {
        #region Thuoc tinh
        private PictureBox pillar;
        int rong = 60;
        int dai = 500;
        int speedPillar = 6;
        #endregion

        #region Constructor
        public Pillar(Form f1, int x, int y)
        {
            pillar = new PictureBox();
            pillar.BackgroundImage = Properties.Resources.pillar;
            pillar.BackColor = Color.Transparent;
            pillar.Size = new Size(rong, dai);
            pillar.Location = new Point(x, y);
            f1.Controls.Add(pillar);
        }
        #endregion

        #region Draw
        public void Appearance()
        {
            if (pillar.Left < -100)
            {
                Random rnd = new Random();
                int x = rnd.Next(600, 700);

                pillar.Left = x;
            }
        }
        #endregion

        //Ham di chuyen pillar
        public void PillarMove()
        {
            pillar.Left -= speedPillar;
        }
        #region Get cac thuoc tinh
        public int getHeight()
        {
            return pillar.Height;
        }
        public int getWidth()
        {
            return pillar.Width;
        }
        public int getLeft()
        {
            return pillar.Left;
        }
        public PictureBox getPic()
        {
            return pillar;
        }
        #endregion

        //Huy doi tuong pillar
        public void Dispose()
        {
            pillar.Dispose();
        }
    }
}
