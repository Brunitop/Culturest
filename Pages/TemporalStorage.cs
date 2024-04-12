public class TemporalStorage
{
    public List<Evento> Eventos { get; set; }
    public List<Asistente> Asistentes { get; set; }

    public TemporalStorage()
    {
        Eventos = new List<Evento>();
        Asistentes = new List<Asistente>();
    }
}