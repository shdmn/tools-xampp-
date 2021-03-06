﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace VhostsEditorGUI
{
    class Vhosts
    {
        private const string DefaultVhostsFile = @"C:\xampp\apache\conf\extra\httpd-vhosts.conf";
        private string VhostsFile;
        private static List<Vhost> vhosts = new List<Vhost>();
        private StreamReader reader;
        private StreamWriter writer;
        private static int count = 0;

        public Vhosts()
        {
            
        }

        public int Count()
        {
            return Vhosts.count;
        }
        public string GetVhostDRAt(int position)
        {
            return Vhosts.vhosts.ElementAt(position).DocRoot;
        }
        public string GetVhostSNAt(int position)
        {
            return Vhosts.vhosts.ElementAt(position).SrvName;
        }
        public Vhost GetVhostBySN(string SN)
        {
            return Vhosts.vhosts.Find(item => item.SrvName == SN);
        }

        public int GetPositionBySN(string SN)
        {
            for (int i = 0; i < Vhosts.count; i++)
            {
                if (Vhosts.vhosts.ElementAt(i).SrvName == SN.Trim())
                {
                    return i;
                }
            }
            return -1;
        }

        public void EditVhostByPosition(int Pos, string nSN, string nDR)
        {
           // this.DelVhostBySN(SN.Trim());
            Vhosts.vhosts.ElementAt(Pos).DocRoot = nDR;
            Vhosts.vhosts.ElementAt(Pos).SrvName = nSN; 
            //Vhosts.count--;
          //  this.AddVhost(nDR, nSN);
        }

        public void Clear()
        {
            Vhosts.vhosts.Clear();
            Vhosts.count = 0;
        }
        public void Init()
        {
            this.Clear();
            this.VhostsFile = DefaultVhostsFile;
            try
            {
                this.reader = new StreamReader(this.VhostsFile);
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("nqma fail");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("nemoga da otvorq faila");
            }
            using (this.reader)
            {
                string line = this.reader.ReadLine();

                while (line != null)
                {
                    int indexDocRoot = line.IndexOf("DocumentRoot");
                    
                    string DocRoot = "";
                    string SrvName= "";

                    if (indexDocRoot != -1)
                    {
                        Vhost vhost = new Vhost();
                        DocRoot = line.Replace("DocumentRoot", "");
                        vhost.DocRoot = DocRoot.Trim();
                       // Console.WriteLine(DocRoot);

                        line = this.reader.ReadLine();
                        int indexSrvName = line.IndexOf("ServerName");

                        if (indexSrvName != -1)
                        {
                            SrvName = line.Replace("ServerName", "");
                        //    Console.WriteLine(SrvName);
                            vhost.SrvName = SrvName.Trim();
                        }

                        Vhosts.vhosts.Add(vhost);
                        Vhosts.count++;
                    }

                    line = this.reader.ReadLine();
                }
            }
            this.reader.Close();
        }
        public void Show()
        {
            int numberOfVhosts = Vhosts.vhosts.Count();
            for(int i = 0; i < numberOfVhosts; i++)
            {
                System.Console.WriteLine("<VirtualHost *>");
                System.Console.Write("DocumentRoot ");
                System.Console.WriteLine(Vhosts.vhosts.ElementAt(i).DocRoot);
                System.Console.Write("ServerName ");
                System.Console.WriteLine(Vhosts.vhosts.ElementAt(i).SrvName);
                System.Console.WriteLine("</VirtualHost>"); 
            }
        }
        public void AddVhost(string DocRoot, string SrvName)
        {
            Symboliclink s = new Symboliclink(DocRoot);

            Vhost newVhost = new Vhost();
            newVhost.DocRoot = "\"" + s.fullPath + "\"".Trim();
            newVhost.SrvName =  SrvName.Trim();

            Vhosts.count++;
            Vhosts.vhosts.Add(newVhost);
        }

        public void DelVhostBySN(string SN)
        {
            
            if (this.GetVhostBySN(SN) != null)
            {
                
                Vhosts.vhosts.RemoveAll(item => item.SrvName == SN);
                Vhosts.count--;
              
            }
        }
        public void ToFile()
        {
            this.VhostsFile = DefaultVhostsFile;
            try
            {
                //this.writer = new StreamWriter("C:\\Users\\vlad_ko\\Desktop\\vhosts2.conf");
                this.writer = new StreamWriter(Vhosts.DefaultVhostsFile+".tmp");
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("cannot find the file");
            }
            catch (IOException)
            {
                MessageBox.Show("Dot Net Perls is the best.");
                Console.Error.WriteLine("cannot open the file");
            }

            using (this.writer)
            {
                this.writer.WriteLine("NameVirtualHost *");
                for (int i = 0; i < Vhosts.count; i++) 
                {
                    this.writer.WriteLine("<VirtualHost *>");
                    this.writer.WriteLine(" DocumentRoot "+this.GetVhostDRAt(i).Trim());
                    this.writer.WriteLine(" ServerName "+this.GetVhostSNAt(i).Trim());
                    this.writer.WriteLine("</VirtualHost>");
                }
            }
            File.Copy(Vhosts.DefaultVhostsFile + ".tmp", Vhosts.DefaultVhostsFile,true);
            HostFile hosts = new HostFile();
            hosts.ToFile();
        }
    }
}
