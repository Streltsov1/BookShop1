using BookShop;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private IUoW unitOfWork = new UnitOfWork();
        public AddBook()
        {
            InitializeComponent();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Book book = new Book();
            book.Name = name.Text;
            book.PageNumber = int.Parse(pageNumber.Text);
            book.PublishingDate = DateTime.Now;
            book.AuthorId = int.Parse(authorId.Text);
            book.GenreId = int.Parse(genreId.Text);
            book.PublishingId = int.Parse(publishingId.Text);
            if (nextBookId.Text == "")
                book.NextBookId = null;
            else book.NextBookId = int.Parse(nextBookId.Text);
            if (previeBookId.Text == "")
                book.PrevieBookId = null;
            else book.PrevieBookId = int.Parse(previeBookId.Text);
            unitOfWork.BookRepo.Insert(book);
            unitOfWork.Save();
        }
    }
}
