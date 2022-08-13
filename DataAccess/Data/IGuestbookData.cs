using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IGuestbookData
    {
        Task DeleteComment(int id);
        Task EditComment(GuestbookModel guestbook);
        Task<GuestbookModel?> ReadComment(int id);
        Task<IEnumerable<GuestbookModel>> ReadComments();
        Task WriteComment(GuestbookModel guestbook);
    }
}