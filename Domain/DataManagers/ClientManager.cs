using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;
using Logistecsa.Infrastructure;

namespace Logistecsa.Domain.DataManagers
{
    public class ClientManager : IRepository<Client>
    {
        readonly LogistecsaDbContext _logistecsaDbContext;
        public ClientManager(LogistecsaDbContext logistecsaDbContext)
        {
            _logistecsaDbContext = logistecsaDbContext;
        }

        void IRepository<Client>.Add(Client entity)
        {
            _logistecsaDbContext.Clients.Add(entity);
            _logistecsaDbContext.SaveChanges();
        }

        void IRepository<Client>.Delete(Client entity)
        {
            _logistecsaDbContext.Clients.Remove(entity);
            _logistecsaDbContext.SaveChanges();
        }

        Client IRepository<Client>.Get(int id)
        {
            return _logistecsaDbContext.Clients
                  .FirstOrDefault(e => e.Id == id);
        }

        IEnumerable<Client> IRepository<Client>.GetAll()
        {
            return _logistecsaDbContext.Clients.ToList();
        }

        void IRepository<Client>.Update(Client client, Client entity)
        {
            client.Nombre = entity.Nombre;
            client.Direccion = entity.Direccion;
            client.Telefono= entity.Telefono;
            client.CorreoElectronico = entity.CorreoElectronico;

            _logistecsaDbContext.SaveChanges();
        }
    }
}
