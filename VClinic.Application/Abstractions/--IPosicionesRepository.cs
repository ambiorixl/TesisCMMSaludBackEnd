using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Entities.Catalogos;

namespace VClinic.Application.Abstractions
{
    public interface IPosicionesRepository
    {
        Task<Posiciones?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Posiciones>> GetByAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Posiciones posicion, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

       
        Task UpdateAsync(Posiciones posicion, CancellationToken cancellationToken = default);
        Task DeleteAsync(Posiciones posicion, CancellationToken cancellationToken = default);
                
        Task<bool> HasRelatedDataAsync(int posicion, CancellationToken cancellationToken = default);

        Task<bool> ExistsDataAsync(int id, string posicion, CancellationToken cancellationToken = default);

    }
}
