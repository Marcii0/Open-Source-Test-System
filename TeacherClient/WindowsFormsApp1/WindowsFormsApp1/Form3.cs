using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
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
        public Form3(string _teachername, string _teacherid)
        {
            InitializeComponent();
            teachername = _teachername;
            teacherid = _teacherid;
        }
        string getTestsURL = "http://localhost:80/GETTESTS.php";
        readonly HttpClient client = new HttpClient();
        private async void Form3_Load(object sender, EventArgs e)
        {
            var values = new Dictionary<string, string>
            {
                {"teachername", teachername },
                {"teacherid", teacherid }
            };
            var data = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(getTestsURL, data);
            var resstring = response.Content.ReadAsStringAsync().Result;
            resstring = resstring.Replace("{", "").Replace("{","");
            string[] l = resstring.Split(',');
            List<string> k = new List<string>();
            List<string> v = new List<string>();
            foreach (var item in l)
            {
                k.Add(item.Split(':')[0]);
                v.Add(item.Split(':')[1]);
            }


            foreach (string item in k.ToArray())
            {
                Console.WriteLine(item);
            }
            foreach (string item in v.ToArray())
            {
                Console.WriteLine(item);
            }
            MessageBox.Show(resstring.Replace("\\n", "\n"));
            
        }
    }
}
