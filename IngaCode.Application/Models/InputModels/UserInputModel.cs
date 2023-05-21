using IngaCode.Application.Extensions;
using IngaCode.Domain.Entities;

namespace IngaCode.Application.Models.InputModels
{
    public class UserInputModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Users ToEntity()
        {
            var user = new Users(this.UserName,
                                Password.GerarHashSenha()
                               );
            return user;
        }
    }
}
