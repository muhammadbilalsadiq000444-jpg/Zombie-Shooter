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
    public partial class GameOpeningForm : Form
    {
        public GameOpeningForm()
        {
            InitializeComponent();
        }

         

        private void GameOpeningForm_Load(object sender, EventArgs e)
        {

        }

        private void StartButton_Click_1(object sender, EventArgs e)
        {
            LevelSelectionForm Form2 = new LevelSelectionForm();
            Form2.ShowDialog();
            this.Close();
        }
    }
}
