using GameFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstDesktopApp
{
    public partial class LevelSelectionForm : Form
    {
        public LevelSelectionForm()
        {
            InitializeComponent();
        }

        private void LevelSelectionFormPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EasyButton_Click(object sender, EventArgs e)
        {

            GameFrameWork.GameForm gameForm = new GameFrameWork.GameForm();
            gameForm.ShowDialog();
            this.Close();
        }
    }
}
