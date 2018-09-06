using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;



namespace xml2pdf_win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            String katalog;
            String sciezka;



            // katalog = "D:\\XML\\pharma-art\\";

            katalog = "d:\\xml";

            //string[] filePaths = Directory.GetFiles(@katalog);

            string[] filePaths = Directory.GetFiles(folderBrowserDialog1.SelectedPath);

            int licznik = 0;

            //  String element = filePaths[1];

            foreach (String element in filePaths)

            {
                licznik++;



                sciezka = "file://" + element;


                label1.Text = "Plik przetwarzany " + licznik.ToString() + " : " + element;


                webBrowser.Navigate(new Uri(sciezka));



                //webBrowser.Print();


                while (webBrowser.IsBusy)
                    System.Windows.Forms.Application.DoEvents();
                for (int i = 0; i < 5000; i++)
                    if (webBrowser.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
                    {
                        System.Windows.Forms.Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                    }
                    else
                        break;


                System.Threading.Thread.Sleep(1000);

                //MessageBox.Show("test: ", element );

                //Thread.Sleep(6000);


                webBrowser.Print();


                while (webBrowser.IsBusy)
                    System.Windows.Forms.Application.DoEvents();
                for (int i = 0; i < 5000; i++)
                    if (webBrowser.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
                    {
                        System.Windows.Forms.Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                    }
                    else
                        break;


                System.Threading.Thread.Sleep(1000);


            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1.ShowDialog();
            labFolder.Text = "Folder z XML:  " + folderBrowserDialog1.SelectedPath.ToString();


        }
    }
    
   



}
