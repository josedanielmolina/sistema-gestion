using DTO.Event;
using HttpCall;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Base;
using Repository.Models;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApiAuthService _apiAuthService;

        public DomainController(IUnitOfWork unitOfWork, IApiAuthService apiAuthService)
        {
            _unitOfWork = unitOfWork;
            _apiAuthService = apiAuthService;
        }

        [HttpPost("DarAltaUsuario")]
        public async Task<IActionResult> DarAltaUsuario(RequestActivarEmpleado request)
        {
            // Crear usuario en base de datos
            var entity = new ApiAuthUsuario()
            {
                Correo = request.Correo,
                Contrasenna = "123456",
                Role = request.Cargo,
                CodigoValidacion = "123456",
                ExpiracionCodigo = DateTime.Now,
                CodigoRh = request.CodigoRH
            };

            _unitOfWork.ApiAuth_Usuario.Add(entity);    
            await _unitOfWork.SaveChangesAsync();

            // Enviar correo al usuario
            // Notificar otras apps 

            return Ok();
        }

        [HttpGet("CallMe")]
        public async Task<IActionResult> CallMe()
        {
            var @event = new RequestActivarEmpleado();
            await _apiAuthService.DarAltaUsuario(@event);
            return Ok();
        }
    }
}
