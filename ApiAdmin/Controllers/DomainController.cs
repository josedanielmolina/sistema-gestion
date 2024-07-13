using AutoMapper;
using DTO.DTO.ApiAdmin;
using DTO.Event;
using HttpCall;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Base;
using Repository.Models;

namespace ApiAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IApiAuthService _apiAuthService;

        public DomainController(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IApiAuthService apiAuthService
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _apiAuthService = apiAuthService;
        }

        [HttpPost("CreateEmpleado")]
        public async Task<IActionResult> CreateEmpleado(EmpleadoDTO empleado)
        {
            // Crear nuevo empleado
            var entity = _mapper.Map<ApiAdminEmpleado>(empleado);
            entity.CodigoRh = Guid.NewGuid().ToString();    

            _unitOfWork.ApiAdmin_EmpleadoRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();

            // Notificar ApiAuth nuevo empleado
            var eventDarAltaEmpleado = new RequestActivarEmpleado()
            {
                Correo = empleado.Correo,
                Cargo = empleado.Cargo,
                CodigoRH = entity.CodigoRh
            };
            await _apiAuthService.DarAltaUsuario(eventDarAltaEmpleado);

            return Ok();
        }
    }
}
