namespace FirstDesktopApp
{
    partial class LevelSelectionForm
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
            EasyButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // EasyButton
            // 
            EasyButton.BackColor = Color.Black;
            EasyButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            EasyButton.ForeColor = Color.White;
            EasyButton.Location = new Point(433, 289);
            EasyButton.Name = "EasyButton";
            EasyButton.Size = new Size(208, 61);
            EasyButton.TabIndex = 0;
            EasyButton.Text = "Start";
            EasyButton.UseVisualStyleBackColor = false;
            EasyButton.Click += EasyButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(354, 201);
            label1.Name = "label1";
            label1.Size = new Size(355, 38);
            label1.TabIndex = 1;
            label1.Text = "Ready for Game of Death";
            // 
            // LevelSelectionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LevelSelectionFormImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1027, 998);
            Controls.Add(label1);
            Controls.Add(EasyButton);
            DoubleBuffered = true;
            Name = "LevelSelectionForm";
            Text = "LevelSelectionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EasyButton;
        private Label label1;
    }
}