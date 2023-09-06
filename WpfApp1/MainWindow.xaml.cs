using System;
using System.Collections.Generic;
using System.Data;
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
using BookShop;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUoW unitOfWork = new UnitOfWork();
        private AddBook addBook = new AddBook();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoadDataCountries()
        {
            tableView.ItemsSource = unitOfWork.CountryRepo.Get().Select(x => new
            {
                x.Id,
                x.Name
            });
        }
        private void LoadDataBook()
        {
            tableView.ItemsSource = unitOfWork.BookRepo.Get().Select(x => new
            {
                x.Id,
                x.Name,
                x.PageNumber,
                x.PublishingDate,
                x.GenreId,
                x.PublishingId,
                x.NextBookId,
                x.PrevieBookId
            });
        }
        private void LoadDataAuthor()
        {
            tableView.ItemsSource = unitOfWork.AuthorRepo.Get().Select(x => new
            {
                x.Id,
                x.Name,
                x.Surname,
                x.Birthdate,
                x.CountryId
            });
        }
        private void LoadDataClient()
        {
            tableView.ItemsSource = unitOfWork.ClientRepo.Get().Select(x => new
            {
                x.Id,
                x.Name,
                x.Surname,
                x.Phone
            });
        }
        private void LoadDataDeferredBook()
        {
            tableView.ItemsSource = unitOfWork.DeferredBookRepo.Get().Select(x => new
            {
                x.Id,
                x.GoodsId,
                x.ClientId
            });
        }
        private void LoadDataGenre()
        {
            tableView.ItemsSource = unitOfWork.GenreRepo.Get().Select(x => new
            {
                x.Id,
                x.Name
            });
        }
        private void LoadDataGoods()
        {
            tableView.ItemsSource = unitOfWork.GoodsRepo.Get().Select(x => new
            {
                x.Id,
                x.BookId,
                x.Number,
                x.Cost,
                x.Price,
                x.Discount,
                x.WriteOffGoods
            });
        }
        private void LoadDataPublishingHouse()
        {
            tableView.ItemsSource = unitOfWork.PublishingRepo.Get().Select(x => new
            {
                x.Id,
                x.Name
            });
        }
        private void LoadDataSale()
        {
            tableView.ItemsSource = unitOfWork.SaleRepo.Get().Select(x => new
            {
                x.Id,
                x.GoodsId,
                x.ClientId
            });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CB.SelectedIndex == 0) LoadDataAuthor();
            else if (CB.SelectedIndex == 1) LoadDataBook();
            else if (CB.SelectedIndex == 2) LoadDataClient();
            else if (CB.SelectedIndex == 3) LoadDataCountries();
            else if (CB.SelectedIndex == 4) LoadDataDeferredBook();
            else if (CB.SelectedIndex == 5) LoadDataGenre();
            else if (CB.SelectedIndex == 6) LoadDataGoods();
            else if (CB.SelectedIndex == 7) LoadDataPublishingHouse();
            else if (CB.SelectedIndex == 8) LoadDataSale();
            else return;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            unitOfWork.Save();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CB.SelectedIndex == 0) { unitOfWork.AuthorRepo.Delete(tableView.SelectedIndex + 1); }
            else if (CB.SelectedIndex == 1) { unitOfWork.BookRepo.Delete(tableView.SelectedIndex + 1); }
            else if (CB.SelectedIndex == 2) { unitOfWork.ClientRepo.Delete(tableView.SelectedIndex + 1); }
            else if (CB.SelectedIndex == 3) { unitOfWork.CountryRepo.Delete(tableView.SelectedIndex + 1); }
            else if (CB.SelectedIndex == 4) { unitOfWork.DeferredBookRepo.Delete(tableView.SelectedIndex + 1); }
            else if (CB.SelectedIndex == 5) { unitOfWork.GenreRepo.Delete(tableView.SelectedIndex + 1); }
            else if (CB.SelectedIndex == 6) { unitOfWork.GoodsRepo.Delete(tableView.SelectedIndex + 1); }
            else if (CB.SelectedIndex == 7) { unitOfWork.PublishingRepo.Delete(tableView.SelectedIndex + 1); }
            else if (CB.SelectedIndex == 8) { unitOfWork.SaleRepo.Delete(tableView.SelectedIndex + 1); }
            else return;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            addBook.Show();
        }
        private void FindBookByName()
        {
            tableView.ItemsSource = unitOfWork.BookRepo.Get().Where(x => x.Name == TB.Text).Select(x => new
            {
                x.Id,
                x.Name,
                x.PageNumber,
                x.PublishingDate,
                x.GenreId,
                x.PublishingId,
                x.NextBookId,
                x.PrevieBookId
            });
        }
        private void FindBookByAuthor()
        {
            try
            {
                var item = unitOfWork.AuthorRepo.Get().Where(x => x.Name + " " + x.Surname == TB.Text).Select(x => new
                {
                    x.Id
                });
                int id = item.First().Id;
                tableView.ItemsSource = unitOfWork.BookRepo.Get().Where(x => x.AuthorId == id).Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.PageNumber,
                    x.PublishingDate,
                    x.GenreId,
                    x.PublishingId,
                    x.NextBookId,
                    x.PrevieBookId
                });
            }
            catch(Exception ex) { return; }
        }
        private void FindBookByGenre()
        {
            try
            {
                var item = unitOfWork.GenreRepo.Get().Where(x => x.Name == TB.Text).Select(x => new
            {
                x.Id
            });
            int id = item.First().Id;
            tableView.ItemsSource = unitOfWork.BookRepo.Get().Where(x => x.GenreId == id).Select(x => new
            {
                x.Id,
                x.Name,
                x.PageNumber,
                x.PublishingDate,
                x.GenreId,
                x.PublishingId,
                x.NextBookId,
                x.PrevieBookId
            });
            }
            catch (Exception ex) { return; }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (CB1.SelectedIndex == 0 && TB.Text != "") FindBookByName();
            else if (CB1.SelectedIndex == 1 && TB.Text != "") FindBookByAuthor();
            else if (CB1.SelectedIndex == 2 && TB.Text != "") FindBookByGenre();
            else return;
        }
    }
}
