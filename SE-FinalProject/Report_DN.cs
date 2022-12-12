using DevExpress.XtraReports.UI;
using SE_FinalProject.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace SE_FinalProject
{
    public partial class Report_DN : DevExpress.XtraReports.UI.XtraReport
    {
        public Report_DN()
        {
            InitializeComponent();
        }

        public void InitData(String Agency, String NoteID, String Accountant, DateTime date) 
        {
            pAgency.Value = Agency;
            pAccountant.Value = Accountant;
            pDate.Value = date;
            pNoteID.Value = NoteID;
        }
    }
}
