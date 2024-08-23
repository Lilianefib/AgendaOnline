using AgendaOnline.Dto;
using AgendaOnline.Services.LoginService;
using AgendaOnline.Services.RegistrarService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AgendaOnline.Controllers
{
    public class RegistrarController : Controller
    {
        private readonly IRegistrarInterface _registrarInterface;
        public RegistrarController(IRegistrarInterface registrarInterface)
        {
            _registrarInterface = registrarInterface;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegisterDto usuarioRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _registrarInterface.RegistrarUsuario(usuarioRegisterDto);
                if (usuario != null)
                {
                    TempData["MensagemSucesso"] = usuario.Mensagem;

                }
                else
                {
                    TempData["MensagemErro"] = usuario.Mensagem;

                    return View(usuarioRegisterDto);

                }
                return RedirectToAction("Registrar");
            }
            else
            {
                return View(usuarioRegisterDto);
            }
        }
    }
}
