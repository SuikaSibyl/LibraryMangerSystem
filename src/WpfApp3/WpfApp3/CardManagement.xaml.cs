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
    /// CardManagement.xaml 的交互逻辑
    /// </summary>
    public partial class CardManagement : Page
    {
        public CardManagement()
        {
            InitializeComponent();
        }

        string connectionString = "Dsn=test;uid=root";
        private void BuildCard(object sender, RoutedEventArgs e)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                try
                {
                    string selectSQL = "SELECT * FROM card WHERE cno = '" + Cid.Text + "';";
                    OdbcDataReader reader = null;
                    OdbcCommand command = new OdbcCommand(selectSQL, connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.HasRows == false)    //If ID doesnt exist
                    {
                        string insertCommand = "INSERT INTO card VALUES('";
                        insertCommand += Cid.Text + "','" + Name.Text + "','" + Department.Text + "','" + Type.Text + "')";
                        OdbcCommand insert_command = new OdbcCommand(insertCommand, connection);
                        insert_command.ExecuteNonQuery();
                        MessageBox.Show("成功注册！\n");
                    }
                    else    //If ID does exist, update it.
                    {
                        MessageBox.Show("该卡号已经注册！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateCard(object sender, RoutedEventArgs e)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                try
                {
                    string selectSQL = "SELECT * FROM card WHERE cno = '" + Cid.Text + "';";
                    OdbcDataReader reader = null;
                    OdbcCommand command = new OdbcCommand(selectSQL, connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.HasRows == true)    //If ID doesnt exist
                    {
                        string updateCommand = "UPDATE card SET\n";
                        updateCommand +=
                            "cno ='" + Cid.Text + "'," +
                            "name ='" + Name.Text + "'," +
                            "department ='" + Department.Text + "'," +
                            "type ='" + Type.Text + "'\n" +
                            "WHERE cno='" + Cid.Text + "'";
                        string updateLog = "成功更改！\ncid=" + Cid.Text + "\n\n";
                        updateLog += "name: " + reader["name"].ToString() + " -> " + Name.Text + "\n";
                        updateLog += "department: " + reader["department"].ToString() + " -> " + Department.Text + "\n";
                        updateLog += "type: " + reader["type"].ToString() + " -> " + Type.Text + "\n";
                        OdbcCommand insert_command = new OdbcCommand(updateCommand, connection);
                        insert_command.ExecuteNonQuery();
                        MessageBox.Show(updateLog);
                    }
                    else    //If ID does exist, update it.
                    {
                        MessageBox.Show("该卡号不存在！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteCard(object sender, RoutedEventArgs e)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                try
                {
                    string selectSQL = "SELECT * FROM card WHERE cno = '" + Cid.Text + "';";
                    OdbcDataReader reader = null;
                    OdbcCommand command = new OdbcCommand(selectSQL, connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.HasRows == true)    //If ID doesnt exist
                    {
                        string deleteCommand = "DELETE FROM card WHERE cno = '" + Cid.Text + "'";
                        OdbcCommand insert_command = new OdbcCommand(deleteCommand, connection);
                        insert_command.ExecuteNonQuery();
                        MessageBox.Show("成功删除！");
                    }
                    else    //If ID does exist, update it.
                    {
                        MessageBox.Show("该卡号不存在！");
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
