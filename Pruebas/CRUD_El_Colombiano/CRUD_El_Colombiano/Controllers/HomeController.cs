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

        public IActionResult Index(String Buscar)
        {
            var PersonasInte = from PersonasInteresada in _DBContext.PersonasInteresadas select PersonasInteresada;

            if (!String.IsNullOrEmpty(Buscar))
            {
                PersonasInte = PersonasInte.Where(s => s.Nombre!.Contains(Buscar));

                return View(PersonasInte);
            }

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
            PersonasInteresada oPersonas = _DBContext.PersonasInteresadas.Include(c => c.ProyectoDeInteresNavigation).Where(e => e.Id == idPersonaInt).FirstOrDefault();   

            return View(oPersonas);
        }

        [HttpPost]
        public IActionResult Eliminar(PersonasInteresada oPersonas)
        {
            _DBContext.PersonasInteresadas.Remove(oPersonas);    
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Ver_Proyectos()
        {
            List<Proyecto> Lista = _DBContext.Proyectos.ToList();
            return View(Lista);
        }

        [HttpGet]
        public IActionResult ProyectoInteDetalle(int idPersonaInt)
        {
            ProyectoVM oProyectoVM = new ProyectoVM()
            {
                oProyecto = new Proyecto()
                
            };

            if (idPersonaInt != 0)
            {
                oProyectoVM.oProyecto = _DBContext.Proyectos.Find(idPersonaInt);
            }


            return View(oProyectoVM);
        }

        [HttpPost]
        public IActionResult ProyectoInteDetalle(ProyectoVM oProyectoVM)
        {
            if (oProyectoVM.oProyecto.Codigo == 0)
            {
                _DBContext.Proyectos.Add(oProyectoVM.oProyecto);
            }
            else
            {
                _DBContext.Proyectos.Update(oProyectoVM.oProyecto);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Ver_Proyectos", "Home");
        }

        [HttpGet]
        public IActionResult EliminarProyecto(int idPersonaInt)
        {
            Proyecto oProyectos = _DBContext.Proyectos.Where(e => e.Codigo == idPersonaInt).FirstOrDefault();

            return View(oProyectos);
        }

        [HttpPost]
        public IActionResult EliminarProyecto(Proyecto oProyectos)
        {
            _DBContext.Proyectos.Remove(oProyectos);
            _DBContext.SaveChanges();

            return RedirectToAction("Ver_Proyectos", "Home");
        }

        
    }
}