using Microsoft.AspNetCore.Mvc;
using IngaCode.Application.Interfaces;
using IngaCode.Application.Models.InputModels;

namespace IngaCode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        private readonly IProjectsService _projectsService;
        public TasksController(ITasksService tasksService, IProjectsService projectsService)
        {
            _tasksService = tasksService;
            _projectsService = projectsService;
        }


        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var produtos = await _tasksService.Get(cancellationToken);
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var produtos = await _tasksService.GetById(id, cancellationToken);
            return Ok(produtos);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskInputModel produtoInputModel, CancellationToken cancellationToken)
        {
            var projetcBanco = await _projectsService.GetById(produtoInputModel.ProjectId, cancellationToken);
            if (projetcBanco is null || produtoInputModel.ProjectId == new Guid())
                return NotFound("Projeto não encontrado");


                var result = await _tasksService.Post(produtoInputModel.ToEntity(), cancellationToken);
            return Created(string.Empty, result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(TaskInputModel produtoInputModel, CancellationToken cancellationToken)
        {
            var existe = await _tasksService.GetById(produtoInputModel.Id, cancellationToken);
            if (existe is null)
                NotFound("Task não encontrada");

            existe.Update(produtoInputModel.Name, produtoInputModel.Description, produtoInputModel.ProjectId);
            var result = await _tasksService.Put(existe, cancellationToken);
            return Created(string.Empty, result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _tasksService.Delete(id, cancellationToken);
            return Ok();
        }
    }
}
