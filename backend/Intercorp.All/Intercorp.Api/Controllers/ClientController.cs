using Intercorp.Domain.Interfaces;
using Intercorp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Intercorp.Api.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientRepository clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpGet]
        [Route("~/api/clients/")]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            try
            {
                var clients = await clientRepository.GetAllAsync();
                return Request.CreateResponse(HttpStatusCode.OK, clients);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("~/api/clients/kpideclientes")]
        public async Task<HttpResponseMessage> GetKpiClientsAsync()
        {
            try
            {
                var clients = await clientRepository.GetAllAsync();
                double avgAge = clients.Average(e => e.Age);
                double stdDev = GetStandardDeviation(clients.Select(x => x.Age).ToList());

                return Request.CreateResponse(HttpStatusCode.OK, new { average = avgAge, standardDeviation = stdDev });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("~/api/clients/")]
        public async Task<HttpResponseMessage> Create([FromBody]ClientDto model)
        {
            try
            {
                if (model == null) return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Model");
                if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Model");            
                var id = clientRepository.Create(model);
                var client = await clientRepository.GetByIdAsync(id);
                return Request.CreateResponse(HttpStatusCode.Created, client);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private double GetStandardDeviation(List<int> ages)
        {
            double mean = ages.Sum() / ages.Count();
            
            var squares_query =
                from int value in ages
                select (value - mean) * (value - mean);
            double sum_of_squares = squares_query.Sum();

            return Math.Sqrt(sum_of_squares / (ages.Count() - 1));
        }
    }
}
