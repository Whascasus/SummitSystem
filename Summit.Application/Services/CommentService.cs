using Summit.Domain.Entities;
using Summit.Domain.Interfaces;
using System.Net.Http.Json;


namespace Summit.Application.Services
{
    public class CommentService : ICommentService
    {
        private static List<Comment> comments = new List<Comment>();
        public async Task FillData()
        {
            
            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetFromJsonAsync<List<Comment>>("https://jsonplaceholder.typicode.com/comments");
                if (response != null)
                    comments = response;
            }
            catch (Exception ex) {
                throw new Exception("Error no hay datos", ex);
            }
        }

        public List<Comment> GetData(int n)
        {
            if (n <= 0)
            {
                throw new Exception("El numero debe ser mayor a 1");
            }

            return comments.OrderBy(x => x.Email).Take(n).ToList();
        }

        public Comment SerchData(int id, string domain)
        {
            if (id > 0)
            {
                var comment = comments.FirstOrDefault(x => x.Id == id);
                if (comment == null)
                {
                    throw new KeyNotFoundException("No se encontro un comentarion con el Id proporcionado");
                }
                return comment;
            }
            else if (!string.IsNullOrEmpty(domain) != null)
            {
                var comment = comments.FirstOrDefault(c => c.Email.EndsWith(domain, StringComparison.CurrentCultureIgnoreCase));
                if (comment == null)
                {
                    throw new KeyNotFoundException("No se encontro un comentario con el dominio proporcionado");
                }
                return comment;
            }
            else {
                throw new ArgumentException("El dominio no puede ser nulo o vacio");
            }
        }
    }
}
