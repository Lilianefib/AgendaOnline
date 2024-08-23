using AgendaOnline.Data;
using AgendaOnline.Dto;
using AgendaOnline.Models;
using AgendaOnline.Services.SenhaService;

namespace AgendaOnline.Services.RegistrarService
{
    public class RegistrarService : IRegistrarInterface
    {
        private readonly AplicationDBContext _context;
        private readonly ISenhaInterface _senhaInterface;

        public RegistrarService(AplicationDBContext context, ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }
        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usurioRegisterDto)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();
            try
            {
                if (VerificarSeEmailExiste(usurioRegisterDto))
                {
                    response.Mensagem = "Email já cadastrado!";
                    response.Status = false;
                    return response;
                }

                _senhaInterface.CriarSenhaHash(usurioRegisterDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new UsuarioModel()
                {
                    Nome = usurioRegisterDto.Nome,
                    Sobrenome = usurioRegisterDto.Sobrenome,
                    Email = usurioRegisterDto.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                _context.Add(usuario);
                //espera salvar antes de ir para outra linha de código
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuário Cadastrado com Sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }

        }

        private bool VerificarSeEmailExiste(UsuarioRegisterDto usuarioResgisterDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuarioResgisterDto.Email);

            if (usuario == null)
            {
                return false;
            }
            return true;

        }

    }
}
