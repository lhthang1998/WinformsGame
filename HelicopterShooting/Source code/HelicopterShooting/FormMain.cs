using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelicopterShooting
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.HelicopterShooting;
        }

        //Hàm gọi form chính của Game
        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Nhiệm vụ của bạn là hãy lái chiếc trực thăng vượt chướng ngại vật và tiêu diệt kẻ thù càng nhiều càng tốt \nNhấn phím mũi tên lên/xuống để di chuyển trực thăng và nhấn phím Space để bắn đạn", "Hướng dẫn");
            this.Hide();
            MainGame g = new MainGame();
            if (checkBox1.Checked == true) g.EnableSound(true);
            g.Show();
            
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        //Hàm đóng Application khi nhấn button Exit
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
