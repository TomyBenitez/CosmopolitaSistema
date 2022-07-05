using FrmCosmopolita.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmCosmopolita.Presentación
{
    public partial class FrmListadoDeCobradores : Form
    {
        public FrmListadoDeCobradores()
        {
            InitializeComponent();
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            //instanciamos el objeto dbContext
            var db = new CosmopolitaContext();

            //traemos la lista de actividades
            var listaCobradores = db.Cobradores.ToList();

            //la asignamos a la grilla
            grdCobradores.DataSource = listaCobradores;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frmNuevoEditarCobrador = new FrmNuevoEditarCobrador();
            frmNuevoEditarCobrador.ShowDialog();
            ActualizarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrilla(txtBusqueda.Text);
        }

        private void ActualizarGrilla(string cadenaDeBusqueda)
        {
            //instanciamos el objeto dbContext
            var db = new CosmopolitaContext();

            //traemos la lista de actividades
            var listaActividades = db.Cobradores.Where(a => a.Apellido_Nombre.Contains(cadenaDeBusqueda)).ToList();

            //la asignamos a la grilla
            grdCobradores.DataSource = listaActividades;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //obtenemos el id y nombre de la actividad seleccionada
            var idCobradores = (int)grdCobradores.CurrentRow.Cells[0].Value;
            var nombreCobradores = (string)grdCobradores.CurrentRow.Cells[1].Value;

            //preguntamos al usuario si está seguro que quiere borrar
            DialogResult respuesta = MessageBox.Show($"¿Deseas eliminar la actividad {nombreCobradores}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //si contestó que si, borramos la actividad
            if (respuesta == DialogResult.Yes)
            {
                var db = new CosmopolitaContext();

                //obtenemos la actividad a borrar
                var CobradorBorrar = db.Cobradores.Find(idCobradores);

                //borramos la actividad
                db.Cobradores.Remove(CobradorBorrar);

                //guardamos los cambios
                db.SaveChanges();

                //actualizamos grilla
                ActualizarGrilla();
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            //obtenemos el id de la fila seleccionada
            var idCobrador = (int)grdCobradores.CurrentRow.Cells[0].Value;
            var frmNuevoEditarCobrador = new FrmNuevoEditarCobrador(idCobrador);
            frmNuevoEditarCobrador.ShowDialog();
            ActualizarGrilla();
        }
    }
}
