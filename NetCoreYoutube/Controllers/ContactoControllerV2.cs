using Microsoft.AspNetCore.Mvc;
using NetCoreYoutube.Datos;
using NetCoreYoutube.Models;

namespace NetCoreYoutube.Controllers
{
    [ApiController]
    [Route("contacto/v2")]
    public class ContactoControllerV2 : ControllerBase
    {
        ContactoDatos _contactoDatos = new ContactoDatos();

        [HttpGet]
        public ActionResult<List<ContactoModel>> listarContacto()
            {
            var listaCreada = new List<ContactoModel>()
            {
                new ContactoModel()
                {
                    IdContacto = 1,
                    Nombre = "Albert",
                    Telefono = "3214152465",
                    Correo = "Albert@gmail.com"
                },
                new ContactoModel()
                {
                    IdContacto = 2,
                    Nombre = "Simon",
                    Telefono = "3203214785",
                    Correo = "Simont@gmail.com"
                },
                new ContactoModel()
                {
                    IdContacto = 3,
                    Nombre = "Mia",
                    Telefono = "3152468597",
                    Correo = "Mia@gmail.com"
                },
                new ContactoModel()
                {
                    IdContacto = 4,
                    Nombre = "Rose",
                    Telefono = "3051426578",
                    Correo = "Rose@gmail.com"
                }
            };
            return listaCreada;
        }

        [HttpGet]
        [Route("{_id}")]
        public ActionResult<ContactoModel> listarPorId(int _id)
        {
            var ContactById = _contactoDatos.Obtener(1);
            if (ContactById.Nombre is null)
            {
                return NotFound();
            }

            return ContactById;
        }
    }
}