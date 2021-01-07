using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TableTopCatalogDemoApp.Data;
using TableTopCatalogDemoApp.WebAPI.Models.Person;

namespace TableTopCatalogDemoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private readonly TableTopDataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonController> _logger;

        public PersonController(
            TableTopDataContext context,
            IMapper mapper,
            ILogger<PersonController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PersonModel>> GetAllPersons()
        {
            var persons = await _context.Persons
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToListAsync();

            return persons.Select(_mapper.Map<PersonModel>);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<PersonModel> GetPersonById([FromRoute]int id)
        {
            var person = await _context.Persons
                .SingleOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                return null;
            }

            var personModel = _mapper.Map<PersonModel>(person);

            return personModel;
        }

        [HttpGet]
        [Route("{id}/extended")]
        public async Task<PersonModelExtended> GetPersonExtendedById([FromRoute] int id)
        {
            var person = await _context.Persons
                .Include(x => x.MemberOf)
                .ThenInclude(x => x.Role)
                .Include(x => x.MemberOf)
                .ThenInclude(x => x.Game)
                .ThenInclude(x => x.Publisher)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                return null;
            }

            var personModel = _mapper.Map<PersonModelExtended>(person);

            personModel.MemberOf = personModel.MemberOf
                .OrderBy(x => x.Game.Title)
                .ToList();

            return personModel;
        }
    }
}
