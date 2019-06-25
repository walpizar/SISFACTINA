using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Seguridad;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AppFacturadorApi.Controllers
{

    [Route("api/")]
    public class RegistroController : ControllerBase
    {
        IService<TbPersona> _per;
       // IService<TbUsuarios> _usuario;
        private UserManager<TbUsuarios> _UserManager;
        private SignInManager<TbUsuarios> _singleManager;
        private readonly ApplicationSettings _appSettings;

        public RegistroController(IService<TbPersona> per, UserManager<TbUsuarios> UserManager, SignInManager<TbUsuarios> singleManager, IOptions<ApplicationSettings> appSettings)
        {
            _per = per;
            _UserManager = UserManager;
            _singleManager = singleManager;
            _appSettings = appSettings.Value;
        }



        //[HttpGet]
        //[Route("Registro")]
        //public ActionResult<IEnumerable<TbRoles>> Registro()
        //{

        //    var lista = _usuario.ConsultarTodos();


        //    if (lista.Count() == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(lista);
        //}
        // POST api/<controller>
        [HttpPost]
        [Route("Registro")]
        public async Task<object> Registro([FromBody]TbUsuarios usuario)
        {
            //TbEmpresa empresa = new TbEmpresa();
            //empresa.Id = usuario.IdEmpresa;
            //empresa = _empre.ConsultarById(empresa);



            //TbRoles rol = new TbRoles();
            //rol.IdRol = usuario.IdRol;
            //rol = _combos.ConsultarById(rol);

            //var persona = new TbPersona();
            //persona.Identificacion = usuario.Id;
            //persona.TipoId = usuario.TipoId;
            //persona.Telefono = 89568017;
            //persona.CodigoPaisTel = "+506";
            //persona.Nombre = "Kevin";
            //persona.CorreoElectronico = usuario.Email;


            //usuario.PhoneNumber = persona.Telefono.ToString();
            usuario.Estado = true;
            usuario.FechaCrea = DateTime.Now;
            usuario.FechaUltMod = DateTime.Now;
            usuario.UsuarioCrea = Environment.UserName;
            usuario.UsuarioUltMod = Environment.UserName;
         //   usuario.UserName = usuario.NombreUsuario;
            //usuario.TbPersona = persona;

            //usuario.IdRolNavigation = rol;

            //usuario.IdNavigation = empresa;

            try
            {
                //bool agregado = _per.Agregar(persona);
                //if (agregado)
                //{
                var result = await _UserManager.CreateAsync(usuario, usuario.Contraseña);
                //await _UserManager.AddToRoleAsync(usuario, usuario.IdRol.ToString());
                return Ok(result);
                //}
                //return BadRequest();

            }
            catch (Exception ex)
            {
                // _per.Eliminar(persona);
                return StatusCode(500);
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _UserManager.FindByNameAsync(model.NombreUsuario);
            if (user != null && await _UserManager.CheckPasswordAsync(user, model.Contraseña))
            {
                //Obtener el Rol del Usuario
               // var role = await _UserManager.GetRolesAsync(user);
               IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        //new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Nombre de Usuario o Contraseña incorrectos" });
        }

    }

}