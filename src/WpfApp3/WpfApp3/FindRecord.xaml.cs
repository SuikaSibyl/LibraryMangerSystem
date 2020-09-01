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
    /// FindRecord.xaml 的交互逻辑
    /// </summary>
    public partial class FindRecord : Page
    {
        public FindRecord()
        {
            InitializeComponent();
        }
        string connectionString = "Dsn=test;uid=root";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                string selectSQL = "SELECT bno,borrowDate,title,category,press,year,author,price\n" +
                    "FROM(SELECT bno, date_format(borrow_date, '%Y-%m-%d') AS borrowDate FROM borrow WHERE cno = '" +
                    CardID.Text + "' AND return_date = 0000 - 00 - 00 )AS bo LEFT JOIN book USING(bno)";
                string selectSQL2 = "SELECT bno,borrowDate,title,category,press,year,author,price\n" +
                    "FROM(SELECT bno, date_format(borrow_date, '%Y-%m-%d') AS borrowDate FROM borrow WHERE cno = '" +
                    CardID.Text + "' AND return_date != 0000 - 00 - 00 )AS bo LEFT JOIN book USING(bno)";
                OdbcDataReader reader = null;
                OdbcDataReader reader2 = null;
                OdbcCommand command = new OdbcCommand(selectSQL, connection);
                OdbcCommand command2 = new OdbcCommand(selectSQL2, connection);
                // Open the connection and execute the select command.
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    DataTable datatable = new DataTable();
                    datatable.Load(reader);
                    if (datatable.Rows.Count > 0 && datatable != null)
                    {
                        NotReturned.ItemsSource = datatable.AsDataView();
                    }
                    reader2 = command2.ExecuteReader();
                    DataTable datatable2 = new DataTable();
                    datatable2.Load(reader2);
                    if (datatable2.Rows.Count > 0 && datatable2 != null)
                    {
                        HaveReturned.ItemsSource = datatable2.AsDataView();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
        }
    }
}
