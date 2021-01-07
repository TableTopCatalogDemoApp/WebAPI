using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TableTopCatalogDemoApp.Data;
using TableTopCatalogDemoApp.WebAPI.Models.Game;

namespace TableTopCatalogDemoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class GameController : ControllerBase
    {
        private readonly TableTopDataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GameController> _logger;

        public GameController(
            TableTopDataContext context,
            IMapper mapper,
            ILogger<GameController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<GameModel>> GetAllGames()
        {
            var games = await _context.Games
                .OrderBy(x => x.Title)
                .ToListAsync();

            return games.Select(_mapper.Map<GameModel>);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<GameModel> GetGameById([FromRoute] int id)
        {
            var game = await _context.Games
                .SingleOrDefaultAsync(x => x.Id == id);

            if (game == null)
            {
                return null;
            }

            var gameModel = _mapper.Map<GameModel>(game);

            return gameModel;
        }

        [HttpGet]
        [Route("{id}/extended")]
        public async Task<GameModelExtended> GetGameExtendedById([FromRoute] int id)
        {
            var game = await _context.Games
                .Include(x => x.Publisher)
                .Include(x => x.TeamMembers)
                .ThenInclude(x => x.Role)
                .Include(x => x.TeamMembers)
                .ThenInclude(x => x.Person)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (game == null)
            {
                return null;
            }

            var gameModel = _mapper.Map<GameModelExtended>(game);
            
            return gameModel;
        }
    }
}
