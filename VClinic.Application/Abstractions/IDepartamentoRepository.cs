using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Entities.Catalogos;

namespace VClinic.Application.Abstractions
{
    public interface IDepartamentoRepository
    {
        Task<Departamentos?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Departamentos>> GetByAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Departamentos departamento, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

       
        Task UpdateAsync(Departamentos departamento, CancellationToken cancellationToken = default);
        Task DeleteAsync(Departamentos departamento, CancellationToken cancellationToken = default);
                
        Task<bool> HasRelatedDataAsync(int departamento, CancellationToken cancellationToken = default);

        Task<bool> ExistsDataAsync(int id, string departamento, CancellationToken cancellationToken = default);

    }
}
