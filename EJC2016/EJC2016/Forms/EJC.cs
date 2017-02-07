using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EJC2016.Forms;
using EJC2016.Utils;
using EJC2016.Bll;

namespace EJC2016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MergePDFs me = new MergePDFs();
            me.AddFile("Roda.pdf");
            me.AddFile("Pos.pdf");
            me.SourceFolder = "C:\\Users\\fernando\\Desktop\\Docs\\";
            me.DestinationFile = "Quadrante";
            me.Execute();

            //EncontristasReport rpt = new EncontristasReport();
            //var Equipe = new Equipe();
            //var lstIds = Equipe.GetIdEquipes();

            //foreach (var equipeId in lstIds)
            //{
            //    AudioReport audioReport = new AudioReport(equipeId);
            //    audioReport.Show();
            //}

            //EncontristasFullReport rpt1 = new EncontristasFullReport();
            //rpt1.Show();
        }
    }
}
