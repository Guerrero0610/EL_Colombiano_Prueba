using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD_El_Colombiano.Models.ViewModels
{
    public class ClienteVM
    {
        public PersonasInteresada oPersona { get; set; } 

        public List<SelectListItem> oLista { get; set; }
    } 
}
