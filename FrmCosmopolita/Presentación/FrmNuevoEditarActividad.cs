using FrmCosmopolita.Data;
using FrmCosmopolita.Modelos;
using Microsoft.EntityFrameworkCore;
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
    public partial class FrmNuevoEditarActividad : Form
    {
        Actividad actividad;
        public FrmNuevoEditarActividad()
        {
            InitializeComponent();
        }

        public FrmNuevoEditarActividad(int idActividad)
        {
            InitializeComponent();
            CargarDatosActividad(idActividad);
        }

        private void CargarDatosActividad(int idActividad)
        {
            //instanciamos la clase dbContext
            var db = new CosmopolitaContext();

            //obtenemos la actividad con el método fint
            actividad = db.Actividades.Find(idActividad);

            //cargamos los datos en la pantalla
            txtNombre.Text = actividad.Nombre;
            txtHorarios.Text = actividad.Horarios;
            nudCosto.Value = actividad.Costo;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //instanciamos el dbcontext
            var db = new CosmopolitaContext();

            if (actividad == null)
            {
                //creamos un objeto del tipo cobrador
                var actividad = new Actividad();
                //cargamos los datos de la pantalla en el objeto cobrador
                actividad.Nombre = txtNombre.Text;
                actividad.Horarios = txtHorarios.Text;
                actividad.Costo = nudCosto.Value;
                //agregamos el cobrador al dbcontext
                db.Actividades.Add(actividad);
            }
            else
            {
                actividad.Nombre = txtNombre.Text;
                actividad.Horarios = txtHorarios.Text;
                actividad.Costo = nudCosto.Value;
                //definimos que estamos modificando
                db.Entry(actividad).State = EntityState.Modified;

            }
            //guardamos los cambios
            db.SaveChanges();
            //cerramos el formulario
            this.Close();
        }
    }
}
