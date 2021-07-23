using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombineNumber
{
    public partial class RankForm : Form
    {
        public RankForm()
        {
            InitializeComponent();
            foreach (Player player in Program.Top10PlayerList)
            {
                ListViewItem item = new ListViewItem();
                item = rankListView.Items.Add(player.Name);
                item.SubItems.Add(player.Score.ToString());
            }
        }

        private void RankForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.CurrentFormType = null;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Program.CurrentFormType = typeof(MenuForm);
            this.Dispose();
        }

    }
}
