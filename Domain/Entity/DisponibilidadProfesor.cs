
namespace Domain.Entity
{
    public enum DiaSemana
    {
        Domingo = 0, Lunes = 1, Martes = 2, Miercoles = 3, Jueves = 4, Viernes = 5, Sabado = 6
    }
    public class DisponibilidadProfesor
    {
        public int Id { get; set; }
        public DiaSemana Dia { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }


        public int ProfesorId { get; set; }
        public Profesor? Profesor { get; set; }
    }
}
