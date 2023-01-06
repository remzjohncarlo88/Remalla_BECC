using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;

namespace BEC_Remalla.Controllers
{
    /// <summary>
    /// BEC Controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class BECController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        /// <summary>
        /// BEC Controller constructor
        /// </summary>
        /// <param name="repository">IRepositoryWrapper object</param>
        public BECController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Basic Get
        /// </summary>
        /// <returns>Peronal Data</returns>
        [HttpGet("~/BasicGet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public string Get()
        {
            var result = new
            {
                name = "test",
                phone = "test"
            };
            
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// GetQuoteRequest
        /// </summary>
        /// <param name="numPassengers">number of passengers</param>
        /// <returns>Listings per given passenger price ordered by total price</returns>
        [HttpGet("~/GetQuoteRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Listing> GetQuoteRequest(int numPassengers)
        {
            var listings = _repository.QuoteRepo.GetQuotesByNumPassengers(numPassengers);

            return listings;
        }

        /// <summary>
        /// Get city by given IP address
        /// </summary>
        /// <returns>city location</returns>
        [HttpGet("~/GetCityByIPAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public string GetCityByIPAddress()
        {
            string hostName = Dns.GetHostName();
            string city = _repository.LocationRepo.GetCity(Dns.GetHostByName(hostName).AddressList[2].ToString());

            return city;
        }
    }
}
