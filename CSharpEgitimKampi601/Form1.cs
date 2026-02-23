using CSharpEgitimKampi601.Entities;
using CSharpEgitimKampi601.Services;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CustomerOperations customerOperations = new CustomerOperations();
        private void btnCustomerCreate_Click(object sender, System.EventArgs e)
        {
            var customer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerCity = txtCustomerCity.Text,
                CustomerShoppingCount = int.Parse(txtCustomerShoppingCount.Text),
            };
            customerOperations.AddCustomer(customer);
            MessageBox.Show("Musteri Ekleme Islemi basarili", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
