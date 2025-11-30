using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Entities.Catalogos;

namespace VClinic.Application.Abstractions
{
    public interface IGeneroRepository
    {
        Task<Genero?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Genero>> GetByAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Genero genero, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

       
        Task UpdateAsync(Genero genero, CancellationToken cancellationToken = default);
        Task DeleteAsync(Genero genero, CancellationToken cancellationToken = default);
                
        Task<bool> HasRelatedDataAsync(int genero, CancellationToken cancellationToken = default);

        Task<bool> ExistsDataAsync(int id, string genero, CancellationToken cancellationToken = default);

    }
}
