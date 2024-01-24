using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;
using Logistecsa.Infrastructure;

namespace Logistecsa.Domain.DataManagers
{
    public class UserManager : IRepository<User>
    {
        readonly LogistecsaDbContext _logistecsaDbContext;
        public UserManager(LogistecsaDbContext logistecsaDbContext)
        {
            _logistecsaDbContext = logistecsaDbContext;
        }

        void IRepository<User>.Add(User entity)
        {
            _logistecsaDbContext.Users.Add(entity);
            _logistecsaDbContext.SaveChanges();
        }

        void IRepository<User>.Delete(User entity)
        {
            _logistecsaDbContext.Users.Remove(entity);
            _logistecsaDbContext.SaveChanges();
        }

        User IRepository<User>.Get(int id)
        {
            return _logistecsaDbContext.Users
                  .FirstOrDefault(e => e.Id == id);
        }

        IEnumerable<User> IRepository<User>.GetAll()
        {
            return _logistecsaDbContext.Users.ToList();
        }

        void IRepository<User>.Update(User user, User entity)
        {
            user.Nombre = entity.Nombre;
            user.Apellido = entity.Apellido;
            user.CorreoElectronico= entity.CorreoElectronico;
            user.Contrasena = entity.Contrasena;
            user.Rol = entity.Rol;

            _logistecsaDbContext.SaveChanges();
        }
    }
}
