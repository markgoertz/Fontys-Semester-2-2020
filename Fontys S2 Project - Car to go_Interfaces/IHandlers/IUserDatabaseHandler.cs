using DTO_layer.Entities_DTO;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.IHandlers
{
    public interface IUserDatabaseHandler : IHandlerGeneric<UserDTO>
    {
        string Login(UserDTO user);
    }
}
