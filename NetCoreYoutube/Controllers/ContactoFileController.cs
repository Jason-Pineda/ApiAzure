using Microsoft.AspNetCore.Mvc;
using NetCoreYoutube.Datos;
using NetCoreYoutube.Models;
using System.Text;

namespace NetCoreYoutube.Controllers
{
    [ApiController]
    [Route("contacto-file")]
    public class ContactoFileController : ControllerBase
    {
        ContactoDatos _contactoDatos = new ContactoDatos();
        [HttpPost]
        public IActionResult UploadFileContacts([FromForm] IFormFile file)
        {
            file = Request.Form.Files.FirstOrDefault();
            var cont = 0;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    string[] result;
                    result = reader.ReadLine().Split(',');
                    var contact = new ContactoModel
                    {
                        Nombre = result[0],
                        Telefono = result[1],
                        Correo = result[2]
                    };
                    if (cont > 0)
                    {
                        var rpta = _contactoDatos.Guardar(contact);
                    }
                    cont++;
                }
            }        
            return Ok($"Received file {file.FileName} with size in bytes {file.Length}");
        }
    }
}
