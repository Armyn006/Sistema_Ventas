using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using FontAwesome.Sharp;

using CapaNegocio;
using CapaPresentación.Modales;

namespace CapaPresentación
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Inicio(Usuario objusuario = null)
        {
            if (objusuario == null)
                usuarioActual = new Usuario() {NombreCompleto = "ADMINISTRADOR DEFAULT", IdUsuario = 1 };

            else 
            usuarioActual = objusuario;

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permisos> LisataPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

           foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = LisataPermisos.Any(m => m.NombreMenu == iconmenu.Name);

                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }
            }
         

            lblusuario.Text = usuarioActual.NombreCompleto;
        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AbbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.LightGray;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.PaleGoldenrod;

            contenedor.Controls.Add(formulario);
            formulario.Show();

        }

        private void menusuarios_Click(object sender, EventArgs e)
        {
            AbbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            AbbrirFormulario((IconMenuItem)menumantenedor, new frm_categoria());
        }

        private void submenuproducto_Click(object sender, EventArgs e)
        {
            AbbrirFormulario((IconMenuItem)menumantenedor, new frm_producto());
        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbbrirFormulario(menuventas, new frm_ventas(usuarioActual));
        }

        private void submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            AbbrirFormulario(menuventas, new frm_detalleventa());
        }

        private void submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            AbbrirFormulario(menucompras, new frm_detallecompra());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbbrirFormulario(menucompras, new frm_compras(usuarioActual));
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbbrirFormulario((IconMenuItem)sender, new frm_clientes());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbbrirFormulario((IconMenuItem)sender, new frm_proveedores());
        }



        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuTitulo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbbrirFormulario((IconMenuItem)menumantenedor, new frm_Negocio());
        }

        private void lblusuario_Click(object sender, EventArgs e)
        {

        }

        private void submenureportecompras_Click(object sender, EventArgs e)
        {
            AbbrirFormulario((IconMenuItem)menureportes, new frmReporteCompras());

        }

        private void submenureporteventas_Click(object sender, EventArgs e)
        {
            AbbrirFormulario((IconMenuItem)menureportes, new frmReporteVentas());

        }

        private void menuacercade_Click(object sender, EventArgs e)
        {
            AbbrirFormulario((IconMenuItem)menuacercade, new mdAcercade());

            // mdAcercade md = new mdAcercade();
            //  md.ShowDialog();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea salir?","Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
                this.Close();
            }
        }
    }
}
