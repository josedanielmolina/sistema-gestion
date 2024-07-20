using ApiAdmin.Features.Empleados;
using DTO.DTO.ApiAdmin;
using Microsoft.AspNetCore.Mvc;

namespace ApiAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        private readonly CreateEmpleadoUseCase _createEmpleadoUseCase;

        public DomainController(
            CreateEmpleadoUseCase createEmpleadoUseCase
            )
        {
            _createEmpleadoUseCase = createEmpleadoUseCase;
        }

        [HttpPost("CreateEmpleadoUseCase")]
        public async Task<IActionResult> CreateEmpleadoUseCase(List<EmpleadoDTO> empleados)
        {
            foreach (var item in empleados)
            {
                await _createEmpleadoUseCase.Execute(item);
            }

            return Ok();
        }
    }
}
