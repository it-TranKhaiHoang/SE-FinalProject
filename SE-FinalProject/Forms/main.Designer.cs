namespace SE_FinalProject.Forms
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.mainContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.ac_GoodsList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ac_CreateReceivedNote = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ac_Delivery = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ac_CreateDeliveryNote = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.ac_Logout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator2 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.skinBarSubItem1 = new DevExpress.XtraBars.SkinBarSubItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(260, 46);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(562, 548);
            this.mainContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ac_GoodsList,
            this.accordionControlElement1,
            this.ac_Delivery,
            this.accordionControlSeparator1,
            this.ac_Logout,
            this.accordionControlSeparator2});
            this.accordionControl1.Location = new System.Drawing.Point(0, 46);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 548);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // ac_GoodsList
            // 
            this.ac_GoodsList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ac_GoodsList.ImageOptions.SvgImage")));
            this.ac_GoodsList.Name = "ac_GoodsList";
            this.ac_GoodsList.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ac_GoodsList.Text = "Goods";
            this.ac_GoodsList.Click += new System.EventHandler(this.ac_GoodsList_Click);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ac_CreateReceivedNote});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement1.ImageOptions.Image")));
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Received";
            // 
            // ac_CreateReceivedNote
            // 
            this.ac_CreateReceivedNote.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ac_CreateReceivedNote.ImageOptions.Image")));
            this.ac_CreateReceivedNote.Name = "ac_CreateReceivedNote";
            this.ac_CreateReceivedNote.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ac_CreateReceivedNote.Text = "Create received note";
            this.ac_CreateReceivedNote.Click += new System.EventHandler(this.ac_CreateReceivedNote_Click);
            // 
            // ac_Delivery
            // 
            this.ac_Delivery.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ac_CreateDeliveryNote});
            this.ac_Delivery.Expanded = true;
            this.ac_Delivery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ac_Delivery.ImageOptions.Image")));
            this.ac_Delivery.Name = "ac_Delivery";
            this.ac_Delivery.Text = "Delivery";
            // 
            // ac_CreateDeliveryNote
            // 
            this.ac_CreateDeliveryNote.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ac_CreateDeliveryNote.ImageOptions.Image")));
            this.ac_CreateDeliveryNote.Name = "ac_CreateDeliveryNote";
            this.ac_CreateDeliveryNote.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ac_CreateDeliveryNote.Text = "Create Delivery Not";
            this.ac_CreateDeliveryNote.Click += new System.EventHandler(this.ac_CreateDeliveryNote_Click);
            // 
            // accordionControlSeparator1
            // 
            this.accordionControlSeparator1.Name = "accordionControlSeparator1";
            // 
            // ac_Logout
            // 
            this.ac_Logout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ac_Logout.ImageOptions.Image")));
            this.ac_Logout.Name = "ac_Logout";
            this.ac_Logout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ac_Logout.Text = "Logout";
            this.ac_Logout.Click += new System.EventHandler(this.ac_Logout_Click);
            // 
            // accordionControlSeparator2
            // 
            this.accordionControlSeparator2.Name = "accordionControlSeparator2";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinBarSubItem1});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(822, 46);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.skinBarSubItem1);
            // 
            // skinBarSubItem1
            // 
            this.skinBarSubItem1.Caption = "Accountant - Trần Khải Hoàng";
            this.skinBarSubItem1.Id = 0;
            this.skinBarSubItem1.Name = "skinBarSubItem1";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinBarSubItem1});
            this.fluentFormDefaultManager1.MaxItemId = 1;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 594);
            this.ControlContainer = this.mainContainer;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.Image = global::SE_FinalProject.Properties.Resources.logoHoangThong_removebg_preview;
            this.Name = "main";
            this.NavigationControl = this.accordionControl1;
            this.Text = "HOANG THONG";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer mainContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ac_CreateReceivedNote;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ac_Delivery;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ac_CreateDeliveryNote;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ac_Logout;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ac_GoodsList;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator2;
    }
}