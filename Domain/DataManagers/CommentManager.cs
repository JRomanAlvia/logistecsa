using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;
using Logistecsa.Infrastructure;

namespace Logistecsa.Domain.DataManagers
{
    public class CommentManager : IRepository<Comment>
    {
        readonly LogistecsaDbContext _logistecsaDbContext;
        public CommentManager(LogistecsaDbContext logistecsaDbContext)
        {
            _logistecsaDbContext = logistecsaDbContext;
        }

        void IRepository<Comment>.Add(Comment entity)
        {
            _logistecsaDbContext.Comments.Add(entity);
            _logistecsaDbContext.SaveChanges();
        }

        void IRepository<Comment>.Delete(Comment entity)
        {
            _logistecsaDbContext.Comments.Remove(entity);
            _logistecsaDbContext.SaveChanges();
        }

        Comment IRepository<Comment>.Get(int id)
        {
            return _logistecsaDbContext.Comments
                  .FirstOrDefault(e => e.Id == id);
        }

        IEnumerable<Comment> IRepository<Comment>.GetAll()
        {
            return _logistecsaDbContext.Comments.ToList();
        }

        void IRepository<Comment>.Update(Comment comment, Comment entity)
        {
            comment.Contenido = entity.Contenido;
            comment.Fecha = entity.Fecha;
            comment.UsuarioId= entity.UsuarioId;
            comment.TareaId = entity.TareaId;

            _logistecsaDbContext.SaveChanges();
        }
    }
}
