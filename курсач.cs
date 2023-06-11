using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficRacer
{
    public partial class Form1 : Form
    {
       private bool lose=false; 
        private int countCoins = 0;
        public Form1()
        {
            InitializeComponent();
         labelLose.Visible = false;
        restart.Visible = false;
            KeyPreview = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            int speed = 10;
            bg1.Top += speed;
            bg2.Top += speed;


            int carSpeed = 7;
            enemy1.Top += carSpeed;
            enemy2.Top += carSpeed;

            coin.Top += speed;

            if (bg1.Top >= 650)
            {
                bg1.Top = 0;
                bg2.Top = -650;
            }
            if (coin.Top >= 650)
            {
                coin.Top = -50;
                Random rand = new Random();
               coin.Left = rand.Next(150, 560);

            } 
            
            if (enemy1.Top >= 650)
            {
                enemy1.Top = -130;
                Random rand = new Random();
                enemy1.Left = rand.Next(150, 300);
            }
            if (enemy2.Top >= 650)
            {
                enemy2.Top = -400;
                Random rand = new Random();
                enemy2.Left = rand.Next(350, 560);
            }
            if (player.Bounds.IntersectsWith(enemy1.Bounds) || player.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer.Enabled = false; 
                labelLose.Visible = true;
                restart.Visible = true;
                lose=true;
            }

            if (player.Bounds.IntersectsWith(coin.Bounds))
            {
                countCoins++;
                labelCoins.Text = "Монети: " + countCoins.ToString();
                coin.Top = -50;
                Random rand = new Random();
                coin.Left = rand.Next(150, 560);
            }

        } 

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(lose) return;
            int speed = 10;
            if ((e.KeyCode ==Keys.Left||e.KeyCode==Keys.A) && player.Left > 150)
                player.Left -= speed;
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && player.Right < 700)
                player.Left += speed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enemy1.Top = -130;
            enemy2.Top = -400;
            labelLose.Visible = false;
            restart.Visible = false;
            timer.Enabled = true;
            lose = false;
            countCoins = 0;
            labelCoins.Text = "Монети: 0 ";
            coin.Top = -500;
        }

        private void labelLose_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
