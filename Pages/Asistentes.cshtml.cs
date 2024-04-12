using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebAppCulturest.Pages;

namespace WebAppCulturest.Pages
{
    public class AsistentesModel : PageModel
    {
        private readonly ILogger<AsistentesModel> _logger;
        private readonly TemporalStorage _storage;

        public AsistentesModel(ILogger<AsistentesModel> logger, TemporalStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        public List<Asistente> Asistentes => _storage.Asistentes;

        public IActionResult OnPostExportar()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Asistente>));
                var stringBuilder = new StringBuilder();
                using (var stringWriter = new StringWriter(stringBuilder))
                {
                    xmlSerializer.Serialize(stringWriter, Asistentes);
                }

                var xmlString = stringBuilder.ToString();
                var fileName = "asistentes.xml";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                System.IO.File.WriteAllText(filePath, xmlString);

                // Devolver el archivo XML como descarga
                return File(filePath, "application/xml", fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al exportar los asistentes como archivo XML");
                return Page();
            }
        }
    }
}