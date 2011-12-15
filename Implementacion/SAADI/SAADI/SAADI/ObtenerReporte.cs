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
        String nombreAlumno = "";
        DateTime fechaactual; 
        private void button1_Click(object sender, EventArgs e)
        {
            Profesor profe = new Profesor();
            profe.obtenerReporteActividadesRealizadas(textBox1.Text, dataGridView1);
            nombreAlumno = textBox1.Text;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = "Actividades Realizadas Por " + nombreAlumno;
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void MyPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            fechaactual = DateTime.Now;
            String fecha = fechaactual.ToString("dd-MM-yyyy HH:mm");

            int x = 0;
            int y = 100;
            int filaGap = 20;
            int colGap = 5;
            int MargenIzq = 50;
 
            int LineasPorPargina = e.MarginBounds.Height / dataGridView1.DefaultCellStyle.Font.Height;
            Font headingFont = new Font("Arial", 10, FontStyle.Bold);
            Font captionFont = new Font("Arial", 10, FontStyle.Bold);
            Brush Sbrush = new SolidBrush(Color.Black);
            string cellValue = "";
            e.Graphics.DrawString("Fecha y Hora Actual: " +fecha, headingFont, Sbrush, x+50, y);
            y += filaGap;
            x = MargenIzq;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if(column.GetType() != typeof(DataGridViewButtonColumn) && column.GetType() != typeof(DataGridViewCheckBoxColumn))
                {
                    cellValue = column.HeaderText;
                    e.Graphics.DrawString(cellValue, headingFont, Sbrush, x, y);
                    x += column.Width + colGap;
                }
            }
            int PosicionFila = 0;
            int count = 0;
            for (int i = PosicionFila; i < dataGridView1.Rows.Count - 1; i++)
            {
                y += filaGap;
                x = MargenIzq;

                foreach (DataGridViewColumn columna in dataGridView1.Columns)
                {
                    if (columna.GetType() != typeof(DataGridViewButtonColumn) && columna.GetType() != typeof(DataGridViewCheckBoxColumn))
                    {
                        cellValue = dataGridView1.Rows[i].Cells[columna.Index].Value.ToString();
                        e.Graphics.DrawString(cellValue, captionFont, Sbrush, x, y);
                        x += columna.Width + colGap;
                        y = y + filaGap * (cellValue.Split(new char[] { '\r', '\n' }).Length - 1);
                    }
                }

                PosicionFila++;
                count++;

                if (count > LineasPorPargina)
                {
                    break;
                }
            }
        
        }        
    }
}
