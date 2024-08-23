using AgendaOnline.Data;
using AgendaOnline.Dto;
using AgendaOnline.Models;
using AgendaOnline.Services.SenhaService;
using AgendaOnline.Services.SessaoService;

namespace AgendaOnline.Services.LoginService
{
    public class LoginService : ILoginInterface
    {
        private readonly AplicationDBContext _context;
        private readonly ISenhaInterface _senhaInterface;
        private readonly ISessaoInterface _sessaoInterface;
        public LoginService(AplicationDBContext context, ISenhaInterface senhaInterface, ISessaoInterface sessaoInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
            _sessaoInterface = sessaoInterface;
        }

        public async Task<ResponseModel<UsuarioModel>> Login(UsuarioLoginDto usuarioLoginDto)
        {
            ResponseModel < UsuarioModel > response = new ResponseModel<UsuarioModel> ();
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuarioLoginDto.Email);

                if (usuario == null)
                {
                    response.Mensagem = "Credenciais inválidas!";
                    response.Status = false;
                    return response;
                }

                if (!_senhaInterface.VerificaSenha(usuarioLoginDto.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    response.Mensagem = "Credenciais inválidas!";
                    response.Status = false;
                    return response;
                }

                //criar sessão

                _sessaoInterface.CriarSessao(usuario);

                response.Mensagem = "Usuaário Logado com Sucesso!";

                return response;


            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

       
      
    }
}
