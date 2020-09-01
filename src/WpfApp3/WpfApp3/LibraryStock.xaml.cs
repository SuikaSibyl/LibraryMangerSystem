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

using System.IO;
using Microsoft.Win32;
using System.Data;
using System.Data.Odbc;

namespace WpfApp3
{
    /// <summary>
    /// LibraryStock.xaml 的交互逻辑
    /// </summary>
    public partial class LibraryStock : Page
    {
        //WPF: Initialize
        //---------------
        public LibraryStock()
        {
            InitializeComponent();
        }
        //My: Insertion
        //---------------
        string connectionString = "Dsn=test;uid=root";
        public void InsertRow(string insertSQL)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                // The insertSQL string contains a SQL statement that
                // inserts a new row in the source table.
                OdbcCommand command = new OdbcCommand(insertSQL, connection);
                // Open the connection and execute the insert command.
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
        }
        private void Button_Insert(object sender, RoutedEventArgs e)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                string selectSQL = "SELECT * FROM book WHERE bno = '" + BookID.Text + "';";
                OdbcDataReader reader = null;
                OdbcCommand command = new OdbcCommand(selectSQL, connection);
                // Open the connection and execute the select command.
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.HasRows == false)    //If ID doesnt exist
                    {
                        string insertCommand = "INSERT INTO book VALUES('";
                        insertCommand += BookID.Text + "','" + Category.Text + "','" + BookName.Text + "','" +
                            Publish.Text + "'," + BookYear.Text + ",'" + BookWriter.Text + "'," + BookPrice.Text +
                             "," + BookNumber.Text + "," + BookNumber.Text + ")";
                        InsertRow(insertCommand);
                        MessageBox.Show("成功入库！\n");
                    }
                    else    //If ID does exist, update it.
                    {
                        MessageBox.Show("已有记录");
                        reader.Read();
                        string update_log = "成功更改!\nbno = "+ BookID.Text + "\n\n";
                        string strBookNumber = (Convert.ToInt32(BookNumber.Text) + Convert.ToInt32(reader["total"])).ToString();
                        string strStockNumber = (Convert.ToInt32(BookNumber.Text) + Convert.ToInt32(reader["stock"])).ToString();
                        string updateCommand = "UPDATE book SET ";
                        if (reader["category"].ToString() != Category.Text)
                        {
                            updateCommand += "category = '" + Category.Text + "',";
                            update_log += "category: " + reader["category"] + " -> " + Category.Text + "\n";
                        }
                        if (reader["title"].ToString() != BookName.Text)
                        {
                            updateCommand += "title = '" + BookName.Text + "',";
                            update_log += "title: " + reader["title"] + " -> " + BookName.Text + "\n";
                        }
                        if (reader["press"].ToString() != Publish.Text)
                        {
                            updateCommand += "press = '" + Publish.Text + "',";
                            update_log += "press: " + reader["press"] + " -> " + Publish.Text + "\n";
                        }
                        if (reader["year"].ToString() != BookYear.Text)
                        {
                            updateCommand += "year = " + BookYear.Text + ",";
                            update_log += "year: " + reader["year"] + " -> " + BookYear.Text + "\n";
                        }
                        if (reader["author"].ToString() != BookWriter.Text)
                        {
                            updateCommand += "author = '" + BookWriter.Text + "',";
                            update_log += "author: " + reader["author"] + " -> " + BookWriter.Text + "\n";
                        }
                        if (reader["price"].ToString() != BookPrice.Text)
                        {
                            updateCommand += "price = " + BookPrice.Text + ",";
                            update_log += "price: " + reader["price"] + " -> " + BookPrice.Text + "\n";
                        }
                        update_log += "total: " + reader["total"] + " -> " + strBookNumber + "\n";
                        update_log += "stock: " + reader["stock"] + " -> " + strStockNumber + "\n";
                        updateCommand += "total = " + strBookNumber + "," +
                            "stock = " + strStockNumber +'\n'+
                            "WHERE bno='" + BookID.Text + "'";
                        OdbcCommand update_command = new OdbcCommand(updateCommand, connection);
                        update_command.ExecuteNonQuery();
                        MessageBox.Show(update_log);
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
        private void InsertOneBook(string[] arrTemp)
        {
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                string selectSQL = "SELECT * FROM book WHERE bno = '" + arrTemp[0].Trim() + "';";
                OdbcDataReader reader = null;
                OdbcCommand command = new OdbcCommand(selectSQL, connection);
                // Open the connection and execute the select command.
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.HasRows == false)    //If ID doesnt exist
                    {
                        string insertCommand = "INSERT INTO book VALUES('";
                        insertCommand += arrTemp[0].Trim() + "','" + arrTemp[1].Trim() + "','" + arrTemp[2].Trim() + "','" +
                            arrTemp[3].Trim() + "'," + arrTemp[4].Trim() + ",'" + arrTemp[5].Trim() + "'," + arrTemp[6].Trim() +
                             "," + arrTemp[7].Trim() + "," + arrTemp[7].Trim() + ")";
                        InsertRow(insertCommand);
                        MessageBox.Show("成功入库！\n");
                    }
                    else    //If ID does exist, update it.
                    {
                        MessageBox.Show("已有记录");
                        reader.Read();
                        string update_log = "成功更改!\nbno = " + arrTemp[0].Trim() + "\n\n";
                        string strBookNumber = (Convert.ToInt32(arrTemp[7].Trim()) + Convert.ToInt32(reader["total"])).ToString();
                        string strStockNumber = (Convert.ToInt32(arrTemp[7].Trim()) + Convert.ToInt32(reader["stock"])).ToString();
                        string updateCommand = "UPDATE book SET ";
                        if (reader["category"].ToString() != arrTemp[1].Trim())
                        {
                            updateCommand += "category = '" + arrTemp[1].Trim() + "',";
                            update_log += "category: " + reader["category"] + " -> " + arrTemp[1].Trim() + "\n";
                        }
                        if (reader["title"].ToString() != arrTemp[2].Trim())
                        {
                            updateCommand += "title = '" + arrTemp[2].Trim() + "',";
                            update_log += "title: " + reader["title"] + " -> " + arrTemp[2].Trim() + "\n";
                        }
                        if (reader["press"].ToString() != arrTemp[3].Trim())
                        {
                            updateCommand += "press = '" + arrTemp[3].Trim() + "',";
                            update_log += "press: " + reader["press"] + " -> " + arrTemp[3].Trim() + "\n";
                        }
                        if (reader["year"].ToString() != arrTemp[4].Trim())
                        {
                            updateCommand += "year = " + arrTemp[4].Trim() + ",";
                            update_log += "year: " + reader["year"] + " -> " + arrTemp[4].Trim() + "\n";
                        }
                        if (reader["author"].ToString() != arrTemp[5].Trim())
                        {
                            updateCommand += "author = '" + arrTemp[5].Trim() + "',";
                            update_log += "author: " + reader["author"] + " -> " + arrTemp[5].Trim() + "\n";
                        }
                        if (reader["price"].ToString() != arrTemp[6].Trim())
                        {
                            updateCommand += "price = " + arrTemp[6].Trim() + ",";
                            update_log += "price: " + reader["price"] + " -> " + arrTemp[6].Trim() + "\n";
                        }
                        update_log += "total: " + reader["total"] + " -> " + strBookNumber + "\n";
                        update_log += "stock: " + reader["stock"] + " -> " + strStockNumber + "\n";
                        updateCommand += "total = " + strBookNumber + "," +
                            "stock = " + strStockNumber + '\n' +
                            "WHERE bno='" + arrTemp[0] + "'";
                        OdbcCommand update_command = new OdbcCommand(updateCommand, connection);
                        update_command.ExecuteNonQuery();
                        MessageBox.Show(update_log);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                Filename.Text = filename;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Filename.Text;
            try
            {

                if (File.Exists(filePath))
                {
                    string[] readText = File.ReadAllLines(filePath);
                    for(int i=0;i<readText.Length;i++)
                    {
                        MessageBox.Show(readText[i]);
                        string[] arrTemp = readText[i].Split(',');
                        InsertOneBook(arrTemp);
                    }
                }
                else
                {
                    MessageBox.Show("文件不存在");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         }
    }
}
