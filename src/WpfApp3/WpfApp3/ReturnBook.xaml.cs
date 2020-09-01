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
    /// ReturnBook.xaml 的交互逻辑
    /// </summary>
    public partial class ReturnBook : Page
    {
        public ReturnBook()
        {
            InitializeComponent();
        }
        string connectionString = "Dsn=test;uid=root";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                try
                {
                    string selectSQL = "SELECT * FROM borrow WHERE bno = '" + 
                        BNO.Text + "' AND cno = '" + CNO.Text + "'AND return_date = 0000 - 00 - 00;";
                    OdbcDataReader reader = null;
                    OdbcCommand command = new OdbcCommand(selectSQL, connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        reader.Read();
                        string insertCommand = "UPDATE borrow SET return_date = current_date()\nWHERE bno='" + BNO.Text + "'";
                        OdbcCommand insert_command = new OdbcCommand(insertCommand, connection);
                        insert_command.ExecuteNonQuery();


                        string bookSQL = "SELECT * FROM book WHERE bno = '" + BNO.Text + "';";
                        OdbcDataReader breader = null;
                        OdbcCommand bcommand = new OdbcCommand(bookSQL, connection);
                        breader = bcommand.ExecuteReader();
                        breader.Read();
                        string strStockNumber = (Convert.ToInt32(breader["stock"]) + 1).ToString();
                        string updateCommand = "UPDATE book SET stock = " + strStockNumber +
                            " \nWHERE bno='" + BNO.Text + "'";
                        OdbcCommand update_Command = new OdbcCommand(updateCommand, connection);
                        update_Command.ExecuteNonQuery();

                        MessageBox.Show("成功还书！\n");
                    }
                    else
                    {
                        MessageBox.Show("并无此借书记录！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
