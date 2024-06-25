using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesCategoriesController : ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;

        public ImagesCategoriesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult GetImage(string fileName)
        {
            var extensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".svg" };

            foreach (var extension in extensions)
            {
                // Ruta de la imagen en el servidor
                string imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "API", "Imagenes", "Categorias", fileName + extension);
                // Verificar si la imagen existe en la carpeta Categorias
                if (System.IO.File.Exists(imagePath))
                {
                    var image = System.IO.File.OpenRead(imagePath);
                    return File(image, GetContentType(imagePath));
                }
            }
            return NotFound();
        }

        private string GetContentType(string imagePath)
        {
            // Obtener la extensión del archivo
            string extension = System.IO.Path.GetExtension(imagePath);

            // Mapeo de extensiones a tipos de contenido MIME
            switch (extension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".svg":
                    return "image/svg+xml";
                // Agrega más extensiones y tipos de contenido MIME según tus necesidades
                default:
                    return "application/octet-stream";
            }
        }
    }
}
