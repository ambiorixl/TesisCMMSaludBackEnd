using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Entities.Catalogos;

namespace VClinic.Application.Abstractions
{
    public interface IProfesionRepository
    {
        Task<Profesion?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Profesion>> GetByAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Profesion profesion, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

       
        Task UpdateAsync(Profesion profesion, CancellationToken cancellationToken = default);
        Task DeleteAsync(Profesion profesion, CancellationToken cancellationToken = default);
                
        Task<bool> HasRelatedDataAsync(int profesion, CancellationToken cancellationToken = default);

        Task<bool> ExistsDataAsync(int id, string profesion, CancellationToken cancellationToken = default);

    }
}
