using DevExpress.XtraEditors;
using SE_FinalProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_FinalProject.Forms
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        public void printNote(DeliveryNote DN)
        {
            Report_DN report = new Report_DN();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(DN.AgencyID, DN.NoteID, DN.AccountantID, DN.Delivery_Date);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}