using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using SE_FinalProject.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE_FinalProject.Forms
{
    public partial class main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public main()
        {
            InitializeComponent();
        }
        UserControl1 uc1;
        UC_Main UC_Main;
        UC_CreateReceived UC_CreateReceived;
        UC_CreateDelivery UC_CreateDelivery;
        UC_Statistical UC_Statistical;
        private void main_Load(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.ShowDialog();
            skinBarSubItem1.Caption = "Accountant - " + Program.username;
            if (UC_Main == null)
            {
                UC_Main = new UC_Main();
                UC_Main.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(UC_Main);
                UC_Main.BringToFront();
            } else
            {
                UC_Main.BringToFront();
            }
        }

        private void ac_Logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ac_CreateReceivedNote_Click(object sender, EventArgs e)
        {
            
            if (UC_CreateReceived == null)
            {
                UC_CreateReceived = new UC_CreateReceived();
                UC_CreateReceived.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(UC_CreateReceived);
                UC_CreateReceived.BringToFront();
            } else
                UC_CreateReceived.BringToFront();

        }

        private void ac_GoodsList_Click(object sender, EventArgs e)
        {
            if (uc1 == null)
            {
                uc1 = new UserControl1();
                uc1.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(uc1);
                uc1.BringToFront();
            }
            else
            {
                uc1.BringToFront();
            }
        }

        private void ac_CreateDeliveryNote_Click(object sender, EventArgs e)
        {
            if (UC_CreateDelivery == null)
            {
                UC_CreateDelivery = new UC_CreateDelivery();
                UC_CreateDelivery.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(UC_CreateDelivery);
                UC_CreateDelivery.BringToFront();
            }
            else
                UC_CreateDelivery.BringToFront();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            if (UC_Statistical == null)
            {
                UC_Statistical = new UC_Statistical();
                UC_Statistical.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(UC_Statistical);
                UC_Statistical.BringToFront();
            }
            else
                UC_Statistical.BringToFront();
        }
    }
}
