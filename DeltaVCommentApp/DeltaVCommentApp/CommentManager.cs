using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeltaVCommentApp
{
    public partial class CommentManager : Form
    {
        public CommentManager()
        {
            InitializeComponent();
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            var sq = new SqlQueries();
            sq.InsertComment(headerTxtBox.Text, sectionTxtBox.Text);
            
            string id = sq.ReturnLastID().ToString();
            int idnum = sq.ReturnLastID();
            
            MessageBox.Show("Added comment with id: {0}", );

            Console.WriteLine(id, idnum);
        }
    }
}
