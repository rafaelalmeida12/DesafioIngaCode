using Microsoft.AspNetCore.Mvc;
using IngaCode.Application.Interfaces;
using IngaCode.Application.Models.InputModels;

namespace IngaCode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeTrackersController : ControllerBase
    {
        private readonly ITimeTrackersService _timeTrackersService;
        private readonly ITasksService _tasksService;
        public TimeTrackersController(ITimeTrackersService timeTrackersService, ITasksService tasksService)
        {
            _timeTrackersService = timeTrackersService;
            _tasksService = tasksService;

        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var produtos = await _timeTrackersService.Get(cancellationToken);
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var produtos = await _timeTrackersService.GetById(id, cancellationToken);
            return Ok(produtos);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TimeTrackerInputModel timeTrackerInputModel, CancellationToken cancellationToken)
        {
            var task =  _tasksService.ObterComObjetosRelacionados(timeTrackerInputModel.TaskId, cancellationToken);
            if (task is null)
                return NotFound("Task não encontrada");


            if (timeTrackerInputModel.Validar(task))
            {
                var result = await _timeTrackersService.Post(timeTrackerInputModel.ToEntity(), cancellationToken);
                return Created(string.Empty, result);
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _timeTrackersService.Delete(id, cancellationToken);
            return Ok();
        }
    }
}
