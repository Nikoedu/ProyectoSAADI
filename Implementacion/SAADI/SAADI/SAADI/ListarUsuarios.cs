using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAADI
{
    public partial class ListarUsuarios : Form
    {
        public ListarUsuarios()
        {
            InitializeComponent();
            Profesor profe = new Profesor();
            profe.listarUsuarios(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
