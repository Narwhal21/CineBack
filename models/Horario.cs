using System;

public class Horario
{
    public static int nextId = 1;
    public int Id { get; private set; }
    public string HoraInicio { get; set; }
    public string HoraFin { get; set; }
    public int Dia { get; set; }

    public Horario(string horaInicio, string horaFin, int dia)
    {
        Id = nextId++;
        HoraInicio = horaInicio;
        HoraFin = horaFin;
        Dia = dia;
    }
}
