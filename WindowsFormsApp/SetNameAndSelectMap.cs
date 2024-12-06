using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonsterHunterProjOOPII;
using System.IO;
namespace WindowsFormsApp
{
    public partial class SetNameAndSelectMap : Form
    {
        public SetNameAndSelectMap()
        {
            InitializeComponent();
        }

        HUNTER hunter = new HUNTER(0, 0);

        string mapText;

        private void textBoxNameSet_TextChanged(object sender, EventArgs e)
        {

          
        }
        private void textBoxNameSet_Leave(object sender, EventArgs e)
        {
            hunter.NAME = textBoxNameSet.Text;
            if (hunter.hunterValidationError != "")
            {
                MessageBox.Show("Name invalid, " + hunter.hunterValidationError);
                textBoxNameSet.Text = "";
            
            }

        }

        private void SetNameAndSelectMap_Load(object sender, EventArgs e)
        {

        }

        private void SetNameAndSelectMap_Click(object sender, EventArgs e)
        {
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.hunter = hunter;
            game.selectedMap = mapText;
            game.Show();
            this.Hide();

        }

        private void SetNameAndSelectMap_Load_1(object sender, EventArgs e)
        {
            //add items (maps) to the combo box
            string[] mapFiles = Directory.GetFiles(@".", "*.txt");

            //list all the files in...
            foreach (string eachFile in mapFiles)
            {
                listBoxMaps.Items.Add(eachFile);
            }
        }

        private void listBoxMaps_Leave(object sender, EventArgs e)
        {
            mapText = listBoxMaps.Text;
        }
    }
}
