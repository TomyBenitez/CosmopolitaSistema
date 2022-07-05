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
    public partial class FrmListadoDeActividades : Form
    {
        public FrmListadoDeActividades()
        {
            InitializeComponent();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            //instanciamos el objeto dbContext
            var db = new CosmopolitaContext();

            //traemos la lista de actividades
            var listaActividades = db.Actividades.ToList();

            //la asignamos a la grilla
            grdActividades.DataSource = listaActividades;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frmNuevoEditarActividad = new FrmNuevoEditarActividad();
            frmNuevoEditarActividad.ShowDialog();
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
            var listaActividades = db.Actividades.Where(a=>a.Nombre.Contains(cadenaDeBusqueda)).ToList();

            //la asignamos a la grilla
            grdActividades.DataSource = listaActividades;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //obtenemos el id de la fila seleccionada
            var idActividad =(int)grdActividades.CurrentRow.Cells[0].Value;
            var frmNuevoEditarActividad = new FrmNuevoEditarActividad(idActividad);
            frmNuevoEditarActividad.ShowDialog();
            ActualizarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //obtenemos el id y nombre de la actividad seleccionada
            var idActividad = (int)grdActividades.CurrentRow.Cells[0].Value;
            var nombreActividad = (string)grdActividades.CurrentRow.Cells[1].Value;

            //preguntamos al usuario si está seguro que quiere borrar
            DialogResult respuesta = MessageBox.Show($"¿Deseas eliminar la actividad {nombreActividad}?","Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           
            //si contestó que si, borramos la actividad
            if(respuesta == DialogResult.Yes)
            {
                var db = new CosmopolitaContext();

                //obtenemos la actividad a borrar
                var actividadBorrar = db.Actividades.Find(idActividad);

                //borramos la actividad
                db.Actividades.Remove(actividadBorrar);

                //guardamos los cambios
                db.SaveChanges();

                //actualizamos grilla
                ActualizarGrilla();
            }
        }
    }
}
