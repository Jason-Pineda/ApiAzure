using Microsoft.AspNetCore.Mvc;
using NetCoreYoutube.Datos;
using NetCoreYoutube.Models;
using System.Security.Cryptography;

namespace NetCoreYoutube.Controllers
{
    [ApiController]
    [Route("contacto")]
    public class ContactoController : ControllerBase
    {
        ContactoDatos _contactoDatos = new ContactoDatos();

        [HttpGet]
        public ActionResult<List<ContactoModel>> listarContacto()
        {
            var listaContacts = _contactoDatos.Listar();
            return listaContacts;
        }

        [HttpGet]
        [Route("{_id}")]
        public ActionResult<ContactoModel> listarPorId(int _id)
        {
            var ContactById = _contactoDatos.Obtener(_id);
            if(ContactById.Nombre is null) {
                return NotFound();
            }

            return ContactById;
        }

        [HttpPost]
        public ActionResult guardarCliente(ContactoModel _contactoModel)
        {
            var rpta = _contactoDatos.Guardar(_contactoModel);
            return Created("", _contactoModel);
        }

        [HttpPut]
        public ActionResult modificarCliente(ContactoModel _contactoModel)
        {
            var ContactById = _contactoDatos.Obtener(_contactoModel.IdContacto);
            if (ContactById.Nombre is null)
            {
                return NotFound();
            }

            var rpta = _contactoDatos.Editar(_contactoModel);
            return Ok(rpta);
        }

        [HttpDelete]

        public ActionResult eliminarCliente(int _id)
        {
            var ContactById = _contactoDatos.Obtener(_id);
            if (ContactById.Nombre is null)
            {
                return NotFound();
            }

            var rpta = _contactoDatos.Eliminar(_id);
            return NoContent();
        }
    }
}
