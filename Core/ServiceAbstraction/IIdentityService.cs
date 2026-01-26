using Shared.DataTransferObject.IdentityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IIdentityService
    {
      Task Register(RegisterDTO registerDTO);
Task<UserLoginTokenDTO> LogIn(LoginDTO loginDTO);
        Task<RoleDTO> AddRole(RoleDTO roleDTO);
        Task<RoleDTO> EditRole(string ID ,string Name);

    }
}
