using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBankProcesses : Form
    {
        public FrmBankProcesses()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBankProcesses_Load(object sender, System.EventArgs e)
        {
            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;

            cmbProcessType.Items.Add("Gelir");
            cmbProcessType.Items.Add("Gider");
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            string desc = txtDescription.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            DateTime processDate = dtpProcessDate.Value;
            string processType = cmbProcessType.Text;
            int bankId = int.Parse(txtBankId.Text);

            BankProcesses bankProcesses = new BankProcesses();
            bankProcesses.Description = desc;
            bankProcesses.Amount = amount;
            bankProcesses.BankId = bankId;
            bankProcesses.ProcessDate = processDate;
            bankProcesses.ProcessType = processType;

            db.BankProcesses.Add(bankProcesses);
            db.SaveChanges();
            MessageBox.Show("Hareket Başarılı Bir Şekilde Sisteme Ekledi", "Banka Hareketleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnList_Click(object sender, System.EventArgs e)
        {
            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProcessId.Text);
            var removeValue = db.BankProcesses.Find(id);
            db.BankProcesses.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Hareket Başarılı Bir Sekilde Sistemden Silindi", "Banka Hareketleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string desc = txtDescription.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            DateTime processDate = dtpProcessDate.Value;
            string processType = cmbProcessType.Text;
            int id = int.Parse(txtProcessId.Text);
            var value = db.BankProcesses.Find(id);

            value.Description = desc;
            value.Amount = amount;
            value.ProcessDate = processDate;
            value.ProcessType = processType;

            db.SaveChanges();
            MessageBox.Show("Hareket Başarılı Bir Sekilde Sistemde Guncellendi", "Banka Hareketleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }



        private void btnGiderler_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
