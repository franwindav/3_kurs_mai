using System;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class Lab12 : Form
    {
        public Lab12() { InitializeComponent(); }

        private int counter = 0;

        private void Button1_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string tag = tagBox.Text;
            if (name != "" && tag != "") Add(name, tag);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (counter < 1) return;
            --counter;
            listView1.Items[counter].Remove();
            treeView1.Nodes.RemoveAt(counter);
        }

        private void Add(string name, string tag)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string date = DateTime.Now.ToString("dd.MM.yyyy");

            string[] array = { (++counter).ToString(), name + " " + tag};
            listView1.Items.Add(new ListViewItem(array));

            TreeNode nodeName = new TreeNode("Name " + name);
            TreeNode nodeTag = new TreeNode("Last Name: " + tag);
            TreeNode nodeTime = new TreeNode("Time: " + time);
            TreeNode nodeDate = new TreeNode("Date: " + date);
            TreeNode[] children = { nodeName, nodeTag, nodeTime, nodeDate };

            TreeNode node = new TreeNode(counter+"", children);
            treeView1.Nodes.Add(node);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
