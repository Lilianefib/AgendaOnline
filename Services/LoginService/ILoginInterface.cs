using AgendaOnline.Dto;
using AgendaOnline.Models;

namespace AgendaOnline.Services.LoginService
{
    public interface ILoginInterface
    {
        Task<ResponseModel<UsuarioModel>> Login(UsuarioLoginDto usuarioLoginDto);
    
    }
}
