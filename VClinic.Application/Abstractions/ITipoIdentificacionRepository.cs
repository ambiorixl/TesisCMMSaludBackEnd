using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Entities.Catalogos;

namespace VClinic.Application.Abstractions
{
    public interface ITipoIdentificacionRepository
    {
        Task<TipoIdentificacion?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<TipoIdentificacion>> GetByAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(TipoIdentificacion tipoIdentificacion, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

       
        Task UpdateAsync(TipoIdentificacion tipoIdentificacion, CancellationToken cancellationToken = default);
        Task DeleteAsync(TipoIdentificacion tipoIdentificacion, CancellationToken cancellationToken = default);
                
        Task<bool> HasRelatedDataAsync(int idTipoIdentificacion, CancellationToken cancellationToken = default);

        Task<bool> ExistsDataAsync(int idTipoIdentificacion, string nombre, CancellationToken cancellationToken = default);

    }
}
