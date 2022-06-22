using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Net;
using JSONREQS;
using System.IO;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Net.Http;


namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        string teachername = "";
        string teacherid = "";
        string teacherpassword = "";
        public Form3(string _teachername, string _teacherid, string _teacherpassword)
        {
            InitializeComponent();
            teachername = _teachername;
            teacherid = _teacherid;
            teacherpassword = _teacherpassword;
        }
        string getTestsURL = "http://localhost:80/GETTESTS.php";
        readonly HttpClient client = new HttpClient();
        private async void Form3_Load(object sender, EventArgs e)
        {
            Console.WriteLine(teacherpassword);
            var values = new Dictionary<string, string>
            {
                {"teachername", teachername },
                {"teacherid", teacherid }
            };
            var data = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(getTestsURL, data);
            var resstring = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(resstring);
            
            JObject json = JObject.Parse(resstring);
            UserControl1 userControl = new UserControl1();
            foreach (var ea in json)
            {
                if (ea.Key == "testname")
                    userControl.Name = ea.Value.ToString();
                if (ea.Key == "testid")
                    userControl.Testid = ea.Value.ToString();
                if (ea.Key == "teacherid")
                    userControl.TeacherPassword = teacherpassword;
                if (ea.Key == "numberoftasks")
                    userControl.NumberofTasks = ea.Value.ToString();
                    flowLayoutPanel1.Controls.Add(userControl);
            }
            
            
            
            
        }
    }
}
