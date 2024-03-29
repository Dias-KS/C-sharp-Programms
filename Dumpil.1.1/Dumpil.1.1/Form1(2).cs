﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Dumpil._1._1
{
    public partial class Form1_2_ : Form
    {
        PictureBox[] clouds;
        int cloudsSpeed;
        Random rnd;
        int playerSpeed;

        PictureBox[] bullets;
        int bulletsSpeed;

        PictureBox[] enemies;
        int sizeEnemy;
        int enemiesSpeed;


        int O4ki;
        int Level;

        WindowsMediaPlayer Gamesong;

        WindowsMediaPlayer GameOVERsong;

        WindowsMediaPlayer GoodGamesong;


        public Form1_2_()
        {
            InitializeComponent();
        }

        private void Form1_2__Load(object sender, EventArgs e)
        {
            Gamesong = new WindowsMediaPlayer();
            Gamesong.URL = "songs\\Dire Straits - Money For Nothing (mp3cut.net) (1).mp3";
            Gamesong.settings.setMode("loop", true);
            Gamesong.settings.volume = 30;

            GameOVERsong = new WindowsMediaPlayer();
            GameOVERsong.URL = "songs\\GameOverSong.mp3";
            GameOVERsong.settings.volume = 30;

            GoodGamesong = new WindowsMediaPlayer();
            GoodGamesong.URL = "songs\\Victory.mp3";
            GoodGamesong.settings.volume = 30;
            GoodGamesong.controls.stop();

            rnd = new Random();
            enemies = new PictureBox[6];
            int sizeEnemy = rnd.Next(120, 120);
            enemiesSpeed = 30;

            O4ki = 0;
            Level = 1;

            Image easyEnemies = Image.FromFile("assets\\GifZombie.gif");

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(sizeEnemy, sizeEnemy);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BackColor = Color.Transparent;
                enemies[i].Image = easyEnemies;
                enemies[i].Location = new Point((i + 1) * rnd.Next(90, 100) + 1080, rnd.Next(400, 600));


                this.Controls.Add(enemies[i]);

            }


            bullets = new PictureBox[1];
            bulletsSpeed = 80;
            playerSpeed = 6;
            cloudsSpeed = 2;
            clouds = new PictureBox[20];
            rnd = new Random();

            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox();
                bullets[i].BorderStyle = BorderStyle.None;
                bullets[i].Size = new Size(10, 3);
                bullets[i].BackColor = Color.Red;


                this.Controls.Add(bullets[i]);
            }

            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i] = new PictureBox();
                clouds[i].BorderStyle = BorderStyle.None;
                clouds[i].Location = new Point(rnd.Next(-1000, 1280), rnd.Next(140, 320));
                if (i % 2 == 1)
                {
                    clouds[i].Size = new Size(rnd.Next(100, 225), rnd.Next(30, 70));
                    clouds[i].BackColor = Color.FromArgb(rnd.Next(50, 125), 255, 200, 200);
                }

                else
                {
                    clouds[i].Size = new Size(150, 25);
                    clouds[i].BackColor = Color.FromArgb(rnd.Next(50, 125), 255, 205, 205);
                }
                this.Controls.Add(clouds[i]);

            }
            Gamesong.controls.play();
        }

         
        

        private void LEFTtimer1_Tick_1(object sender, EventArgs e)
        {
            if (Player2.Left > 10)
            {
                Player2.Left -= playerSpeed;
            }
        }

        

        private void Form1_2__KeyDown_1(object sender, KeyEventArgs e)
        {

            Player2.Image = Properties.Resources.ArtemisRun1;

            if (e.KeyCode == Keys.A)
            {
                LEFTtimer1.Start();

            }

            if (e.KeyCode == Keys.D)
            {
                RIGHTtimer1.Start();

            }

            if (e.KeyCode == Keys.W)
            {
                UPtimer1.Start();

            }

            if (e.KeyCode == Keys.S)
            {
                DOWNtimer1.Start();

            }

            if (e.KeyCode == Keys.Space)

            {
                Player2.Image = Properties.Resources.ArtemisShoot1;

                for (int i = 0; i < bullets.Length; i++)
                {
                    Intersect1();

                    if (bullets[i].Left > 1280)
                    {
                        bullets[i].Location = new Point(Player2.Location.X + 100 + i * 50, Player2.Location.Y + 35);
                    }
                }

            }
        }



        private void Form1_2__KeyUp_1(object sender, KeyEventArgs e)
        {
            Player2.Image = Properties.Resources.ArtemisStand1;

            LEFTtimer1.Stop();
            RIGHTtimer1.Stop();
            UPtimer1.Stop();
            DOWNtimer1.Stop();

        }


        private void BULLETStimer1_Tick_1(object sender, EventArgs e)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].Left += bulletsSpeed;
            }
        }

        private void ENEMIEStimer1_Tick_1(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiesSpeed);
        }

        private void MoveEnemies(PictureBox[] enemies, int speed)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Left -= speed + (int)(Math.Sin(enemies[i].Left * Math.PI / 120) + Math.Cos(enemies[i].Left * Math.PI / 120));

                Intersect1();

                if (enemies[i].Left < this.Left)
                {
                    int sizeEnemy = rnd.Next(100, 100);
                    enemies[i].Size = new Size(sizeEnemy, sizeEnemy);
                    enemies[i].Location = new Point((i + 1) * rnd.Next(150, 250) + 1280, rnd.Next(400, 600));
                }
            }

        }

        private void Intersect1()
        {
            for (int i = 0; i < enemies.Length; i++)
            {

                if (bullets[0].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    O4ki += 1;
                    label4.Text = (O4ki < 10) ? "0" + O4ki.ToString() : O4ki.ToString();


                    if (O4ki % 20 == 0)
                    {
                        Level += 1;
                        label5.Text = (Level < 10) ? "0" + Level.ToString() : Level.ToString();


                        if (Level == 2)
                        {
                            enemiesSpeed += 3;
                        }
                        if (Level == 3)
                        {
                            enemiesSpeed += 4;
                        }

                        if (Level == 4)
                        {
                            enemiesSpeed += 5;
                        }


                        if (Level == 5)
                        {
                            GameOver1("GOOD GAME!");
                            button1.Visible = true;
                            button1.Location = new Point(565, 150);
                            Gamesong.controls.stop();
                            GoodGamesong.controls.play();
                            
                        }
                    }




                    enemies[i].Location = new Point((i + 1) * rnd.Next(150, 250) + 1280, rnd.Next(450, 650));
                    bullets[0].Location = new Point(4000, Player2.Location.Y + 50);
                }

                if (Player2.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    Player2.Visible = false;

                    GameOver1("GAME OVER");
                    button1.Visible = true;
                    button1.Location = new Point(565, 150);
                    Gamesong.controls.stop();
                    GameOVERsong.controls.play();

                }

            }
        }

        private void GameOver1(string str)
        {
            label1.Text = str;
            label1.Location = new Point(450, 50);
            label1.Visible = true;

            ENEMIEStimer1.Stop();
            
        }

        

        private void BGtimer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].Left += cloudsSpeed;

                if (clouds[i].Left >= 1280)
                {
                    clouds[i].Left = clouds[i].Height;
                }
            }

            for (int i = clouds.Length; i < clouds.Length; i++)
            {
                clouds[i].Left += cloudsSpeed - 10;

                if (clouds[i].Left >= 1280)
                {
                    clouds[i].Left = clouds[i].Left;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2_2_ frm2_2_ = new Form2_2_();
            frm2_2_.Show();
            this.Hide();
        }

        private void UPtimer1_Tick(object sender, EventArgs e)
        {
            if (Player2.Top > 400)
            {
                Player2.Top -= playerSpeed;
            }
        }

        private void DOWNtimer1_Tick(object sender, EventArgs e)
        {
            Player2.Top += playerSpeed;
        }

        private void RIGHTtimer1_Tick(object sender, EventArgs e)
        {
            if (Player2.Left < 1150)
            {
                Player2.Left += playerSpeed;
            }
        }

        private void Form1_2__KeyUp(object sender, KeyEventArgs e)
        {
            Player2.Image = Properties.Resources.ArtemisStand1;

            LEFTtimer1.Stop();
            RIGHTtimer1.Stop();
            UPtimer1.Stop();
            DOWNtimer1.Stop();
        }

        private void ENEMIEStimer1_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiesSpeed);
        }

        private void BULLETStimer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].Left += bulletsSpeed;
            }
        }
    }
}

