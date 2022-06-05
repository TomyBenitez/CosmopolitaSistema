namespace FrmCosmopolita
{
    public partial class FrmCosmopolita : Form
    {
        public FrmCosmopolita()
        {
            InitializeComponent();
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
    }
}