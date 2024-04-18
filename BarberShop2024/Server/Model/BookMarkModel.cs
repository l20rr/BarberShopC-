using BarberShop2024.Server.Data;
using BarberShop2024.Shared;

namespace BarberShop2024.Server.Model
{
    public class BookMarkModel : IBookMark
    {
        private readonly DataContext _context;

        public BookMarkModel(DataContext context)
        {
            _context = context;
        }
        public async Task<BookMark> AddBook(BookMark bookMark)
        {
            var result = await _context.BookMarks.AddAsync(bookMark);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteBook(int bookMarkId)
        {
            var foundBook = _context.BookMarks.FirstOrDefault(e => e.BookMarkId == bookMarkId);
            if (foundBook == null) return;

            _context.BookMarks.Remove(foundBook);
            _context.SaveChanges();
        }

        public IEnumerable<BookMark> GetAllBooks()
        {
            return _context.BookMarks;
        }

        public BookMark GetBookById(int bookMarkId)
        {
            return _context.BookMarks.FirstOrDefault(c => c.BookMarkId == bookMarkId);
        }

        public BookMark UpdateBook(int bookMarkId, BookMark bookMark)
        {
            var foundBook= _context.BookMarks.FirstOrDefault(e => e.BookMarkId == bookMark.BookMarkId);

            if (foundBook != null)
            {

                foundBook.DateBook = bookMark.DateBook;
             


                _context.SaveChangesAsync();

                return foundBook;
            }

            return null;
        }
    }
}
