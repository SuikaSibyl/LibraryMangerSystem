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
    /// BorrowBook.xaml 的交互逻辑
    /// </summary>
    public partial class BorrowBook : Page
    {
        public BorrowBook()
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
                    string selectSQL = "SELECT * FROM book WHERE bno = '" + BNO.Text + "';";
                    OdbcDataReader reader = null;
                    OdbcCommand command = new OdbcCommand(selectSQL, connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        reader.Read();
                        if (Convert.ToInt32(reader["stock"]) > 0)    //If ID doesnt exist
                        {
                            string insertCommand = "INSERT borrow VALUES('"+CNO.Text+
                                "','"+ BNO.Text +"', current_date(), 0000 - 00 - 00)";
                            OdbcCommand insert_command = new OdbcCommand(insertCommand, connection);
                            insert_command.ExecuteNonQuery();


                            string strStockNumber = (Convert.ToInt32(reader["stock"]) - 1).ToString();
                            string updateCommand = "UPDATE book SET stock = " + strStockNumber +
                                " \nWHERE bno='"+ BNO.Text + "'";
                            OdbcCommand update_Command = new OdbcCommand(updateCommand, connection);
                            update_Command.ExecuteNonQuery();

                            MessageBox.Show("成功借出！\n");
                        }
                        else    //If ID does exist, update it.
                        {
                            MessageBox.Show("该书已无库存！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("该书不存在！");
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
