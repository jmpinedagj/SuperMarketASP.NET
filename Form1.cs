using ejercicioCrud.Dato;
using ejercicioCrud.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ejercicioCrud
{
    public partial class Form1 : Form
    {
        private DataTable table;
        ProductoAdmin admin = new ProductoAdmin();
        private void Inicializar()
        {
            table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("nombre_Producto");
            table.Columns.Add("descripcion_Producto");
            table.Columns.Add("unid_Medida");
            table.Columns.Add("peso");
            table.Columns.Add("precio");
            listaproductos.DataSource = table;
        }


        public Form1()
        {
            InitializeComponent();
           
            Consultar();
        }

        private void Consultar()
        {   
            Inicializar();
           List<productos> lista = admin.Consultar();
            foreach (var item in lista)

            { 
                DataRow row = table.NewRow();
                row["Id"] = item.Id;
                row["nombre_Producto"] = item.nombre_Producto;
                row["descripcion_Producto"] = item.descripcion_Producto;
                row["unid_Medida"] = item.unid_Medida;
                row["peso"] = item.peso;
                row["precio"] = item.precio;
                table.Rows.Add(row);


            }
            
        }
        
        private void Guardar ()
        {
            productos modelo = new productos()
            {
                 Id = int.Parse(textBox1.Text),
                 nombre_Producto = textBox2.Text,
                 descripcion_Producto = textBox4.Text,
                 unid_Medida = textBox3.Text,
                 peso =int.Parse(textBox6.Text),
                 precio = int.Parse(textBox5.Text)

            };
            admin.Guardar(modelo);
        }


        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
        }



        private void EliminarProducto()
        {
          
      
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
            Consultar();
            Limpiar();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           
        }

        private void listaproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (listaproductos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = listaproductos.SelectedRows[0];

                DialogResult confirmacion = MessageBox.Show("¿Seguro que deseas eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    listaproductos.Rows.Remove(filaSeleccionada);
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila antes de eliminar");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listaproductos.Rows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = listaproductos.Rows[0];

                filaSeleccionada.Cells[0].Value = textBox1.Text;
                filaSeleccionada.Cells[1].Value = textBox2.Text;
                filaSeleccionada.Cells[2].Value = textBox4.Text;
                filaSeleccionada.Cells[3].Value = textBox3.Text;
                filaSeleccionada.Cells[4].Value = textBox6.Text;
                filaSeleccionada.Cells[5].Value = textBox5.Text;
                listaproductos.Refresh();
            }
        }


        private void traerForm(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.RowIndex >= 0 && e.RowIndex < listaproductos.Rows.Count)
                {
                    DataGridViewRow filaSeleccionada = listaproductos.Rows[e.RowIndex];
                    textBox1.Text = filaSeleccionada.Cells[0].Value?.ToString();
                    textBox2.Text = filaSeleccionada.Cells[1].Value?.ToString();
                    textBox4.Text = filaSeleccionada.Cells[2].Value?.ToString();
                    textBox3.Text = filaSeleccionada.Cells[3].Value?.ToString();
                    textBox6.Text = filaSeleccionada.Cells[4].Value?.ToString();
                    textBox5.Text = filaSeleccionada.Cells[5].Value?.ToString();

         
                }
            }

        private void listaproductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void listaproductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string terminoBusqueda = txtBuscar.Text.ToLower();

            if (!string.IsNullOrWhiteSpace(terminoBusqueda))
            {
               
                listaproductos.ClearSelection();

                foreach (DataGridViewRow fila in listaproductos.Rows)
                {
                    bool encontrado = false;

                    for (int i = 0; i < fila.Cells.Count; i++)
                    {
                        if (fila.Cells[i].Value != null && fila.Cells[i].Value.ToString().ToLower().Contains(terminoBusqueda))
                        {
                            encontrado = true;
                            break;
                        }
                    }

                    if (encontrado)
                    {
                        fila.Selected = true;
                  
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese un término de búsqueda válido.", "Búsqueda Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
