using Domain.Repositories;
using Services.Abstractions.DTO;
using Services.Abstractions.Services;
using Services.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UsersService : IUsersService
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper = ObjectMapperBusiness.Instance;
        public UsersService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<UserDTO> Get(string id)
        {
            return mapper.Mapper.Map<UserDTO>(await uow.UsersRepository.Get(id));
        }
    }
}
