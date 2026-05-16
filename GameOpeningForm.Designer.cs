namespace FirstDesktopApp
{
    partial class GameOpeningForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartButton = new Button();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StartButton.BackColor = Color.Black;
            StartButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StartButton.ForeColor = Color.White;
            StartButton.Location = new Point(1067, 774);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(191, 62);
            StartButton.TabIndex = 0;
            StartButton.Text = "Press to Enter in City";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click_1;
            // 
            // GameOpeningForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            BackgroundImage = Properties.Resources.ZombieShooterOpening;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1444, 987);
            Controls.Add(StartButton);
            DoubleBuffered = true;
            Name = "GameOpeningForm";
            Text = "GameOpeningForm";
            Load += GameOpeningForm_Load;
            ResumeLayout(false);
        }

        #endregion


        private Panel GameOpeningFormPanel;
        private Button StartButton;
    }
}