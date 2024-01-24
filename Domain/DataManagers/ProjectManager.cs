using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;
using Logistecsa.Infrastructure;

namespace Logistecsa.Domain.DataManagers
{
    public class ProjectManager : IRepository<Project>
    {
        readonly LogistecsaDbContext _logistecsaDbContext;
        public ProjectManager(LogistecsaDbContext logistecsaDbContext)
        {
            _logistecsaDbContext = logistecsaDbContext;
        }

        void IRepository<Project>.Add(Project entity)
        {
            _logistecsaDbContext.Projects.Add(entity);
            _logistecsaDbContext.SaveChanges();
        }

        void IRepository<Project>.Delete(Project entity)
        {
            _logistecsaDbContext.Projects.Remove(entity);
            _logistecsaDbContext.SaveChanges();
        }

        Project IRepository<Project>.Get(int id)
        {
            return _logistecsaDbContext.Projects
                  .FirstOrDefault(e => e.Id == id);
        }

        IEnumerable<Project> IRepository<Project>.GetAll()
        {
            return _logistecsaDbContext.Projects.ToList();
        }

        void IRepository<Project>.Update(Project project, Project entity)
        {
            project.Nombre = entity.Nombre;
            project.Descripcion = entity.Descripcion;
            project.FechaInicio = entity.FechaInicio;
            project.FechaFin = entity.FechaFin;

            _logistecsaDbContext.SaveChanges();
        }
    }
}
