using Microsoft.AspNetCore.Mvc;
using IngaCode.Application.Interfaces;
using IngaCode.Application.Models.InputModels;
using IngaCode.Application.Extensions;
using System.Security.Cryptography;

namespace IngaCode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollaboratorsController : ControllerBase
    {
        private readonly ICollaboratorsService _collaboratorService;
        public CollaboratorsController(ICollaboratorsService collaboratorService)
        {
            _collaboratorService = collaboratorService;
        }


        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var collaborators = await _collaboratorService.Get(cancellationToken);
            return Ok(collaborators);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name, CancellationToken cancellationToken)
        {
            var collaborators = await _collaboratorService.GetByName(name, cancellationToken);
            return Ok(collaborators);
        }

    }
}
