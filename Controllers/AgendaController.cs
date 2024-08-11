using AgendaOnline.Data;
using AgendaOnline.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace AgendaOnline.Controllers
{
    public class AgendaController : Controller
    {

        readonly private AplicationDBContext _db;
        public AgendaController(AplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<AgendaModel> itens = _db.Agenda;
            return View(itens);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            AgendaModel agenda = _db.Agenda.FirstOrDefault(x => x.Id == id);

            if (agenda == null)
            {
                return NotFound();
            }
            return View(agenda);
        }

        [HttpGet]

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            AgendaModel agenda = _db.Agenda.FirstOrDefault(x => x.Id == id);

            if (agenda == null)
            {
                return NotFound();
            }
            return View(agenda);

        }
        [HttpGet]
        public IActionResult Exportar()
        {
            var dados = GetDados();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dados, "Dados Agenda");

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spredsheetml.sheet", "Agenda.xls");
                }

            }
        }

        private DataTable GetDados()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Dados Agenda";
            dataTable.Columns.Add("Nome", typeof(string));
            dataTable.Columns.Add("Gerência", typeof(string));
            dataTable.Columns.Add("Ramal", typeof(string));
            dataTable.Columns.Add("Usuario", typeof(string));
            dataTable.Columns.Add("Função", typeof(string));
            dataTable.Columns.Add("E-mail", typeof (string));

            var dados = _db.Agenda.ToList();

            if(dados.Count > 0)
            {
                dados.ForEach( agenda =>
                {
                    dataTable.Rows.Add(agenda.Name, agenda.Gerencia, agenda.Ramal, agenda.Usuario, agenda.Funcao, agenda.Email);
                });
            }

            return dataTable;
        }

        [HttpPost]
        public IActionResult Cadastrar(AgendaModel agenda)
        {
            if (ModelState.IsValid)
            {
                _db.Agenda.Add(agenda);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpPost]
        public IActionResult Editar(AgendaModel agenda)
        {
            if (ModelState.IsValid)
            {
                _db.Agenda.Update(agenda);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição!";
            return View(agenda);

        }

        [HttpPost]
        public IActionResult Excluir(AgendaModel agenda)
        {
          if(agenda == null)
            {
                return NotFound();
            }

          _db.Agenda.Remove(agenda);
          _db.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}
