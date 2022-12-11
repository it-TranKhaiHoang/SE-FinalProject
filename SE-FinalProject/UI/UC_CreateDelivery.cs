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
    public partial class UC_CreateDelivery : UserControl
    {
        public UC_CreateDelivery()
        {
            InitializeComponent();
            load_LKGoods();
            load_LKAgency();
        }
        private void load_LKAgency()
        {
            
            LK_Agency.Properties.DataSource = Controllers.GetAgency();
            LK_Agency.Properties.DisplayMember = "Agency_Name";
            LK_Agency.Properties.ValueMember = "Agency_Name";
            LK_Agency.Properties.NullText = @"Chooses agency";
        }
        private void load_LKGoods()
        {
            LKDN_GoodsID.DataSource = Controllers.GetGoodsToDelivery();
            LKDN_GoodsID.DisplayMember = "GoodsID";
            LKDN_GoodsID.ValueMember = "GoodsID";
            LKDN_GoodsID.NullText = @"Chooses goods";
        }

        private void GC_ListGoodsInDN_Load(object sender, EventArgs e)
        {
            GC_ListDeliveryNote.DataSource = Controllers.GetDeliveryDetail("");
        }

        private void GC_ListDeliveryNote_Load(object sender, EventArgs e)
        {
            GC_ListDeliveryNote.DataSource = Controllers.GetDeliveryNote();

        }
    }
}
