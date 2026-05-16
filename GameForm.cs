using EZInput;
using FirstDesktopApp.Core;
using FirstDesktopApp.Entities;
using FirstDesktopApp.Properties;
using FirstDesktopApp.Systems;
using GameFrameWork;
using Microsoft.VisualBasic.Devices;
using NAudio;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFrameWork
{

    //     
    public partial class GameForm : Form
    {
        public static GameForm Instance;

        public Game game = new Game();
        PhysicsSystem physics = new PhysicsSystem();
        CollisionSystem collisions = new CollisionSystem();
        EnemySpawner spawner;
        bool isGameOver = false;

        public SoundPlayer fireSound;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private WaveOutEvent waveOut;
        private Mp3FileReader mp3Reader;

        Player mainPlayer;
        private ProgressBar healthBar;
        private Label label2;
         
        private Label label1;


        public GameForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Instance = this;

            Setting();

            mp3Reader = new Mp3FileReader("C:\\Users\\User\\Downloads\\gunshot-352466.mp3");

            waveOut = new WaveOutEvent();

            waveOut.Init(mp3Reader);

            LevelManager.Level = 1;
            File.WriteAllText("level.txt", "1");



            timer.Interval = 20;
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void Setting()
        {
            mainPlayer = new Player
            {
                Position = new PointF(615, 606),
                Size = new Size(80, 80),
                Sprite = Resources.up,
                Movement = new KeyboardMovement()
            };

            game.AddObject(mainPlayer);


            spawner = new EnemySpawner(game, mainPlayer);
            spawner.SpawnLevelEnemies(1); // Level 1 start




        }

        private void InitializeComponent()
        {
            label2 = new Label();
            healthBar = new ProgressBar();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new System.Drawing.Point(1021, 36);
            label2.Name = "label2";
            label2.Size = new Size(120, 38);
            label2.TabIndex = 0;
            label2.Text = "Health: ";
            // 
            // healthBar
            // 
            healthBar.Location = new System.Drawing.Point(1133, 40);
            healthBar.Name = "healthBar";
            healthBar.Size = new Size(183, 34);
            healthBar.TabIndex = 1;
            healthBar.Value = 100;
            // 
            // GameForm
            // 
            BackgroundImage = Resources.WhatsApp_Image_2026_01_07_at_1_30_53_AM;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1328, 759);
            Controls.Add(healthBar);
            Controls.Add(label2);
            Name = "GameForm";
            ResumeLayout(false);
            PerformLayout();

        }









        protected override void OnPaint(PaintEventArgs e)
        {
            game.Draw(e.Graphics);

            e.Graphics.DrawString($"Kills: {GameStats.Score}",
                new Font("Arial", 14, FontStyle.Bold), Brushes.Red, 570, 26);

            e.Graphics.DrawString($"Level: {LevelManager.Level}",
                new Font("Arial", 14, FontStyle.Bold), Brushes.White, 10, 26);

            e.Graphics.DrawString($"HighScore: {GameStats.HighScore}",
                new Font("Arial", 14, FontStyle.Bold), Brushes.Yellow, 10, 70);

            e.Graphics.DrawString($"Ammo: {mainPlayer.Ammo}",
                new Font("Arial", 14, FontStyle.Bold), Brushes.White, 325, 26);


        }

        private void TimerTick(object sender, EventArgs e)
        {

            if (EZInput.Keyboard.IsKeyPressed(Key.Space) && mainPlayer.Ammo > 0)
            {



                waveOut.Stop();
                mp3Reader.Position = 0;
                waveOut.Play();

            }

            if (mainPlayer.Health <= 0 && !isGameOver)
            {
                isGameOver = true;
                timer.Stop();
                GameStats.SaveScore();
                mainPlayer.Sprite = FirstDesktopApp.Properties.Resources.dead;

                MessageBox.Show("GAME OVER");
                Application.Exit();
                return;
            }

            game.Update(new GameTime());
            physics.Apply(game.Objects.ToList());
            collisions.Check(game.Objects.ToList());
            game.Cleanup();
            //if (!game.Objects.Any(o => o is Enemy))
            //{
            //    GameStats.SaveScore();
            //    LevelManager.NextLevel();
            //    StartLevel(LevelManager.Level);

            //}
            if (!game.Objects.Any(o => o is Enemy))
            {
                GameStats.SaveScore();
                LevelManager.NextLevel();

                mainPlayer.Position = new PointF(615, 606);
                mainPlayer.Ammo = 10;
                mainPlayer.Health = 100;


                spawner.SpawnLevelEnemies(LevelManager.Level);
            }


            healthBar.Value = mainPlayer.Health;

            if (mainPlayer.Health < 30)
            {
                healthBar.ForeColor = Color.Red;
            }
            else
            {
                healthBar.ForeColor = Color.Green;
            }


            //if (!game.Objects.Any(o => o is Enemy))
            //{
            //    GameStats.SaveScore();
            //    LevelManager.NextLevel();


            //    mainPlayer.Position = new PointF(615, 606);
            //    mainPlayer.Ammo = 10;
            //    mainPlayer.Health = 100;


            //    spawner.SpawnEnemies(LevelManager.Level + 2);
            //}





            if (mainPlayer.Ammo == 0 &&
                !game.Objects.Any(o => o is AmmoPowerUp))
            {
                AmmoPowerUp p = new AmmoPowerUp();
                p.Size = new SizeF(40, 40);
                p.Position = new PointF(
                    new Random().Next(50, 1200),
                    new Random().Next(50, 700)
                );

                game.AddObject(p);
            }
            Invalidate();

        }
        private void StartLevel(int level)
        {

            game.Objects.RemoveAll(o => o is Enemy);


            mainPlayer.Position = new PointF(615, 606);
            mainPlayer.Ammo = 10;
            mainPlayer.Health = 100;


            //spawner.SpawnEnemies(level + 2);
            spawner.SpawnLevelEnemies(LevelManager.Level);
        }




        private void timer1_Tick(object sender, EventArgs e)
        {

        }


        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}

//        public void InitializeComponent()
//        {
//            healthBar = new ProgressBar();
//            label1 = new Label();
//            SuspendLayout();
//            // 
//            // healthBar
//            // 
//            healthBar.Location = new System.Drawing.Point(1065, 26);
//            healthBar.Name = "healthBar";
//            healthBar.Size = new Size(264, 34);
//            healthBar.TabIndex = 0;
//            healthBar.Value = 100;
//            // 
//            // label1
//            // 
//            label1.AutoSize = true;
//            label1.BackColor = Color.Transparent;
//            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
//            label1.ForeColor = Color.Transparent;
//            label1.Location = new System.Drawing.Point(955, 26);
//            label1.Name = "label1";
//            label1.Size = new Size(112, 38);
//            label1.TabIndex = 1;
//            label1.Text = "Health:";
//            // 
//            // GameForm
//            // 
//            BackColor = Color.FromArgb(64, 64, 64);
//            BackgroundImage = Resources.WhatsApp_Image_2026_01_07_at_1_30_53_AM;
//            BackgroundImageLayout = ImageLayout.Stretch;
//            ClientSize = new Size(1364, 858);
//            Controls.Add(label1);
//            Controls.Add(healthBar);
//            Name = "GameForm";
//            ResumeLayout(false);
//            PerformLayout();

//        }
//    }
//}

