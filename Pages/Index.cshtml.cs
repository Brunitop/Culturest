using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebAppCulturest.Pages; // Asegúrate de agregar el namespace adecuado para tus modelos

namespace WebAppCulturest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TemporalStorage _storage;

        public IndexModel(ILogger<IndexModel> logger, TemporalStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        public void OnGet()
        {
            // Lógica para manejar la solicitud GET
        }

        public IActionResult OnPostRegistrarAsistente(string nombres, string apellidos, long numeroExpediente, long eventoId)
        {
            // Lógica para registrar un nuevo asistente
            var nuevoAsistente = new Asistente
            {
                Nombres = nombres,
                Apellidos = apellidos,
                NumeroExpediente = numeroExpediente,
                EventoId = eventoId
            };

            _storage.Asistentes.Add(nuevoAsistente); // Agregar el nuevo asistente al almacenamiento temporal

            // Redirigir a la misma página después del registro
            return RedirectToPage();
        }
    }
}