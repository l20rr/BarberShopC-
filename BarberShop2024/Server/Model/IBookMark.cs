using BarberShop2024.Shared;

namespace BarberShop2024.Server.Model
{
    public interface IBookMark
    {
        IEnumerable<BookMark> GetAllBooks();
        BookMark GetBookById(int bookMarkId);
        Task<BookMark> AddBook(BookMark bookMark );
        BookMark UpdateBook(BookMark bookMark);
        void DeleteBook(int bookMarkId);
    }
}
