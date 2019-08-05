using Intercorp.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intercorp.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientDto>> GetAllAsync();
        int Create(ClientDto client);
        Task<ClientDto> GetByIdAsync(int id);
    }
}