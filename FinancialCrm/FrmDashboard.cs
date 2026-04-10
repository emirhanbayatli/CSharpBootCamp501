using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }


        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        int count = 0;
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + " TL";

            var lastBankProcessAmount = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString() + " TL";

            var bankData = db.Banks.Select(x => new { x.BankTitle, x.BankBalance }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            var billData = db.Bills.Select(x => new { x.BillTitle, x.BillAmount }).ToList();

            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 4 == 1)
            {
                var bill1 = db.Bills.Where(x => x.BillTitle == "Elektirik Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektirik Faturasi";
                lblBillAmount.Text = bill1.ToString() + " TL";
            }
            if (count % 4 == 2)
            {
                var bill1 = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Doğalgaz Faturasi";
                lblBillAmount.Text = bill1.ToString() + " TL";
            }
            if (count % 4 == 3)
            {
                var bill1 = db.Bills.Where(x => x.BillTitle == "Su Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturasi";
                lblBillAmount.Text = bill1.ToString() + " TL";
            }
            if (count % 4 == 0)
            {
                var bill1 = db.Bills.Where(x => x.BillTitle == "Internet Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Internet Faturasi";
                lblBillAmount.Text = bill1.ToString() + " TL";
            }



        }

        private void btnBankForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }



        private void frmBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmBankProcesses frm = new FrmBankProcesses();
            frm.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
