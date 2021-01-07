using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TableTopCatalogDemoApp.Data;
using TableTopCatalogDemoApp.WebAPI.Models.Publisher;

namespace TableTopCatalogDemoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PublisherController : ControllerBase
    {
        private readonly TableTopDataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(
            TableTopDataContext context,
            IMapper mapper,
            ILogger<PublisherController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PublisherModel>> GetAllPublishers()
        {
            var publishers = await _context.Publishers
                .OrderBy(x => x.Title)
                .ToListAsync();

            return publishers.Select(_mapper.Map<PublisherModel>);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<PublisherModel> GetPublisherById([FromRoute] int id)
        {
            var publisher = await _context.Publishers
                .SingleOrDefaultAsync(x => x.Id == id);

            if (publisher == null)
            {
                return null;
            }

            var publisherModel = _mapper.Map<PublisherModel>(publisher);

            return publisherModel;
        }

        [HttpGet]
        [Route("{id}/extended")]
        public async Task<PublisherModelExtended> GetPublisherExtendedById([FromRoute] int id)
        {
            var publisher = await _context.Publishers
                .Include(x => x.Games)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (publisher == null)
            {
                return null;
            }

            var publisherModel = _mapper.Map<PublisherModelExtended>(publisher);

            return publisherModel;
        }
    }
}
