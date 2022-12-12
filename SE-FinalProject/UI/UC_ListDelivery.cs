using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using SE_FinalProject.Classes;
using SE_FinalProject.Forms;

namespace SE_FinalProject.UI
{
    public partial class UC_ListDelivery : XtraForm
    {
        public UC_ListDelivery()
        {
            InitializeComponent();
        }

        private void btnLoadDN_Click(object sender, EventArgs e)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                string query = "select n.NoteID, n.AccountantID, a.AgencyID, n.Delivery_Date, n.Total_amount, a.Agency_Name " +
                    "from Goods_Delivery_Note n inner join Agency a on n.AgencyID  = a.AgencyID";
                    //$"where n.Delivery_Date between convert(varchar(25),'{dateEditFrom.EditValue}', 103) and convert(varchar(25),'{dateEditTo.EditValue}', 103) ";
                deliveryNoteBindingSource.DataSource = db.Query<DeliveryNote>(query, commandType: CommandType.Text);
            }
            
        }

        private void btnPrintDN_Click(object sender, EventArgs e)
        {
            DeliveryNote obj = deliveryNoteBindingSource.DataSource as DeliveryNote;
            if (obj != null)
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    {
                        db.Open();
                    }
                    string query = "select p.Goods_Name, d.NoteID, d.Unit, d.Price, d.Quantity, d.Into_Money" +
                        "from [Goods_Delivery_Detail] d inner join Goods g on g.GoodsID = p.GoodsID" +
                    $"where d.NoteID = '{obj.NoteID}'";
                    List<DeliveryDetail> list = db.Query<DeliveryDetail>(query, commandType: CommandType.Text).ToList();
                    using (frmPrint frm = new frmPrint())
                    {
                        frm.printNote(obj);
                        frm.ShowDialog();
                    }
                }
            }
        }
    }
}
