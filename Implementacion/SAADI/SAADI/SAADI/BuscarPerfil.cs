﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAADI
{
    public partial class BuscarPerfil : Form
    {
        public BuscarPerfil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profesor profe = new Profesor();
            profe.buscarPerfil(textBox1.Text, dataGridView1);
        }
    }
}
