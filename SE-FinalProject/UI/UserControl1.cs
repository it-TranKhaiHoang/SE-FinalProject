using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using SE_FinalProject.Properties;
using System.Resources;

namespace SE_FinalProject.UI
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        Dictionary<string, Image> imageCache = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);
        Dictionary<int, Image> storage = new Dictionary<int, Image>();

        void AddUnboundColumn(GridView view)
        {
            // Create an unbound column.
            GridColumn colImage = new GridColumn();
            colImage.FieldName = "Image";
            colImage.Caption = "Image";
            colImage.UnboundType = UnboundColumnType.Object;
            colImage.OptionsColumn.AllowEdit = false;
            colImage.Visible = true;
            // Add the Image column to the grid's Columns collection.
            view.Columns.Add(colImage);
        }

        void AssignPictureEdittoImageColumn(GridColumn column)
        {
            // Create and customize the PictureEdit repository item.
            RepositoryItemPictureEdit riPictureEdit = new RepositoryItemPictureEdit();
            riPictureEdit.SizeMode = PictureSizeMode.Zoom;
            // Add the PictureEdit to the grid's RepositoryItems collection.
            gcGoods.RepositoryItems.Add(riPictureEdit);

            // Assign the PictureEdit to the 'Image' column.
            column.ColumnEdit = riPictureEdit;
        }


        private void gcGoods_Load(object sender, EventArgs e)
        {
            AddUnboundColumn(gridView1);
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[6].VisibleIndex = 1;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            gcGoods.DataSource = Controllers.GetGoodsList();
        }

        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            AssignPictureEdittoImageColumn(e.Column);
            if (e.Column.FieldName == "Image" && e.IsGetData)
            {
                GridView view = sender as GridView;
                string fileName = view.GetRowCellValue(view.GetRowHandle(e.ListSourceRowIndex), "Image Path") as string ?? string.Empty;
                if (!imageCache.ContainsKey(fileName))
                {
                    ResourceManager rm = Resources.ResourceManager;
                    Bitmap myImage = (Bitmap)rm.GetObject(fileName);
                    //e.Value = storage[e.ListSourceRowIndex] = Image.FromFile(fileName);
                    //e.Value = storage[e.ListSourceRowIndex] = Properties.Resources.checklist;
                    e.Value = storage[e.ListSourceRowIndex] = myImage;
                }
                storage[e.ListSourceRowIndex] = (Image)e.Value;
            }
        }

    }
}
