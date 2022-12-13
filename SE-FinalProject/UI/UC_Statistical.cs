using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_FinalProject.UI
{
    public partial class UC_Statistical : UserControl
    {
        public UC_Statistical()
        {
            InitializeComponent();
        }

        private void btn_STFind_Click(object sender, EventArgs e)
        {
            String from = dt_STFromDate.Text;
            String to = dt_STToDate.Text;
            if (dt_STFromDate.Text != "" && dt_STToDate.Text != "")
            {
                GC_ImportReport.DataSource = Controllers.getImportReport(from, to);
                GC_ExportReport.DataSource = Controllers.getExportReport(from, to);
                GC_SellingReport.DataSource = Controllers.getSellingReport(from, to);
                GC_RevenueReport.DataSource = Controllers.getEvenueReport(from, to);
            } else
            {
                MessageBox.Show("Please select From Date and To Date");
            }
        }

        private void btn_STRefresh_Click(object sender, EventArgs e)
        {
            dt_STFromDate.Text = "";
            dt_STToDate.Text = "";
            GC_ImportReport.DataSource = Controllers.getImportReport("", "");
            GC_ExportReport.DataSource = Controllers.getExportReport("", "");
            GC_SellingReport.DataSource = Controllers.getSellingReport("", "");
            GC_RevenueReport.DataSource = Controllers.getEvenueReport("", "");
        }
    }
}
