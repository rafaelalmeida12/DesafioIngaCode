using Microsoft.AspNetCore.Mvc;
using IngaCode.Application.Interfaces;
using IngaCode.Application.Models.InputModels;
using IngaCode.Application.Extensions;
using System.Security.Cryptography;
using IngaCode.Domain.Entities;
using IngaCode.Application.Services;

namespace IngaCode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly ICollaboratorsService _CollaboratorsService;
        public UsersController(IUsersService usersService, ICollaboratorsService collaboratorsService)
        {
            _usersService = usersService;
            _CollaboratorsService = collaboratorsService;
        }


        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var produtos = await _usersService.Get(cancellationToken);
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var produtos = await _usersService.GetById(id, cancellationToken);
            return Ok(produtos);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserInputModel userInputModel, CancellationToken cancellationToken)
        {
            if (await _usersService.GetByName(userInputModel.UserName, cancellationToken))
                return BadRequest("Usuário já cadastrado!");

            var users = await _usersService.Post(userInputModel.ToEntity(), cancellationToken);
            var collaborats = await _CollaboratorsService.Post(new Collaborators(users.UserName,users), cancellationToken);
            return Created(string.Empty, users);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserInputModel userInputModel, CancellationToken cancellationToken)
        {
            var existe = await _usersService.GetById(userInputModel.Id, cancellationToken);
            if (existe is null)
                NotFound("User não encontrado");


            existe.Update(userInputModel.UserName, userInputModel.Password);
            var result = await _usersService.Put(existe, cancellationToken);
            return Created(string.Empty, result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _usersService.Delete(id, cancellationToken);
            return Ok();
        }
    }
}
