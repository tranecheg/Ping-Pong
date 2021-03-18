using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        private int speed_ver = 3;
        private int speed_hor = 3;
        private int score = 0;

        public Form1()
        {
            InitializeComponent();
            timer.Enabled = true;
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            this.Bounds = Screen.PrimaryScreen.Bounds;

            gamePanel.Top = background.Bottom - (background.Bottom / 10);
            loseLabel.Visible = false;
            loseLabel.Left = (background.Width / 2) - (loseLabel.Width / 2);
            loseLabel.Top = (background.Height / 2) - (loseLabel.Height / 2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Space)
            {
                timer.Enabled = true;
                speed_ver = 3;
                speed_hor = 3;
                score = 0;
                ball.Top = 50;
                gamePanel.Left = 70;
                result.Text = "Результат 0";
                loseLabel.Visible = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gamePanel.Left = Cursor.Position.X - (gamePanel.Width / 2);

            ball.Left += speed_hor;
            ball.Top += speed_ver;

            if (ball.Left <= background.Left)
                speed_hor *= -1;
            if (ball.Right >= background.Right)
                speed_hor *= -1;
            if (ball.Top <= background.Top)
                speed_ver *= -1;
            if (ball.Bottom >= background.Bottom)
            {
                timer.Enabled = false;
                loseLabel.Visible = true;
            }
            if (ball.Bottom>=gamePanel.Top && ball.Bottom <= gamePanel.Bottom &&
                ball.Left >= gamePanel.Left && ball.Right <= gamePanel.Right)
            {
                speed_hor += 2;
                speed_ver += 2;
                speed_ver *= -1;
                score++;
                result.Text = "Результат " + score.ToString();
                Random rnd = new Random();

               
                background.BackColor = Color.FromArgb(rnd.Next(150, 255), rnd.Next(150, 255), rnd.Next(150, 255));
            }
        }
    }
}
