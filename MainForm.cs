using System.Windows.Forms;
using CTranslator.Analysis;
using CTranslator.Analysis.Errors;

namespace CTranslator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mOpen_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                edtCode.LoadFile(dlgOpen.FileName);
                lstErrors.Items.Clear();
            }
        }

        private void mSave_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                edtCode.SaveFile(dlgSave.FileName);
            }
        }

        private void mPerform_Click(object sender, EventArgs e)
        {
            lstErrors.Items.Clear();
            try
            {
                Scanner.Analyze(edtCode.Text);
                Parser.Analyze();
                lstErrors.Items.Add("Программа соответствует грамматике");
                TablesForm tf = new TablesForm();
                tf.ShowDialog();
            }
            catch (Error error)
            {
                lstErrors.Items.Add(error.Message);
            }
        }

        private void mTables_Click(object sender, EventArgs e)
        {
            TablesForm tf = new TablesForm();
            tf.ShowDialog();
        }
    }
}