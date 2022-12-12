using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
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

namespace SE_FinalProject.UI
{
    public partial class UC_CreateReceived : UserControl
    {
        public UC_CreateReceived()
        {
            InitializeComponent();
            load_LKGoods();
        }

        private decimal total_amount = 0;
       
        
        private void load_LKGoods()
        {
            LK_ListGoods.DataSource = Controllers.GetGoodsToReceived();
            LK_ListGoods.DisplayMember = "GoodsID";
            LK_ListGoods.ValueMember = "GoodsID";
            LK_ListGoods.NullText = @"Please select an item";
        }


        private void GC_ReceivedNote_Load(object sender, EventArgs e)
        {
            GC_ReceivedNote.DataSource = Controllers.GetReceivedNoteList();
            //btnRefresh.Enabled = false;
            dateEdit_ReceivedDate.EditValue = DateTime.Now;
            dateEdit_ReceivedDate.Enabled = true;
            txtAccountant.Text = Program.username;
        }

        

        private void GC_ReceivedDetail_Load(object sender, EventArgs e)
        {
           GC_ReceivedDetail.DataSource = Controllers.GetReceivedDetail("");
           //GC_ReceivedDetail.DataSource = Controllers.GetDeliveryDetail("GDN-001");
        }

        private void GV_ReceivedNote_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtNodeID.Text = GV_ReceivedNote.GetFocusedRowCellValue("NoteID").ToString();
            dateEdit_ReceivedDate.EditValue = GV_ReceivedNote.GetFocusedRowCellValue("Received_Date");
           
            txtAccountant.Text = GV_ReceivedNote.GetFocusedRowCellValue("Accountant").ToString();
            txtReceivedReason.Text = GV_ReceivedNote.GetFocusedRowCellValue("Received_Reason").ToString();
            GC_ReceivedDetail.DataSource = Controllers.GetReceivedDetail(GV_ReceivedNote.GetFocusedRowCellValue("NoteID").ToString());
            txtNodeID.Enabled = false;
            dateEdit_ReceivedDate.Enabled = false;
            
            txtReceivedReason.Enabled = false;
            btnCreate_CreateReceived.Enabled = false;
            btnRefresh.Enabled = true;
            buttonDelete.Visible = false;
            col_GoodsID.OptionsColumn.AllowEdit = false;
            col_Quantity.OptionsColumn.AllowEdit = false;
            GV_ReceivedDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Enabled Edit Text
            txtNodeID.Enabled = true;
            dateEdit_ReceivedDate.Enabled = true;
           
            txtReceivedReason.Enabled = true;
            btnCreate_CreateReceived.Enabled = true;
            btnRefresh.Enabled = false;
            
            // Refresh Edit Text
            txtNodeID.Text = "";
          
            txtReceivedReason.Text = "";
            txtAccountant.Text = Program.username;
            dateEdit_ReceivedDate.EditValue = DateTime.Now;
            buttonDelete.Visible = true;
            col_GoodsID.OptionsColumn.AllowEdit = true;
            col_Quantity.OptionsColumn.AllowEdit = true;
            GV_ReceivedDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            // Refresh Received Detail Grid Control
            GC_ReceivedDetail.DataSource = Controllers.GetReceivedDetail("");
        }

        private void btnCreate_CreateReceived_Click(object sender, EventArgs e)
        {
            String NoteID = txtNodeID.Text;
            String AccountantID = Program.userID;
            String Received_Reason = txtReceivedReason.Text;
            decimal Total_amount = total_amount;
            if (txtNodeID.Text == "")
            {
                MessageBox.Show("Please enter Note ID");
            }
            else if (txtReceivedReason.Text == "")
            {
                MessageBox.Show("Please enter Received Reason");
            } else
            {
                Controllers.CreateReceivedNote(NoteID, AccountantID, Received_Reason, Total_amount);
                // Craate Received Detail
                for (int i = 0; i < GV_ReceivedDetail.DataRowCount; i++)
                {
                    String GoodsID = GV_ReceivedDetail.GetRowCellValue(GV_ReceivedDetail.GetRowHandle(i), col_GoodsID).ToString();
                    String Unit = GV_ReceivedDetail.GetRowCellValue(GV_ReceivedDetail.GetRowHandle(i), col_Unit).ToString();
                    decimal Price = Convert.ToDecimal(GV_ReceivedDetail.GetRowCellValue(GV_ReceivedDetail.GetRowHandle(i), col_Price));
                    int Quantity = Convert.ToInt16(GV_ReceivedDetail.GetRowCellValue(GV_ReceivedDetail.GetRowHandle(i), col_Quantity));
                    decimal Into_Money = Convert.ToDecimal(GV_ReceivedDetail.GetRowCellValue(GV_ReceivedDetail.GetRowHandle(i), col_Into_Money));
                    Controllers.CreateReceivedDetail(NoteID, GoodsID, Unit, Price, Quantity, Into_Money);
                }

                GC_ReceivedNote.DataSource = Controllers.GetReceivedNoteList();
            }
        }

        private void GV_ReceivedDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "GoodsID")
            {
                var value = GV_ReceivedDetail.GetRowCellValue(e.RowHandle, e.Column);
                var dt = Controllers.GetGoodsToReceived();
                foreach (DataRow item in dt.Rows)
                {
                   decimal quantity = 0;
                   decimal price = 0;
                   decimal amount = 0;
                   if (item["GoodsId"].ToString() == value.ToString())
                   {
                        GV_ReceivedDetail.SetRowCellValue(e.RowHandle, "Unit", item["Unit"].ToString());
                        GV_ReceivedDetail.SetRowCellValue(e.RowHandle, "Price", item["numPrice"].ToString());
                        if (GV_ReceivedDetail.GetFocusedRowCellValue(col_Quantity).ToString() == "") {
                            quantity = 0;
                        } else
                        {
                            quantity = Convert.ToDecimal(GV_ReceivedDetail.GetFocusedRowCellValue(col_Quantity));
                            price = Convert.ToDecimal(GV_ReceivedDetail.GetFocusedRowCellValue(col_Price));
                            amount = quantity * price;
                            GV_ReceivedDetail.SetFocusedRowCellValue(col_Into_Money, amount);
                        }
                        
                   }
                }
            }
            if (e.Column == col_Quantity)
            {
                decimal quantity = Convert.ToDecimal(GV_ReceivedDetail.GetFocusedRowCellValue(col_Quantity));
                decimal price = Convert.ToDecimal(GV_ReceivedDetail.GetFocusedRowCellValue(col_Price));
                decimal amount = quantity * price;
                GV_ReceivedDetail.SetFocusedRowCellValue(col_Into_Money,amount);
                
            }
        }

        private void editBtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to delete this row?", "Delete", MessageBoxButtons.YesNo,  MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GV_ReceivedDetail.DeleteSelectedRows();
            }
        }

        private void GV_ReceivedDetail_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            GridSummaryItem summary = e.Info.SummaryItem;
            decimal summaryValue = Convert.ToDecimal(summary.SummaryValue);
            total_amount = summaryValue;
        }

        private void btn_DeleteReceivedNote_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to delete this received?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String NodeID = GV_ReceivedNote.GetFocusedRowCellValue("NoteID").ToString();
                Controllers.DeleteReceivedNote(NodeID);
                GC_ReceivedNote.DataSource = Controllers.GetReceivedNoteList();
                GC_ReceivedDetail.DataSource = Controllers.GetReceivedDetail("");
            }
        }
    }
}
