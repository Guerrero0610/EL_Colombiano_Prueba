using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_El_Colombiano.Models;
using CRUD_El_Colombiano.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_El_Colombiano.Controllers
{
    public class HomeController : Controller
    {
        private readonly BdproyectosContext _DBContext;

        public HomeController(BdproyectosContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<PersonasInteresada> Lista = _DBContext.PersonasInteresadas.Include(c => c.ProyectoDeInteresNavigation).ToList();
            return View(Lista);
        }

        [HttpGet]
        public IActionResult PersonaInteDetalle(int idPersonaInt)
        {
            ClienteVM oPersonaVM = new ClienteVM(){
                oPersona = new PersonasInteresada(),
                oLista = _DBContext.Proyectos.Select(proyec => new SelectListItem()
                {
                    Text = proyec.Codigo.ToString(),
                    Value = proyec.Codigo.ToString()

                }).ToList()

            };

            if(idPersonaInt != 0)
            {
                oPersonaVM.oPersona = _DBContext.PersonasInteresadas.Find(idPersonaInt);
            }
           

             return View(oPersonaVM);
        }

        [HttpPost]
        public IActionResult PersonaInteDetalle(ClienteVM oPersonaVM)
        {
            if(oPersonaVM.oPersona.Id == 0)
            {
                _DBContext.PersonasInteresadas.Add(oPersonaVM.oPersona);
            }
            else
            {
                _DBContext.PersonasInteresadas.Update(oPersonaVM.oPersona); 
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int idPersonaInt)
        {
            PersonasInteresada oPersona = _DBContext.PersonasInteresadas.Include(c => c.ProyectoDeInteresNavigation).Where(e => e.Id == idPersonaInt).FirstOrDefault();   

            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Eliminar(PersonasInteresada oPersona)
        {
            _DBContext.PersonasInteresadas.Remove(oPersona);    
            _DBContext.SaveChanges(); 
            
            return View(oPersona);
        }
    }
}