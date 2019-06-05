using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFacturadorApi.Entities.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppFacturadorApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UserManager<TbUsuarios> _UserManager;

        public LoginController(UserManager<TbUsuarios> UserManager)
        {

            _UserManager = UserManager;
        }

        [Route("Perfil")]
        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(C => C.Type == "UserID").Value;
            var user = await _UserManager.FindByIdAsync(userId);
            return new
            {
                user.NombreUsuario,
                user.IdRolNavigation.Nombre

            };
        }
    }
}