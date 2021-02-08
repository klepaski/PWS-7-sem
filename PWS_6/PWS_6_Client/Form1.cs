using PWS_6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWS_6_Client
{
    public partial class Form1 : Form
    {
        WSCJAModel.WSCJAEntities2 wSCJAEntities;
        public Form1()
        {
            wSCJAEntities = new WSCJAModel.WSCJAEntities2(new Uri("https://localhost:44357/WcfDataService1.svc/"));

            InitializeComponent();
        }

        private void getStudents_Click(object sender, EventArgs e)
        {
            result.Text = "";
            foreach (var student in wSCJAEntities.Student.AsEnumerable())
            {
                result.Text += string.Format("Id {0}: {1}\n", student.Id, student.Name);
            }
        }

        private void getNotes_Click(object sender, EventArgs e)
        {
            var notes = wSCJAEntities.Note.Where(n => n.Note1 >= 4).ToList();

            result.Text = "";
            foreach (var note in notes)
            {
                result.Text += string.Format("Id {0}: Note '{1}' on exam '{2}' (Student ID: {3})\n", note.Id, note.Note1, note.Subj, note.StudentId);
            }
        }
    }
}
