using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ege_Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string saat = "abc";


        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         saat = DateTime.Now.ToLongTimeString();
         this.Text = "Ege Browser  " + saat +"  "+ webBrowser1.DocumentTitle;
         toolStripStatusLabel1.Text = webBrowser1.StatusText;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com/search?q="+textBox1.Text);
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            webBrowser1.Navigate("file://"+openFileDialog1.FileName);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox2.Text = webBrowser1.Url.ToString();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void ileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_DoubleClick(object sender, EventArgs e)
        {
            if (menuStrip1.Visible == true)
            {
                menuStrip1.Visible = false;
            }
            else
            {
                menuStrip1.Visible = true;
            }
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                toolStripProgressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
                toolStripProgressBar1.Value = Convert.ToInt32(e.CurrentProgress);
            }
            catch (Exception)
            { 
                toolStripProgressBar1.Maximum = 0;
            }
        }

        private void geçmişToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gecmisiyukle();
        }
        private void gecmisiyukle()
        {
            listBox1.Items.Clear();
            StreamReader dosya = new StreamReader("Gecmis.txt");
            while (!dosya.EndOfStream)
            {
                listBox1.Items.Add(dosya.ReadLine());
            }
            dosya.Close();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string gcmst = DateTime.Now.Hour + ":" +DateTime.Now.Minute;

            FileStream f = new FileStream("Gecmis.txt", FileMode.Append);
            StreamWriter yaz = new StreamWriter(f);
            yaz.WriteLine(gcmst + " " + webBrowser1.Url);
            yaz.Close();
            gecmisiyukle();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StreamWriter dosya = new StreamWriter("Gecmis.txt");
            dosya.Write(" ");
            dosya.Close();
            gecmisiyukle();
        }
    }
}
