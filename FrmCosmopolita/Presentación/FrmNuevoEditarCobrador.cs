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
    public partial class FrmNuevoEditarCobrador : Form
    {
        private Cobrador cobrador;

        public FrmNuevoEditarCobrador()
        {
            InitializeComponent();
        }

        public FrmNuevoEditarCobrador(int idCobrador)
        {
            InitializeComponent();
            CargarDatosCobrador(idCobrador);
        }

        private void CargarDatosCobrador(int idCobrador)
        {
            //instanciamos la clase dbContext
            var db = new CosmopolitaContext();

            //obtenemos la actividad con el método fint
            cobrador = db.Cobradores.Find(idCobrador);

            //cargamos los datos en la pantalla
            txtApellidoNombre.Text = cobrador.Apellido_Nombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //instanciamos la clse bdContext
            var db = new CosmopolitaContext();

            if (cobrador == null)
            {
                //creamos un objeto del tipo cobrador
                var cobrador = new Cobrador();
                //cargamos los datos de la pantalla en el objeto cobrador
                cobrador.Apellido_Nombre = txtApellidoNombre.Text;
                //agregamos el cobrador al dbcontext
                db.Cobradores.Add(cobrador);
            }
            else
            {
                cobrador.Apellido_Nombre = txtApellidoNombre.Text;
                //definimos que estamos modificando
                db.Entry(cobrador).State = EntityState.Modified;

            }
            //Guardamos los cambios
            db.SaveChanges();

            //cerramos el formulario
            this.Close();
        }
    }
}
