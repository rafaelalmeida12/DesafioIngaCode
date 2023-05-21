using Microsoft.AspNetCore.Mvc;
using IngaCode.Application.Interfaces;
using IngaCode.Application.Models.InputModels;

namespace IngaCode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectsService _projectService;
        public ProjectController(IProjectsService projectService)
        {
            _projectService = projectService;
        }


        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var produtos = await _projectService.Get(cancellationToken);
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var produtos = await _projectService.GetById(id, cancellationToken);
            return Ok(produtos);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectInputModel produtoInputModel, CancellationToken cancellationToken)
        {
            var result = await _projectService.Post(produtoInputModel.ToEntity(), cancellationToken);
            return Created(string.Empty, result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProjectInputModel produtoInputModel, CancellationToken cancellationToken)
        {
            var existe = await _projectService.GetById(produtoInputModel.Id, cancellationToken);
            if (existe is null)
                NotFound("Projeto não encontrado");

            existe.Update(produtoInputModel.Name);
            var result = await _projectService.Put(existe, cancellationToken);
            return Created(string.Empty, result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _projectService.Delete(id, cancellationToken);
            return Ok();
        }
    }
}
