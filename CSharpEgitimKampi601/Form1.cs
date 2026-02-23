using CSharpEgitimKampi601.Entities;
using CSharpEgitimKampi601.Services;
using System.Collections.Generic;
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

        private void btnCustomerList_Click(object sender, System.EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomer();
            dataGridView1.DataSource = customers;
        }

        private void btnCustomerDelete_Click(object sender, System.EventArgs e)
        {
            string customerId = txtCustomerId.Text;
            customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("Musteri Silme Islemi basarili", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCustomerUpdate_Click(object sender, System.EventArgs e)
        {
            string customerId = txtCustomerId.Text;
            var updatedCustomer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerCity = txtCustomerCity.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerShoppingCount = int.Parse(txtCustomerShoppingCount.Text),
                CustomerId = customerId
            };
            customerOperations.UpdateCustomer(updatedCustomer);
            MessageBox.Show("Musteri Guncelleme Islemi basarili", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnGetById_Click(object sender, System.EventArgs e)
        {
            string customerId = txtCustomerId.Text;
            Customer customers = customerOperations.GetCustomerById(customerId);
            dataGridView1.DataSource = new List<Customer> { customers };
        }
    }
}
