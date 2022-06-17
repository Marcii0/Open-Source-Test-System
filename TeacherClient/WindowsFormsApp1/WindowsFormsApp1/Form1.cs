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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, string> credentials = new Dictionary<string, string>();

        string loginURL = "http://localhost:80/LOGIN.php";
        readonly HttpClient client = new HttpClient();

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Username";
            textBox2.Text = "Password";
            textBox1.GotFocus += TextBox1_GotFocus;
            textBox1.LostFocus += TextBox1_LostFocus;
            textBox2.GotFocus += TextBox2_GotFocus;
            textBox2.LostFocus += TextBox2_LostFocus;
        }

        async void login()
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                var values = new Dictionary<string, string>
            {
            { "username", textBox1.Text },
            { "password", textBox2.Text }
            };
                var data = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(loginURL, data);
                var resstring = response.Content.ReadAsStringAsync().Result;
                if (!resstring.Contains("\n"))
                {
                    MessageBox.Show(resstring);
                    return;
                }
                credentials.Add("username", Regex.Split(resstring, "\n")[0]);
                credentials.Add("password", Regex.Split(resstring, "\n")[1]);
                credentials.Add("teacherid", Regex.Split(resstring, "\n")[2]);
                MessageBox.Show("Teacher NAME | "+credentials["username"]+"\n Teacher PASSWORD | "+credentials["password"]+"\n Teacher ID | "+credentials["teacherid"]);
                finalizeLogin();
            }
            else
                MessageBox.Show("You need to enter something for your Username and Password!");
        }


        void finalizeLogin()
        {
            Form3 _finalizeLogin = new Form3(credentials["username"], credentials["teacherid"]);
            _finalizeLogin.Show();
        }

        #region getfocuslostfocus
        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim(' ') == "")
                textBox1.Text = "Username";
        }

        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
                textBox1.Text = "";
        }
        private void TextBox2_LostFocus(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim(' ') == "")
                textBox2.Text = "Password";
        }

        private void TextBox2_GotFocus(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
                textBox2.Text = "";
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            login();
            button1.Enabled = false;
        }
    }
}
