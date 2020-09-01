using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.Odbc;

namespace WpfApp3
{
    /// <summary>
    /// LibraryQuery.xaml 的交互逻辑
    /// </summary>
    public partial class LibraryQuery : Page
    {
        string connectionString = "Dsn=test;uid=root";
        string selectSQL = "Select * From book ";
        public LibraryQuery()
        {
            InitializeComponent();
        }
        private void Enter_Query(object sender, RoutedEventArgs e)
        {
            selectSQL = "Select * From book ";
            int where = 0;
            if(BookID.Text != "")
            {
                if (where == 0)
                    selectSQL += "WHERE bno = '" + BookID.Text + "'";
                else
                    selectSQL += " AND  bno = '" + BookID.Text + "'";
                where++;
            }
            if (Category.Text != "")
            {
                if (where == 0)
                    selectSQL += "WHERE category = '" + Category.Text + "'";
                else
                    selectSQL += " AND  category = '" + Category.Text + "'";
                where++;
            }
            if (BookName.Text != "")
            {
                if (where == 0)
                    selectSQL += "WHERE title = '" + BookName.Text + "'";
                else
                    selectSQL += " AND  title = '" + BookName.Text + "'";
                where++;
            }
            if (Publish.Text != "")
            {
                if (where == 0)
                    selectSQL += "WHERE press = '" + Publish.Text + "'";
                else
                    selectSQL += " AND  press = '" + Publish.Text + "'";
                where++;
            }
            if (BookWriter.Text != "")
            {
                if (where == 0)
                    selectSQL += "WHERE author = '" + BookWriter.Text + "'";
                else
                    selectSQL += " AND author = '" + BookWriter.Text + "'";
                where++;
            }
            if (BookYearL.Text != "" && BookYearR.Text != "") 
            {
                if (where == 0)
                    selectSQL += "WHERE year between " + BookYearL.Text + " AND " +BookYearR.Text;
                else
                    selectSQL += " AND year between " + BookYearL.Text + " AND " + BookYearR.Text;
                where++;
            }
            if (BookPricel.Text != "" && BookPricer.Text != "")
            {
                if (where == 0)
                    selectSQL += "WHERE price between " + BookPricel.Text + " AND " + BookPricer.Text;
                else
                    selectSQL += " AND price between " + BookPricel.Text + " AND " + BookPricer.Text;
                where++;
            }
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                OdbcDataReader reader = null;
                OdbcCommand command = new OdbcCommand(selectSQL, connection);
                // Open the connection and execute the select command.
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    DataTable datatable = new DataTable();
                    datatable.Load(reader);
                    if (datatable.Rows.Count > 0 && datatable != null)
                    {
                        QueryGrid.ItemsSource = datatable.AsDataView();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
        }
    }
}
