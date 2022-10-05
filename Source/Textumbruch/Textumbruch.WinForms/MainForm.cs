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
            var interactor = new TextInteractor(VorherTextbox.Text);
            var ergebnis = interactor.UmbrechenAufMaximaleBreiteVonZeichen(
                (int)BreiteInZeichenNumericUpDown.Value
            );
            NachherTextbox.Text = ergebnis;
        }
    }
}