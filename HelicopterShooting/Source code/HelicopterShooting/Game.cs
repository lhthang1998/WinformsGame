using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace HelicopterShooting
{
    class Game
    {
        #region Thuoc tinh
        SoundPlayer pl;
        bool sound;
        int score;
        Sprites player;
        Pillar pillar1;
        Pillar pillar2;
        bool enable;
        Random rnd;
        Enemy enemy;
        int DoChenhLech = 80;
        bool up;
        bool down;
        bool shoot;
        #endregion

        #region Constructor
        public Game()
        {

        }
        public Game(Form f1)
        {
            pl = new SoundPlayer();
            sound = false;
            rnd = new Random();
            player = new Sprites();
            enable = true;
            TaoPillar(f1);
            TaoEnemy();
        }
        #endregion

        #region Tao doi tuong trong game
        void TaoPillar(Form f1)
        {

            int y = rnd.Next(-470, -150);
            int x = 700;
            pillar1 = new Pillar(f1, x, y);
            pillar2 = new Pillar(f1, x, pillar1.getHeight() + y + DoChenhLech);
            enable = true;

        }

        void TaoEnemy()
        {
            enemy = new Enemy(pillar1.getLeft() + pillar1.getWidth() + rnd.Next(200, 400), rnd.Next(100, 350) - 48);
        }
        #endregion

        #region Ve doi tuong
        public void Draw(PaintEventArgs e)
        {
            player.Draw(e);
            if (enable == true) enemy.Draw(e);
        }
        #endregion

        #region NewGame
        public void NewGame(Form f1,Label label1,Label label2,Timer timer1)
        {
            if (up)
            {
                if (player.Rectangle().Y >= 0)
                    player.setRecUp();
            }
            if (down)
            {
                if ((player.Rectangle().Y + player.Rectangle().Height) <= f1.Size.Height - player.Rectangle().Height)
                    player.setRecDown();
            }

            if (shoot)
                player.MakeBullet(f1);
            enemy.Move();
            f1.Invalidate();
            //Xet di chuyen cua vien dan trong form
            foreach (Control temp in f1.Controls)
            {
                if (temp is PictureBox && temp.Tag == "bullet")
                {
                    temp.Left += 10;
                    if (temp.Left >= 800)
                    {
                        f1.Controls.Remove(temp);
                        temp.Dispose();
                    }
                    if ((temp.Left + temp.Width) >= enemy.getLeft() && temp.Location.Y >= enemy.Rectangle().Y && temp.Location.Y <= enemy.Rectangle().Y + enemy.Rectangle().Height)
                    {
                        score++;
                        if (sound == true) PlaySound("ding_sound.wav");                       
                        player.Healpoint(-1);
                        enemy.SetLeft(-120);
                        f1.Controls.Remove(temp);
                        temp.Dispose();
                    }

                }
            }

            //Ham ong ngai vat di chuyen
            pillar1.PillarMove();
            pillar2.PillarMove();
            //Ham huy doi tuong Enemy khi di khoi khung hinh
            if (enemy.getLeft() < -100)
            {
                player.Healpoint(1);
                enemy.graphics().Dispose();
                if (enable == false) enable = true;
                TaoEnemy();
            }

            //Ham huy doi tuong ong ngai vat khi di khoi khung hinh
            if (pillar1.getLeft() < -100)
            {
                f1.Controls.Remove(pillar1.getPic());
                f1.Controls.Remove(pillar2.getPic());
                pillar1.getPic().Dispose();
                pillar2.getPic().Dispose();
                enable = false;
                TaoPillar(f1);
            }

            label1.Text = "MISS : " + player.Healpoint();
            label2.Text = "SCORE : " + score.ToString();
            //Xu ly va cham
            if (CheckVaCham() == true || player.Healpoint() == 0)
            {
                if (sound == true) PlaySound("crash_sound.wav");
                timer1.Stop();
                MessageBox.Show("Kết thúc game! Bạn đã đạt được số điểm là "+score);
                FormMain fm = new FormMain();
                fm.Show();
                EndGame(f1);
            }
        }
        #endregion

        #region Ket thuc game
        public void EndGame(Form f1)
        {
            f1.Dispose();
        }
        #endregion


        #region Check va cham cua cac doi tuong
        private bool CheckVaCham()
        {
            int x1 = 0;
            int x2 = x1 + player.Rectangle().Width;
            int y1 = player.Rectangle().Location.Y;
            int y2 = y1 + player.Rectangle().Height;
            //Check player va cham voi Enemy
            if (player.Rectangle().IntersectsWith(enemy.Rectangle()) && (player.Rectangle().Left + player.Rectangle().Width) >= (enemy.Rectangle().Left + 20)&&((player.Rectangle().Location.Y<=enemy.Rectangle().Location.Y+enemy.Rectangle().Height-10)||(player.Rectangle().Location.Y+player.Rectangle().Height>=enemy.Rectangle().Location.Y-20))) return true;
            //TH1 : Player vừa ở trước 2 cột
            if (x2 - 15 == pillar1.getPic().Location.X)
            {
                if (y1 <= pillar1.getPic().Location.Y + pillar1.getPic().Height || y2 >= pillar2.getPic().Location.Y)
                    return true;
            }
            //TH2 : Player nằm giữa 2 cột
            if (x2 - 15 > pillar1.getPic().Location.X && x2 - 15 <= pillar1.getPic().Location.X + pillar1.getPic().Width)
            {
                if (y1 <= pillar1.getPic().Location.Y + pillar1.getPic().Height || y2 >= pillar2.getPic().Location.Y)
                    return true;
            }
            //TH3 : Play đã đi qua 1 nửa giữa 2 cột
            if (x2 - 15 > pillar1.getPic().Location.X + pillar1.getPic().Width)
            {
                if (x1 <= pillar1.getPic().Location.X + pillar1.getPic().Width)
                {
                    if (y1 <= pillar1.getPic().Location.Y + pillar1.getPic().Height || y2 - 10 >= pillar2.getPic().Location.Y)
                        return true;
                }
            }
            return false;
        }
        #endregion

        #region Gan co cho su kien an phim len/xuong/Space
        public void SetUp(bool x)
        {
            up = x;
        }
        public void SetDown(bool x)
        {
            down = x;
        }
        public void SetShoot(bool x)
        {
            shoot = x;
        }
        #endregion

        //Bật tắt âm thanh
        public void SetSound(bool x)
        {
            sound = x;
        }

        void PlaySound(string s)
        {
            pl.SoundLocation = Application.StartupPath + @"\Sounds\" + s;
            pl.Play();
        }
    }
}
