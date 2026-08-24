using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataExport
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection SQLConnection = null;
            System.Data.SqlClient.SqlDataAdapter DataAdapter1 = null;
            System.Data.SqlClient.SqlDataAdapter DataAdapter2 = null;
            System.Data.DataSet LocalDataSet1 = new DataSet("Data");
            System.Data.DataSet LocalDataSet2 = new DataSet("Data");
            string Query = "";
            int TableCount = 0;
            int RowCount = 0;
            string Filename = "";
            StringBuilder sb = null;

            Cursor.Current = Cursors.WaitCursor;

            SQLConnection = new System.Data.SqlClient.SqlConnection("Data Source=" + txtServer.Text + ";Initial Catalog=" + txtDatabase.Text + ";User ID=" + txtUsername.Text + ";Password=" + txtPassword.Text + ";Connection Timeout=0");
            SQLConnection.Open();

            Query = "select name from sys.tables order by name";

            DataAdapter1 = new System.Data.SqlClient.SqlDataAdapter(Query, SQLConnection);

            DataAdapter1.Fill(LocalDataSet1, "Data");
            TableCount = LocalDataSet1.Tables[0].Rows.Count;

            // Extract the names of all tables

            foreach (DataRow r in LocalDataSet1.Tables[0].Rows)
            {
                lstTables.Items.Add(r[0].ToString());
            }

            this.Refresh();

            foreach (string Table in lstTables.Items)
            {
                Query = "Select * from " + Table;

                Console.WriteLine (Query);

                LocalDataSet2.Clear();

                // Get all data in this table
                DataAdapter2 = new System.Data.SqlClient.SqlDataAdapter(Query, SQLConnection);
                DataAdapter2.Fill(LocalDataSet2, "Data");

                RowCount = LocalDataSet2.Tables[0].Rows.Count;

                Console.WriteLine("Table " + Table + " has " + RowCount + " rows.");

                if (RowCount > 0)
                {
                    sb = new StringBuilder();

                    IEnumerable<string> columnNames = LocalDataSet2.Tables[0].Columns.Cast<DataColumn>().
                                                        Select(column => column.ColumnName);
                    sb.AppendLine(string.Join(",", columnNames));

                    foreach (DataRow row in LocalDataSet2.Tables[0].Rows)
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                        sb.AppendLine(string.Join(",", fields));
                    }

                    Filename = txtOutputFolder.Text + "\\" + Table + ".csv";

                    System.IO.File.WriteAllText(Filename, sb.ToString());

                    sb.Clear();
                    
                }
            }

            // Cleanup

            DataAdapter1.Dispose();
            DataAdapter2.Dispose();

            LocalDataSet1.Clear();
            
            LocalDataSet1.Dispose();
            LocalDataSet2.Dispose();

            SQLConnection.Close();
            SQLConnection.Dispose();

            Cursor.Current = Cursors.Default;
        }
    }
}
