using Textumbruch.Interactors;

namespace Textumbruch.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void UmbrechenButton_Click(object sender, EventArgs e)
        {
            var ergebnis = TextInteractor.UmbrechenAufMaximaleBreiteVonZeichen(
                VorherTextbox.Text, 
                (int)BreiteInZeichenNumericUpDown.Value
            );
            NachherTextbox.Text = ergebnis;
        }
    }
}