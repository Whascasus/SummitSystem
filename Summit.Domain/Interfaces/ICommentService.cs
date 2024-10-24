using Summit.Domain.Entities;

namespace Summit.Domain.Interfaces
{
    public interface ICommentService
    {
        Task FillData();
        List<Comment> GetData(int n);
        Comment SerchData(int id, string domain);
    }
}
