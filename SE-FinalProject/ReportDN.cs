using DevExpress.XtraReports.UI;
using SE_FinalProject.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace SE_FinalProject
{
    public partial class ReportDN : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportDN()
        {
            InitializeComponent();
        }

        public void InitData(String NoteID, String AgencyID, String AccountantID, DateTime date, List<DeliveryDetail> data)
        {
            pNoteID.Value = NoteID;
            pAgency.Value = AgencyID;
            pAccountant.Value = AccountantID;
            pDeliveryDate.Value = date;
            objectDataSource1.DataSource = data;
        }

    }
}
