using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentación
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {


            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtid.Text && u.Clave == txtclave.Text && u.Estado == true).FirstOrDefault();           

            if(ousuario != null)
            {
                Inicio form = new Inicio(ousuario);

                form.Show();
                this.Hide();
                form.FormClosing += frm_closing; //Cierra en conjunto el formulario de login y el de inicio
            }
            else
            {
                MessageBox.Show("No se encontró el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtid.Text = ""; //Limpia los cuadros de texto que contienen el ID y la clave de algú usuario
                txtclave.Text = "";

            }


        }

        private void frm_closing(object sender, FormClosingEventArgs e) //muestra el formulario de login despues de cerrar el formulario de inicio
        {
            txtid.Text = ""; //Limpia los cuadros de texto que contienen el ID y la clave de algú usuario
            txtclave.Text = "";

            this.Show();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
