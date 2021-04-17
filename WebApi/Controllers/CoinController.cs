using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/coins")]
    public class CoinController : Controller
    {
        private readonly ILoggerService _logger;
        private readonly ICoinService _coinService;

        public CoinController(ILoggerService logger, ICoinService coinService)
        {
            _logger = logger;
            _coinService = coinService;
        }
        
        // Get: api/coins/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoinReadDto>>> GetAllCoins()
        {
            var coins = await _coinService.GetAllCoinsAsync();
            _logger.LogInfo($"Returned all coins from database.");
                
            return Ok(coins);
        }
        
        // Get: api/coins/{id}
        [HttpGet("{id:int}", Name = "GetCoinById")]
        public async Task<ActionResult<CoinReadDto>> GetCoinById(int id)
        {
            var coin = await _coinService.GetCoinByIdAsync(id);

            if (coin == null)
            {
                _logger.LogError($"Owner with id: {id.ToString()}, hasn't been found in db.");
                return NotFound();
            }
                
            _logger.LogInfo($"Returned owner with id: {id.ToString()}");
            return Ok(coin);
        }
        
        // Post: api/coins/
        [HttpPost]
        public async Task<ActionResult<CoinReadDto>> CreateCoin([FromBody] CoinCreateDto coin)
        {
            if (coin == null)
            {
                _logger.LogError("Coin object sent from client is null.");
                return BadRequest("Coin object is null");
            }

            var createdCoin = await _coinService.CreateCoinAsync(coin);

            return CreatedAtRoute(nameof(GetCoinById), new {id = createdCoin.ID}, createdCoin);
        }
        
        // Put: api/coins/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCoin(int id, [FromBody] CoinUpdateDto coin)
        {
            if (coin == null)
            {
                _logger.LogError("Coin object sent from client is null.");
                return BadRequest("Coin object is null");
            }
                
            if (coin.ID != id)
            {
                _logger.LogError("Coin object sent from client doesn't match with provided resource ID.");
                return BadRequest("Coin object doesn't match provided resource ID");
            }

            var coinEntity = await _coinService.UpdateCoinAsync(id, coin);

            if (coinEntity == null)
            {
                _logger.LogError($"Coin with id: {id.ToString()}, hasn't been found in db.");
                return NotFound();
            }

            return NoContent();
        }
        
        // Delete: api/coins/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCoin(int id)
        {
            var coin = await _coinService.DeleteCoinAsync(id);
            if (coin == null)
            {
                _logger.LogError($"Coin with id: {id.ToString()}, hasn't been found in db.");
                return NotFound();
            }
                
            return NoContent();
        }
    }
}