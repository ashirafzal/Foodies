using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodies
{
    public partial class DeletedInvoice : Form
    {
        public DeletedInvoice()
        {
            InitializeComponent();
        }

        private void DeletedInvoice_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'invoiceDataSet.Bill' table. You can move, or remove it, as needed.
            this.billTableAdapter.Fill(this.invoiceDataSet.Bill);

        }
    }
}
