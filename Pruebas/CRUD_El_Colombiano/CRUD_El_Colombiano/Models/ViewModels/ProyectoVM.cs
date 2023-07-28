using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD_El_Colombiano.Models.ViewModels
{
    public class ProyectoVM
    {
        public Proyecto oProyecto { get; set; }

        public List<SelectListItem> oListaCons { get; set; }
    }
}
