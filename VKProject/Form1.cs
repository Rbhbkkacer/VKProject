using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace VKProject
{
    public partial class Form1 : Form
    {
        private string starturl = "http://ru.aliexpress.com/";
        private WebRequest reqest;
        private StreamReader streamread;
        private List<string> kategories = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            kategories.Clear();
            reqest = WebRequest.Create(starturl);
            streamread = new StreamReader(reqest.GetResponse().GetResponseStream());
            string s = streamread.ReadToEnd();
            int i = 0;
            while (true)
            {
                try
                {
                    string s1 = s.Remove(0, s.IndexOf("<dl data-role=\"first-menu\"", i));
                    s1 = s1.Remove(s1.IndexOf("<ul class=\"clearfix bottom-show-list\">"));
                    kategories.Add(s1);
                    i = s.IndexOf("<ul class=\"clearfix bottom-show-list\">", i + 1);
                }
                catch
                {
                    break;
                }
            }
            i = 0;
            string ss = kategories[new Random().Next(kategories.Count)];
            kategories.Clear();
            while (true)
            {
                try
                {
                    string s1 = ss.Remove(0, ss.IndexOf("<dt><a href=", i));
                    s1 = s1.Remove(s1.IndexOf("</dd>"));
                    kategories.Add(s1);
                    i = ss.IndexOf("</dd>", i + 1);
                }
                catch
                {
                    break;
                }
            }
            string sss = kategories[new Random().Next(kategories.Count)];
            sss = sss.Remove(0, sss.IndexOf("<dd>"));
            kategories.Clear();
            i = 0;
            while (true)
            {
                try
                {
                    string s1 = sss.Remove(0, sss.IndexOf("<a href=", i));
                    s1 = s1.Remove(s1.IndexOf("</a>"));
                    kategories.Add(s1);
                    i = sss.IndexOf("</a>", i + 1);
                }
                catch
                {
                    break;
                }
            }
            sss = kategories[new Random().Next(kategories.Count)];
            sss = sss.Remove(0, sss.IndexOf("http"));
            sss = sss.Remove(sss.IndexOf("\">"));
            reqest = WebRequest.Create(sss);
            streamread = new StreamReader(reqest.GetResponse().GetResponseStream());
            s = streamread.ReadToEnd();
            i = 0;
            kategories.Clear();
            ss = s.Remove(0, s.IndexOf("<span class=\"ui-pagination-active\""));
            ss = ss.Remove(ss.IndexOf("</div>"));
            while (true)
            {
                try
                {
                    string s1 = ss.Remove(0, ss.IndexOf("<a href=", i));
                    s1 = s1.Remove(s1.IndexOf("</a>"));
                    kategories.Add(s1);
                    i = ss.IndexOf("</a>", i + 1);
                }
                catch
                {
                    break;
                }
            }
            sss = sss.Insert(sss.IndexOf("html"), "/" + (new Random().Next(kategories.Count) + 1).ToString());
            reqest = WebRequest.Create(sss);
            streamread = new StreamReader(reqest.GetResponse().GetResponseStream());
            s = streamread.ReadToEnd();
            bool variant;
            try
            {
                s = s.Remove(0, s.IndexOf("<li qrdata="));
                variant = true;
            }
            catch
            {
                s = s.Remove(0, s.LastIndexOf("<ul id="));
                variant = false;
            }
            i = 0;
            kategories.Clear();
            while (true)
            {
                try
                {
                    string s1;
                    if (variant)
                    {
                        s1 = s.Remove(0, s.IndexOf("class=\"picRind \" href=\"", i));
                    }
                    else
                    {
                        s1 = s.Remove(0, s.IndexOf("<div class=\"img-container left-block util-clearfix\">", i));
                    }
                    s1 = s1.Remove(s1.IndexOf("</a>"));
                    kategories.Add(s1);
                    i = s.IndexOf("</a>", i + 1);
                }
                catch
                {
                    break;
                }
            }
            sss = kategories[new Random().Next(kategories.Count)];
            sss = sss.Remove(0, sss.IndexOf("ru"));
            sss = sss.Remove(sss.IndexOf("\" ><"));
            sss = sss.Insert(0, "http://");
            reqest = WebRequest.Create(sss);
            streamread = new StreamReader(reqest.GetResponse().GetResponseStream());
            s = streamread.ReadToEnd();
            reqest = WebRequest.Create("http://qps.ru/api?url=" + sss);
            streamread = new StreamReader(reqest.GetResponse().GetResponseStream());
            richTextBox1.Text += streamread.ReadToEnd() + "\n";
            i = 0;
            string name = s.Remove(0, s.IndexOf("<title>") + 7);
            name = name.Remove(name.IndexOf("</title>"));
            richTextBox1.Text += name + "\n";
            kategories.Clear();
            while (true)
            {
                try
                {
                    string s1 = s.Remove(0, s.IndexOf("<li><span class=", i));
                    s1 = s1.Remove(0, s1.IndexOf("http"));
                    s1 = s1.Remove(s1.IndexOf("_50x50.jpg\"/></span></li>"));
                    kategories.Add(s1);
                    i = s.IndexOf("_50x50.jpg\"/></span></li>", i + 1);
                }
                catch
                {
                    break;
                }
            }
            foreach (string item in kategories)
            {
                richTextBox1.Text += item + "\n";
            }
        }
    }
}