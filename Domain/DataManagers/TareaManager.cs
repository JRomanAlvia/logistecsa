using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;
using Logistecsa.Infrastructure;

namespace Logistecsa.Domain.DataManagers
{
    public class TareaManager : IRepository<Tarea>
    {
        readonly LogistecsaDbContext _logistecsaDbContext;
        public TareaManager(LogistecsaDbContext logistecsaDbContext)
        {
            _logistecsaDbContext = logistecsaDbContext;
        }

        void IRepository<Tarea>.Add(Tarea entity)
        {
            _logistecsaDbContext.Tareas.Add(entity);
            _logistecsaDbContext.SaveChanges();
        }

        void IRepository<Tarea>.Delete(Tarea entity)
        {
            _logistecsaDbContext.Tareas.Remove(entity);
            _logistecsaDbContext.SaveChanges();
        }

        Tarea IRepository<Tarea>.Get(int id)
        {
            return _logistecsaDbContext.Tareas
                  .FirstOrDefault(e => e.Id == id);
        }

        IEnumerable<Tarea> IRepository<Tarea>.GetAll()
        {
            return _logistecsaDbContext.Tareas.ToList();
        }

        void IRepository<Tarea>.Update(Tarea tarea, Tarea entity)
        {
            tarea.Titulo = entity.Titulo;
            tarea.Descripcion = entity.Descripcion;
            tarea.Estado= entity.Estado;
            tarea.FechaVencimiento = entity.FechaVencimiento;

            _logistecsaDbContext.SaveChanges();
        }
    }
}
