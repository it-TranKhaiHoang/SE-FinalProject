using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_FinalProject
{
    public class Controllers 
    {
        static SqlConnection conn = new SqlConnection();

        // Connect to Database
        public static void ConnectToDB ()
        {
            conn = new SqlConnection(Program.connectionString);
            conn.Open();
        }
        // Close connect to Database
        public static void CloseConnect()
        {
            conn.Close();
        }

        // Get data to DataTable
        public static DataTable GetData (String query)
        {
            ConnectToDB();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CloseConnect();
            return dt;
        }


        public DataTable _GetData(String query)
        {
            ConnectToDB();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CloseConnect();
            return dt;
        }

        public static int AddData (String query)
        {
            ConnectToDB();
            SqlCommand cmd = new SqlCommand(query, conn);
            int i = cmd.ExecuteNonQuery();
            CloseConnect();
            return i;
        }

        public static int DeleteData(String query)
        {
            ConnectToDB();
            SqlCommand cmd = new SqlCommand(query, conn);
            int i = cmd.ExecuteNonQuery();
            CloseConnect();
            return i;
        }
        

        public static DataTable GetGoodsList ()
        {
            DataTable dt = GetData(
                "SELECT GoodsID as 'ID', Goods_Img as 'Image Path' , Goods_Name as 'Name', Unit, Quantity, FORMAT(Price,'c','vi-VN') AS 'Price'"
                + "FROM Goods");
            return dt;
        }

        public static DataTable GetGoodsToReceived()
        {
            DataTable dt = GetData(
               "SELECT GoodsID, Goods_Img,Price as 'numPrice', Goods_Name, Unit, Quantity, FORMAT(Price,'c','vi-VN') AS 'Price'"
               + "FROM Goods");
            
            return dt;
        }

        public static DataTable GetGoodsToDelivery()
        {
            DataTable dt = GetData(
               "SELECT GoodsID, Goods_Img,Price as 'numPrice', Goods_Name, Unit, Quantity, FORMAT(Price,'c','vi-VN') AS 'Price'"
               + "FROM Goods WHERE Quantity > 0");
            return dt;
        }

        public static DataTable GetAgency()
        {
            DataTable dt = GetData("SELECT * FROM Agency");
            return dt;
        }

        public static DataTable GetReceivedNoteList()
        {
            DataTable dt = GetData(
                "SELECT NoteID,AccountantID, Received_Reason, (SELECT fullname FROM Accountant as a WHERE a.UserID = AccountantID) as 'Accountant'," +
                "FORMAT( Received_Date,'dddd, MMMM dd, yyyy hh:mm:ss tt','VI-VN') AS 'Received_Date'," +
                "FORMAT(Total_amount,'c','vi-VN') AS 'Total_amount', Total_amount as 'Total' " +
                "FROM Goods_Received_Note");
            return dt;
        }

        public static DataTable GetReceivedDetail(String NoteID)
        {
            String sql = "SELECT * FROM Goods_Received_Detail WHERE NoteID = '"+ NoteID +"'";
            DataTable dt = GetData(sql);
            if (dt == null)
               return null;
            return dt;
        }
        public static DataTable GetDeliveryNote()
        {
            DataTable dt = GetData("SELECT d.NoteID, d.AgencyID, d.AccountantID, d.Delivery_Date, d.Total_amount, a.Agency_Name, c.fullname " +
                "FROM Goods_Delivery_Note d " +
                "inner join Agency a ON d.AgencyID = a.AgencyID " +
                "inner join Accountant as c on c.UserID = d.AccountantID");
            return dt;
        }
        public static DataTable GetDeliveryNoteByDate(String FromDate, String ToDate)
        {
            DataTable dt = GetData("SELECT d.NoteID, d.AgencyID, d.AccountantID, d.Delivery_Date, d.Total_amount, a.Agency_Name, c.fullname " +
                "FROM Goods_Delivery_Note d " +
                "inner join Agency a ON d.AgencyID = a.AgencyID " +
                "inner join Accountant as c on c.UserID = d.AccountantID " +
                $"WHERE d.Delivery_Date between '{FromDate}' and '{ToDate}'");
            return dt;
        }
        public static DataTable GetDeliveryDetail(String NoteID)
        {
            String sql = "SELECT * FROM Goods_Delivery_Detail WHERE NoteID = '" + NoteID + "'";
            DataTable dt = GetData(sql);
            if (dt == null)
                return null;
            return dt;
        }
        public static void CreateReceivedDetail(String NoteID, String GoodsID, String Unit, decimal Price, int Quantity, decimal Into_Money)
        {
            int i = AddData("INSERT INTO Goods_Received_Detail(NoteID, GoodsID, Unit, Price, Quantity, Into_Money)" +
                "VALUES('"+ NoteID + "', '"+ GoodsID + "', '"+ Unit + "', "+ Price + ", "+ Quantity + ","+ Into_Money + ")");
            
        }

        public static void CreateReceivedNote(String NoteID, String AccountantID, String Received_Reason, decimal Total_amount)
        {
            int i = AddData("INSERT INTO Goods_Received_Note (NoteID, AccountantID, Received_Reason, Total_amount) " +
               "VALUES('"+ NoteID + "', '"+ AccountantID + "', '"+ Received_Reason + "', "+ Total_amount + ")");
            if (i != 0)
            {
                MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteReceivedNote(String NoteID)
        {
            String sql = "DELETE FROM Goods_Received_Detail WHERE NoteID = '" + NoteID +"'" ;
            int isDeleteReceivedDetail = DeleteData(sql);
            if (isDeleteReceivedDetail != 0)
            {
                int isDeleteReceivedNote = DeleteData("DELETE FROM Goods_Received_Note WHERE NoteID = '" + NoteID + "'");
                if (isDeleteReceivedNote != 0)
                {
                    MessageBox.Show("Delete received note success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CreateDeliveryNote(String NoteID, String AgencyID, String AccountantID, String Delivery_Date, decimal Total_amount )
        {
            int i = AddData("INSERT INTO Goods_Delivery_Note (NoteID,AgencyID, AccountantID,Delivery_Date, Total_amount)" +
               "VALUES('"+NoteID+"', '"+AgencyID+"', '"+AccountantID+"','"+Delivery_Date+"', "+Total_amount+")");
            if (i != 0)
            {
                MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CreateDeliveryDetail(String NoteID, String GoodsID, String Unit, decimal Price, int Quantity, decimal Into_Money) 
        {
            int i = AddData("INSERT INTO Goods_Delivery_Detail(NoteID, GoodsID, Unit, Price, Quantity, Into_Money)" +
                "VALUES('" + NoteID + "', '" + GoodsID + "', '" + Unit + "', " + Price + ", " + Quantity + "," + Into_Money + ")");
        }
        public static void DeleteDeliveryNote(String NoteID)
        {
            String sql = "DELETE FROM Goods_Delivery_Detail WHERE NoteID = '" + NoteID + "'";
            int isDeleteReceivedDetail = DeleteData(sql);
            if (isDeleteReceivedDetail != 0)
            {
                int isDeleteReceivedNote = DeleteData("DELETE FROM Goods_Delivery_Note WHERE NoteID = '" + NoteID + "'");
                if (isDeleteReceivedNote != 0)
                {
                    MessageBox.Show("Delete delivery note success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static DataTable getImportReport(String from, String to)
        {
            String query = "select g.Goods_Name,g.GoodsID, SUM(q.Quantity) as 'Total' " +
                " from Goods_Received_Note d " +
                " inner join Goods_Received_Detail q on q.NoteID = d.NoteID " +
                " inner join Goods g on q.GoodsID = g.GoodsID " +
                $" where Received_Date between '{from}' and '{to}' " +
                " group by g.Goods_Name,g.GoodsID ";
            DataTable dt = GetData(query);

            return dt;
        }

        public static DataTable getExportReport(String from, String to)
        {
            String query = "select g.Goods_Name,g.GoodsID, SUM(q.Quantity) as 'Total' " +
                "from Goods_Delivery_Note d " +
                " inner join Goods_Delivery_Detail q on q.NoteID = d.NoteID " +
                " inner join Goods g on q.GoodsID = g.GoodsID " +
                $" where Delivery_Date between '{from}' and '{to}' " +
                " group by g.Goods_Name,g.GoodsID ";
            DataTable dt = GetData(query);

            return dt;
        }

        public static DataTable getSellingReport(String from, String to)
        {
            String query = " select total.Goods_Name, max(total.Total) as 'Quantity' " +
                " from (select g.Goods_Name,g.GoodsID, SUM(q.Quantity) as 'Total' " +
                " from Goods_Received_Note d " +
                " inner join Goods_Received_Detail q on q.NoteID = d.NoteID" +
                " inner join Goods g on q.GoodsID = g.GoodsID " +
                $" where Received_Date between '{from}' and '{to}' " +
                " group by g.Goods_Name,g.GoodsID) as total" +
                " group by total.Goods_Name" +
                " order by Quantity DESC ";
            DataTable dt = GetData(query);

            return dt;
        }

        public static DataTable getEvenueReport(String from, String to)
        {
            String query = " select sum(d.Total_amount) as 'Turnover' " +
                " from Goods_Delivery_Note d " +
                $" where Delivery_Date between '{from}' and '{to}' ";
            DataTable dt = GetData(query);

            return dt;
        }

    }

}
