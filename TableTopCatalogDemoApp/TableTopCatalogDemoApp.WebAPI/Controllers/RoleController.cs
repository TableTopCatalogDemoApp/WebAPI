using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TableTopCatalogDemoApp.Data;
using TableTopCatalogDemoApp.WebAPI.Models.Role;

namespace TableTopCatalogDemoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RoleController : ControllerBase
    {
        private readonly TableTopDataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleController> _logger;

        public RoleController(
            TableTopDataContext context,
            IMapper mapper,
            ILogger<RoleController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<RoleModel>> GetAllRoles()
        {
            var roles = await _context.Roles
                .OrderBy(x => x.Title)
                .ToListAsync();

            return roles.Select(_mapper.Map<RoleModel>);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<RoleModel> GetRoleById([FromRoute] int id)
        {
            var role = await _context.Roles
                .SingleOrDefaultAsync(x => x.Id == id);

            if (role == null)
            {
                return null;
            }

            var roleModel = _mapper.Map<RoleModel>(role);

            return roleModel;
        }

        [HttpGet]
        [Route("{id}/extended")]
        public async Task<RoleModelExtended> GetGameExtendedById([FromRoute] int id)
        {
            var role = await _context.Roles
                .Include(x => x.Members)
                .ThenInclude(x => x.Game)
                .Include(x => x.Members)
                .ThenInclude(x => x.Person)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (role == null)
            {
                return null;
            }

            var roleModel = _mapper.Map<RoleModelExtended>(role);

            return roleModel;
        }
    }
}
