using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPongGame
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;  //ball speeds
        public int speed_top = 4;
        public int point = 0;       //score
        public int level = 1;
        //Obstacle obstacle;

        public Form1()
        {
            InitializeComponent();
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None; //remove any border
            this.TopMost = true;    //bring form to the front
            this.Bounds = Screen.PrimaryScreen.Bounds;   //Make it fullscreen
            racket.Top = playGround.Bottom - (playGround.Bottom / 10); //racket position setting
            label1.Left = (playGround.Width / 2) - (label1.Width / 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);

            //DrawObstacle(playGround);
            ball.Left += speed_left;
            ball.Top += speed_top;

            if (ball.Bottom>=racket.Top&&ball.Bottom<=racket.Bottom&&ball.Left>=racket.Left&&ball.Right<=racket.Right)
            {
                //speed_top += 1;
                //speed_left += 1;
                if ((point + 1) % 5 == 0)
                {
                    level = 1 + ((point + 1) / 5);
                    speed_left = 2;
                    speed_top = 2;
                }
                Random rnd = new Random();
                int modLeft = rnd.Next(-level, level);
                int modTop = rnd.Next(0, level);
                speed_top = -(speed_top + modTop);
                speed_left = (speed_left + modLeft);
                point++;
                score_lbl.Text = "Points : " + point;
                Random r = new Random();
                playGround.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));
                level_lbl.Text = "Level : " + level;
            }
            if (ball.Left<=playGround.Left)
            {
                speed_left = -speed_left;
            }
            if (ball.Right>=playGround.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top<=playGround.Top)
            {
                speed_top = -speed_top;
            }
            if (ball.Bottom>=playGround.Bottom)
            {
                timer1.Enabled = false;
                label1.Visible = true;
            }
        }

        //private void DrawObstacle(Panel canvas)
        //{
        //    Random rnd = new Random();
        //    obstacle = new Obstacle(rnd.Next(0, (playGround.Width / 50)), rnd.Next(0, (playGround.Height / 15)));
        //    canvas.FillRectangle(new SolidBrush(Color.Black), new Rectangle(obstacle.X * 50, obstacle.Y * 15, 50, 15));
        //}

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();  //escape to close app
            }
            if (e.KeyCode==Keys.Enter)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                point = 0;
                score_lbl.Text = string.Empty;
                timer1.Enabled = true;
                label1.Visible = false;
                playGround.BackColor = Color.White;
            }
        }
        //public void DrawObstacle(Graphics canvas)
        //{
        //    Random rnd = new Random();
        //    obstacle= new Obstacle(rnd.Next(0,(playGround.Width/50)),rnd.Next(0,(playGround.Height/15)));
        //    canvas.FillRectangle(new SolidBrush(Color.Black), new Rectangle(obstacle.X * 50, obstacle.Y * 15, 50, 15));
        //}
    }
}
