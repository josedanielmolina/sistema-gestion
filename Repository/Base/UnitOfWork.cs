using Microsoft.EntityFrameworkCore.Storage;
using Repository.Models;

namespace Repository.Base
{
    public interface IUnitOfWork
    {
        IRepository<ApiAdminEmpleado> ApiAdmin_EmpleadoRepository { get; set; }
        IRepository<ApiAuthUsuario> ApiAuth_Usuario { get; set; }

        IDbContextTransaction BeginTransaction();
        void Dispose();
        Task SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<ApiAdminEmpleado> ApiAdmin_EmpleadoRepository { get; set; }
        public IRepository<ApiAuthUsuario> ApiAuth_Usuario { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ApiAdmin_EmpleadoRepository = new Repository<ApiAdminEmpleado>(context);
            ApiAuth_Usuario = new Repository<ApiAuthUsuario>(context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
