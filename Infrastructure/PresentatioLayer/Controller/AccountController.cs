using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.IdentityDTO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentatioLayer.Controller
{
    [ApiController]

    [Route("api/[controller]")]
    public class AccountController(IServiceManager service) : ControllerBase
    {

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO RegisterData)
        {
            if (ModelState.IsValid)
            {
                await service.identityservice.Register(RegisterData);
                return Ok(RegisterData);
            }
            else { return BadRequest(); }
        }

        [HttpPost("Login")]
        
        public async Task<IActionResult> login(LoginDTO LoginData)
        {


            var result =await  service.identityservice.LogIn(LoginData);
            return Ok(result);
        }
        [HttpPost("Add Role To User")]
        [Authorize ( Roles ="SuperAdmin")]
        public async Task<IActionResult> AddRole(RoleDTO RoleData) { 
        
        var resule= await service.identityservice.AddRole(RoleData);
           // RoleDTO role = new RoleDTO { userName = RoleData.userName, Role=RoleData.Role };
        return Ok(resule);
        }


        [HttpPut ("Edit Role")]
        [Authorize (Roles="SuperAdmin")]
        public async Task<IActionResult> editrole(string id, string name)
        {
            var result = await service.identityservice.EditRole(id, name);
                return Ok(result);
        }
    }
}
