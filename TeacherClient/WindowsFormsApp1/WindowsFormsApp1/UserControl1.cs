using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Net.Http;
namespace WindowsFormsApp1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        string testname;
        string testid;
        string numberoftasks;
        string teacherpassword;

        string deletetestURL = "http://localhost:80/DELETETEST.php";
        readonly HttpClient client = new HttpClient();

        public string Testname
        {
            get { return testname; }
            set { testname = value; label1.Text = testname; }
        }
        public string Testid
        {
            get { return testid; }
            set { testid = value; }
        }

        public string TeacherPassword
        {
            get { return teacherpassword; }
            set { teacherpassword = value; }
        }

        public string NumberofTasks
        {
            get { return numberoftasks; }
            set { numberoftasks = value; label2.Text = numberoftasks; }
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            var values = new Dictionary<string, string>
            {
            { "password", teacherpassword },
            { "testid", testid }
            };
            var data = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(deletetestURL, data);
            Console.WriteLine(teacherpassword);
            Console.WriteLine(testid);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}
