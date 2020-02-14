using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitClient.Services;
using LibGit2Sharp;

namespace GitClient
{
    public partial class Form1 : Form
    {
        GitService gs = new GitService();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label2.Visible = true;
            label2.Text = gs.InitRepository(textBox1.Text);
        }

        public void button4_Click(object sender, EventArgs e)
        {
          //  textBox2.ScrollBars = ScrollBars.Both;
           // textBox2.WordWrap = false;

            var commits = gs.GetCommits(textBox1.Text);
            richTextBox1.SelectionBullet = true;
            richTextBox1.Text = string.Join("\n", commits);
            label3.Visible = true;
            label3.Text = "Commit Count: " + commits.Count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tags = gs.GetTags(textBox1.Text);
            richTextBox1.SelectionBullet = true;
            richTextBox1.Text = string.Join("\n", tags);
            label3.Visible = true;
            label3.Text = "Tag Count: " + tags.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var branches = gs.GetBranches(textBox1.Text);
            richTextBox1.SelectionBullet = true;
            richTextBox1.Text = string.Join("\n", branches);
            label3.Visible = true;
            label3.Text = "Branch Count: " + branches.Count;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
