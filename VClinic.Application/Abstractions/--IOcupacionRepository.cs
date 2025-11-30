using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Entities.Catalogos;

namespace VClinic.Application.Abstractions
{
    public interface IOcupacionRepository
    {
        Task<Ocupacion?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Ocupacion>> GetByAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Ocupacion ocupacion, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

       
        Task UpdateAsync(Ocupacion ocupacion, CancellationToken cancellationToken = default);
        Task DeleteAsync(Ocupacion ocupacion, CancellationToken cancellationToken = default);
                
        Task<bool> HasRelatedDataAsync(int ocupacion, CancellationToken cancellationToken = default);

        Task<bool> ExistsDataAsync(int id, string ocupacion, CancellationToken cancellationToken = default);

    }
}
