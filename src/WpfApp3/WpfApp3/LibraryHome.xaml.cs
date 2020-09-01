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

namespace WpfApp3
{
    /// <summary>
    /// LibraryHome.xaml 的交互逻辑
    /// </summary>
    public partial class LibraryHome : Page
    {
        public LibraryHome()
        {
            InitializeComponent();
        }

        private void Button_Stock(object sender, RoutedEventArgs e)
        {
            LibraryStock library_stock = new LibraryStock();
            this.NavigationService.Navigate(library_stock);
        }

        private void Button_Query(object sender, RoutedEventArgs e)
        {
            LibraryQuery library_query = new LibraryQuery();
            this.NavigationService.Navigate(library_query);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LibraryStock library_stock = new LibraryStock();
            this.NavigationService.Navigate(library_stock);
        }

        private void Card_Management(object sender, RoutedEventArgs e)
        {
            CardManagement card_management = new CardManagement();
            this.NavigationService.Navigate(card_management);
        }

        private void Borrow_Book(object sender, RoutedEventArgs e)
        {
            BorrowBook borrow_book = new BorrowBook();
            this.NavigationService.Navigate(borrow_book);
        }

        private void Return_Book(object sender, RoutedEventArgs e)
        {
            ReturnBook return_book = new ReturnBook();
            this.NavigationService.Navigate(return_book);
        }

        private void Find_Record(object sender, RoutedEventArgs e)
        {
            FindRecord find_record = new FindRecord();
            this.NavigationService.Navigate(find_record);
        }
    }
}
