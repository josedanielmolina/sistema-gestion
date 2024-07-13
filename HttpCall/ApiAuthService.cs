using DTO.Event;

namespace HttpCall
{
    public interface IApiAuthService
    {
        Task<bool> DarAltaUsuario(RequestActivarEmpleado @event);
    }

    public class ApiAuthService : HttpBase, IApiAuthService
    {
        public ApiAuthService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<bool> DarAltaUsuario(RequestActivarEmpleado @event)
        {
            await Post<RequestActivarEmpleado, object>("DarAltaUsuario", @event);
            return true;
        }
    }
}
