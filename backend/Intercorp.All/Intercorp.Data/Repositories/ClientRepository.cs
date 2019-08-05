using Intercorp.Domain.Interfaces;
using Intercorp.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intercorp.Data.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public int Create(ClientDto client)
        {
            GetDbFactory().Save(client);
            return client.ClientId;
        }

        public async Task<List<ClientDto>> GetAllAsync()
        {
            var query = @"SELECT * FROM [dbo].[Client]";
            return await GetDbFactory().FetchAsync<ClientDto>(query);
        }

        public async Task<ClientDto> GetByIdAsync(int id)
        {
            var query = @"SELECT * FROM [dbo].[Client] WHERE ClientId = @0";
            return await GetDbFactory().SingleOrDefaultAsync<ClientDto>(query, id);
        }
    }
}
