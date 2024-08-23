using AgendaOnline.Dto;
using AgendaOnline.Models;

namespace AgendaOnline.Services.RegistrarService
{
    public interface IRegistrarInterface
    {
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usurioRegisterDto);
    }
}
