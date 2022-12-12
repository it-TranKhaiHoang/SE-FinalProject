using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using SE_FinalProject.Classes;
using SE_FinalProject.Forms;
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

namespace SE_FinalProject.UI
{
    public partial class UC_CreateDelivery : UserControl
    {
        public UC_CreateDelivery()
        {
            InitializeComponent();
            load_LKGoods();
            load_LKAgency();
            txt_DNAcountantID.Text = Program.username;
        }
        private decimal total_amount = 0;
        private void load_LKAgency()
        {
            
            LK_Agency.Properties.DataSource = Controllers.GetAgency();
            LK_Agency.Properties.DisplayMember = "Agency_Name";
            LK_Agency.Properties.ValueMember = "AgencyID";
            LK_Agency.Properties.NullText = @"Please choose an agent";
        }
        private void load_LKGoods()
        {
            LK_ListGoods_DN.DataSource = Controllers.GetGoodsToDelivery();
            LK_ListGoods_DN.DisplayMember = "GoodsID";
            LK_ListGoods_DN.ValueMember = "GoodsID";
            LK_ListGoods_DN.NullText = @"Please select an item";
        }


        private void GC_ListDeliveryNote_Load(object sender, EventArgs e)
        {
            //GC_ListDeliveryNote.DataSource = Controllers.GetDeliveryNote();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT d.NoteID, d.AgencyID, d.AccountantID, d.Delivery_Date, d.Total_amount, a.Agency_Name, c.fullname " +
                "FROM Goods_Delivery_Note d " +
                "inner join Agency a ON d.AgencyID = a.AgencyID " +
                "inner join Accountant as c on c.UserID = d.AccountantID ";
                deliveryNoteBindingSource.DataSource = db.Query<DeliveryNote>(query, commandType: CommandType.Text);
            }

        }

        private void GC_DeliveryDetail_Load(object sender, EventArgs e)
        {
            GC_DeliveryDetail.DataSource = Controllers.GetDeliveryDetail("");
        }

