using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace SAADI
{
    public partial class ObtenerReporte : Form
    {
        public ObtenerReporte()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profesor profe = new Profesor();
            profe.obtenerReporteActividadesRealizadas(textBox1.Text, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void MyPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            this.dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }        
    }
}
