using System;
using System.Windows.Forms;

namespace PennyWise
{
    public partial class EditDetails : Form
    {
        private TransactionDetails transaction; 

        public EditDetails(TransactionDetails transaction)
        {
            CustomizeTitleBar();
            InitializeComponent();
            this.transaction = transaction;

            descriptionTextBox.Text = transaction.Description;
            amountTextBox.Text = transaction.Amount.ToString();

            transactionDateTimePicker.Value = transaction.Date;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FullscreenButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        public TransactionDetails GetEditedTransaction()
        {
            TransactionDetails editedTransaction = new TransactionDetails(
                descriptionTextBox.Text,
                decimal.Parse(amountTextBox.Text),
                transactionDateTimePicker.Value,
                transaction.CategoryName,
                transaction.TransactionID);

            return editedTransaction;
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            transaction.Description = descriptionTextBox.Text;
            transaction.Amount = decimal.Parse(amountTextBox.Text);
            transaction.Date = transactionDateTimePicker.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void EditDetails_Load(object sender, EventArgs e)
        {

        }
    }
}