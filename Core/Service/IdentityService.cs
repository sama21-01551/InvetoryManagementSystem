using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared.DataTransferObject.IdentityDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service
{
    public class IdentityService(UserManager<ApplicationUser> _userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager) : IIdentityService
    {
        public async Task<UserLoginTokenDTO> LogIn(LoginDTO loginDTO)
        {
            //ApplicationUser loginuser = new ApplicationUser
            //{
            //    UserName = loginDTO.UserName
            //};
            var find = await _userManager.FindByNameAsync(loginDTO.UserName);
            bool isexist = await _userManager.CheckPasswordAsync(find, loginDTO.Password);
            if (isexist == true)
            {

                List<Claim> userclaime = new List<Claim>();

                var roles = await _userManager.GetRolesAsync(find);
                foreach (var role in roles) { userclaime.Add(new Claim(ClaimTypes.Role, role)); };

                var securiytkey = configuration.GetSection("JWTToken")["securiytkey"];
                var securitykeyinbytes = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securiytkey));

                SigningCredentials signature = new SigningCredentials(securitykeyinbytes, SecurityAlgorithms.HmacSha256);
                userclaime.Add(new Claim(ClaimTypes.Name, find.UserName));
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: configuration["JWTToken:Issuer"],
                    audience: configuration["JWTToken:Audience"],
                    claims: userclaime,
                    signingCredentials: signature,
                      expires: DateTime.UtcNow.AddMinutes(60)
                    );
                var x = new JwtSecurityTokenHandler().WriteToken(token);
                return new UserLoginTokenDTO
                {
                    Token = x,
                    Name = find.UserName,
                };
            }
            else { return new UserLoginTokenDTO(); }
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,

            };
            await _userManager.CreateAsync(user, registerDTO.Password);
        }

        public async Task<RoleDTO> AddRole(RoleDTO roleDTO)
        {
            // var user= new ApplicationUser { UserName=roleDTO.userName, Id=roleDTO.ID};  
            string[] roles = { "Admin", "SuperAdmin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {

                    await roleManager.CreateAsync(new IdentityRole(roleDTO.Role));
                }
            }

            var getuser = await _userManager.FindByIdAsync(roleDTO.ID);

            if (getuser != null)
            {
                if (!roles.Contains(roleDTO.Role)) { Console.WriteLine("The Role Doesnot Exist"); }

                //var therolefromuser = new IdentityRole("f");
                //await roleManager.CreateAsync(therolefromuser);


                var theadmin = await _userManager.AddToRoleAsync(getuser, roleDTO.Role);
                return roleDTO = new RoleDTO
                {
                    userName = roleDTO.userName,
                    Role = roleDTO.Role,
                    ID = roleDTO.ID,
                };
            }

            else
            {
                return roleDTO = new RoleDTO
                {
                    userName = "",
                    Role = ""
                };
            }
        }

        public async Task<RoleDTO> EditRole(string ID, string Role)
        {
            var theuser = await _userManager.FindByIdAsync(ID); //theuser 

            var Rolesforuser = await _userManager.GetRolesAsync(theuser);// rrolename
            string[] Roles = { "Admin", "SuperAdmin", "User" };
            
            if (Rolesforuser.Count > 0)
            {

                foreach (var role in Rolesforuser)
                {
                    if (await roleManager.RoleExistsAsync(Role))
                    {
                        await _userManager.RemoveFromRoleAsync(theuser, role);
                        await _userManager.AddToRoleAsync(theuser, Role);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(theuser, role);
                        foreach (var rolee in Roles)
                        {
                            if (await roleManager.RoleExistsAsync(Role))
                            {
                                await _userManager.AddToRoleAsync(theuser, Role);
                            }
                        }

                    }
                }
                //   var identity = roleManager.DeleteAsync(new IdentityRole(identity));
                // var deletrole = roleManager.DeleteAsync(IdentityRole(roleid);

            }
            foreach(var role in Roles)
            {
                if( await roleManager.RoleExistsAsync(role)) { 
            await roleManager.CreateAsync(new IdentityRole(Role));
                var user = await _userManager.AddToRoleAsync(theuser, Role);
                
                }
            }
             
                var roledto = new RoleDTO
                {

                    Role = Role,
                    ID = ID,
                };
                return roledto;
            
        } } 
    }


