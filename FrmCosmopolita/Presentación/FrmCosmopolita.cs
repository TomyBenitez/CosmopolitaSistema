namespace FrmCosmopolita
{
    public partial class FrmCosmopolita : Form
    {
        public FrmCosmopolita()
        {
            InitializeComponent();
            CbModoOscuroClaro.SelectedIndex = 0;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var texto = "Hecho por: Tomás Benitez";
            texto += Environment.NewLine;
            texto += "Materia: Programación 1";
            texto += Environment.NewLine;
            texto += "Carrera: TSD Software";
            var titulo = "Acerca de...";
            MessageBox.Show(texto, titulo);
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaDeCosmopolitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcercaDe frmacercade = new FrmAcercaDe();
            frmacercade.ShowDialog();
        }

        private void mostrarEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnPrincipal.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            BtnAcercaDe.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            BtnOpciones.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            BtnSalir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
        }

        private void ocultarEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnPrincipal.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnAcercaDe.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnOpciones.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnSalir.DisplayStyle = ToolStripItemDisplayStyle.Image;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            salirToolStripMenuItem1_Click(sender, e);
        }

        private void BtnAcercaDe_Click(object sender, EventArgs e)
        {
            acercaDeCosmopolitaToolStripMenuItem_Click(sender, e);
        }

        private void CbModoOscuroClaro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Modo Claro
            if (CbModoOscuroClaro.SelectedIndex == 0)
            {
                this.BackColor = Color.White;
                TextoEstado.Text = "Modo Claro";
                TextoEstado.ForeColor = Color.Black;
                StsBarraDeEstado.BackColor = Color.White;
                MenuHerramientas.BackColor = Color.White;
                menuStrip1.BackColor = Color.White;
                CbModoOscuroClaro.BackColor = Color.White;
                CbModoOscuroClaro.ForeColor = Color.Black;
                BtnPrincipal.BackColor = Color.White;
                BtnOpciones.BackColor = Color.White;
                BtnAcercaDe.BackColor = Color.White;
                BtnSalir.BackColor = Color.White;
                BtnOpciones.BackColor = Color.White;
                principalToolStripMenuItem.BackColor = Color.White;
                utilidadesToolStripMenuItem.BackColor = Color.White;
                salirToolStripMenuItem.BackColor = Color.White;
            }
            else
            { //Modo Oscuro
                this.BackColor = Color.FromArgb(255, 18, 18, 18);
                TextoEstado.Text = "Modo Oscuro";
                TextoEstado.ForeColor = Color.White;
                StsBarraDeEstado.BackColor = Color.FromArgb(255, 41, 41, 41);
                MenuHerramientas.BackColor = Color.FromArgb(255, 41, 41, 41);
                menuStrip1.BackColor = Color.FromArgb(255, 41, 41, 41);
                CbModoOscuroClaro.BackColor = Color.FromArgb(255, 41, 41, 41);
                CbModoOscuroClaro.ForeColor = Color.White;
                BtnPrincipal.BackColor = Color.FromArgb(255, 41, 41, 41);
                BtnAcercaDe.BackColor = Color.FromArgb(255, 41, 41, 41);
                BtnSalir.BackColor = Color.FromArgb(255, 41, 41, 41);
                BtnOpciones.BackColor = Color.FromArgb(255, 41, 41, 41);
                principalToolStripMenuItem.BackColor = Color.FromArgb(255, 41, 41, 41);
                utilidadesToolStripMenuItem.BackColor = Color.FromArgb(255, 41, 41, 41);
                salirToolStripMenuItem.BackColor = Color.FromArgb(255, 41, 41, 41);
            }
        }
    }
}