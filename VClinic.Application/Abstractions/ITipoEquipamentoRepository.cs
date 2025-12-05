using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Entities.Catalogos;

namespace VClinic.Application.Abstractions
{
    public interface ITipoEquipamentoRepository
    {
        Task<TipoEquipamento?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<TipoEquipamento>> GetByAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(TipoEquipamento tipoEquipo, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

       
        Task UpdateAsync(TipoEquipamento tipoEquipo, CancellationToken cancellationToken = default);
        Task DeleteAsync(TipoEquipamento tipoEquipo, CancellationToken cancellationToken = default);
                
        Task<bool> HasRelatedDataAsync(int tipoEquipo, CancellationToken cancellationToken = default);

        Task<bool> ExistsDataAsync(int id, string tipoEquipo, CancellationToken cancellationToken = default);

    }
}