        private void GV_DeliveryDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "GoodsID")
            {
                var value = GV_DeliveryDetail.GetRowCellValue(e.RowHandle, e.Column);
                var dt = Controllers.GetGoodsToReceived();
                foreach (DataRow item in dt.Rows)
                {
                    decimal quantity = 0;
                    decimal price = 0;
                    decimal amount = 0;
                    if (item["GoodsID"].ToString() == value.ToString())
                    {
                        GV_DeliveryDetail.SetRowCellValue(e.RowHandle, "Unit", item["Unit"].ToString());
                        GV_DeliveryDetail.SetRowCellValue(e.RowHandle, "Price", item["numPrice"].ToString());
                        if (GV_DeliveryDetail.GetFocusedRowCellValue(col_Quantity_DN).ToString() == "")
                        {
                            quantity = 0;
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(GV_DeliveryDetail.GetFocusedRowCellValue(col_Quantity_DN));
                            price = Convert.ToDecimal(GV_DeliveryDetail.GetFocusedRowCellValue(col_Price_DN));
                            amount = quantity * price;
                            GV_DeliveryDetail.SetFocusedRowCellValue(col_Into_Money_DN, amount);
                        }

                    }
                }
            }
            if (e.Column == col_Quantity_DN)
            {
                decimal quantity = Convert.ToDecimal(GV_DeliveryDetail.GetFocusedRowCellValue(col_Quantity_DN));
                decimal price = Convert.ToDecimal(GV_DeliveryDetail.GetFocusedRowCellValue(col_Price_DN));
                decimal amount = quantity * price;
                GV_DeliveryDetail.SetFocusedRowCellValue(col_Into_Money_DN, amount);

            }
        }

        private void editBtnDelete_DN_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to delete this row?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GV_DeliveryDetail.DeleteSelectedRows();
            }
        }

        private void btnCreateDeliveryNote_Click(object sender, EventArgs e)
        {
            String NoteID = txt_DNID.Text;
            String AccountantID = Program.userID;
            String Delivery_Date = dateEdit_DNDate.Text;
            String AgencyID = LK_Agency.Properties.GetKeyValueByDisplayValue(LK_Agency.Text).ToString();
            decimal Total_amount = total_amount;
            if (NoteID == "")
            {
                MessageBox.Show("Please enter Note ID");
            }
            else if (Delivery_Date == "")
            {
                MessageBox.Show("Please select a delivery date");
            } 
            else if (AgencyID == "")
            {
                MessageBox.Show("Please choose an agent");
            } else
            {
                //MessageBox.Show(Total_amount.ToString() + " " + NoteID+ " " + AccountantID + " " + Delivery_Date + " " + AgencyID);
                Controllers.CreateDeliveryNote(NoteID, AgencyID, AccountantID, Delivery_Date, Total_amount);
                for (int i = 0; i < GV_DeliveryDetail.DataRowCount; i++)
                {
                    String GoodsID = GV_DeliveryDetail.GetRowCellValue(GV_DeliveryDetail.GetRowHandle(i), col_GoodsID_DN).ToString();
                    String Unit = GV_DeliveryDetail.GetRowCellValue(GV_DeliveryDetail.GetRowHandle(i), col_Unit_DN).ToString();
                    decimal Price = Convert.ToDecimal(GV_DeliveryDetail.GetRowCellValue(GV_DeliveryDetail.GetRowHandle(i), col_Price_DN));
                    int Quantity = Convert.ToInt16(GV_DeliveryDetail.GetRowCellValue(GV_DeliveryDetail.GetRowHandle(i), col_Quantity_DN));
                    decimal Into_Money = Convert.ToDecimal(GV_DeliveryDetail.GetRowCellValue(GV_DeliveryDetail.GetRowHandle(i), col_Into_Money_DN));
                    Controllers.CreateDeliveryDetail(NoteID, GoodsID, Unit, Price, Quantity, Into_Money);
                }
                GC_ListDeliveryNote.DataSource = Controllers.GetDeliveryNote();
            }
            
        }

        private void GV_DeliveryDetail_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            GridSummaryItem summary = e.Info.SummaryItem;
            decimal summaryValue = Convert.ToDecimal(summary.SummaryValue);
            total_amount = summaryValue;
        }

        private void GV_ListDeliveryNote_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
            txt_DNID.Text = GV_ListDeliveryNote.GetFocusedRowCellValue("NoteID").ToString();
            dateEdit_DNDate.EditValue = GV_ListDeliveryNote.GetFocusedRowCellValue("Delivery_Date");
            LK_Agency.Properties.NullText = GV_ListDeliveryNote.GetFocusedRowCellValue("AgencyID").ToString();
            
            GC_DeliveryDetail.DataSource = Controllers.GetDeliveryDetail(GV_ListDeliveryNote.GetFocusedRowCellValue("NoteID").ToString());
            txt_DNID.Enabled = false;
            dateEdit_DNDate.Enabled = false;

            //txtReceivedReason.Enabled = false;
            btnCreateDeliveryNote.Enabled = false;
            LK_Agency.Enabled = false;
            btnDNRefresh.Enabled = true;
            buttonDelete_DN.Visible = false;
            col_GoodsID_DN.OptionsColumn.AllowEdit = false;
            col_Quantity_DN.OptionsColumn.AllowEdit = false;
            GV_DeliveryDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        private void btnDNRefresh_Click(object sender, EventArgs e)
        {
            LK_Agency.Properties.NullText = @"Chooses agency";
            txt_DNID.Enabled = true;
            dateEdit_DNDate.Enabled = true;
            btnCreateDeliveryNote.Enabled = true;
            LK_Agency.Enabled = true;
            btnDNRefresh.Enabled = false;
            buttonDelete_DN.Visible = true;
            col_GoodsID_DN.OptionsColumn.AllowEdit = true;
            col_Quantity_DN.OptionsColumn.AllowEdit = true;
            GV_DeliveryDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            txt_DNID.Text = "";
            txt_DNAcountantID.Text = Program.username;

            GC_DeliveryDetail.DataSource = Controllers.GetDeliveryDetail("");
            load_LKGoods();
        }

        private void DN_btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to delete this delivery?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String NodeID = GV_ListDeliveryNote.GetFocusedRowCellValue("NoteID").ToString();
                Controllers.DeleteDeliveryNote(NodeID);
                GC_ListDeliveryNote.DataSource = Controllers.GetDeliveryNote();
                GC_DeliveryDetail.DataSource = Controllers.GetDeliveryDetail("");
            }
        }

        private void btn_DNLoad_Click(object sender, EventArgs e)
        {
            if (dtFromDate.Text != "" && dtToDate.Text != "")
            {
                //GC_ListDeliveryNote.DataSource = Controllers.GetDeliveryNoteByDate(dtFromDate.Text,dtToDate.Text);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT d.NoteID, d.AgencyID, d.AccountantID, d.Delivery_Date, d.Total_amount, a.Agency_Name as 'Agency_Name', c.fullname as 'fullname'" +
                    "FROM Goods_Delivery_Note d " +
                    "inner join Agency a ON d.AgencyID = a.AgencyID " +
                    "inner join Accountant as c on c.UserID = d.AccountantID " +
                    $"WHERE d.Delivery_Date between '{dtFromDate.Text}' and '{dtToDate.Text}'";
                    deliveryNoteBindingSource.DataSource = db.Query<DeliveryNote>(query, commandType: CommandType.Text);
                }
            }
                
        }

        private void btn_DNPrint_Click(object sender, EventArgs e)
        {
            DeliveryNote obj = deliveryNoteBindingSource.Current as DeliveryNote;
            MessageBox.Show(obj.NoteID);
            if (obj != null)
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT d.NoteID, d.GoodsID, d.Unit, d.Price, d.Quantity, d.Into_money, g.Goods_Name " +
                    "FROM [Goods_Delivery_Detail] d " +
                    "inner join Goods g ON g.GoodsID = d.GoodsID " +
                    $"WHERE d.NoteID = '{obj.NoteID}' ";
                    List<DeliveryDetail> list = db.Query<DeliveryDetail>(query, commandType: CommandType.Text).ToList();
                    using (frmPrint frm = new frmPrint())
                    {
                        frm.printNote(obj, list);
                        frm.ShowDialog();
                    }
                }
            }
                
            

        }
    }
}
