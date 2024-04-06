using System.ComponentModel.DataAnnotations;
namespace L01P02_2019TM602.Models
{
    public class datos

    {
        [Key]
        public int Id { get; set; }
        public string? facultad { get; set; }
    }

    public class materias

    {
        [Key]
        public int Id { get; set; }
        public string? materia { get; set; }
        public int unidades_valorativas { get; set; }
        public string? estado { get; set; }
    }

    public class departamentos

    {
        [Key]
        public int Id { get; set; }
        public string? departamento { get; set; }
    }

    public class alumnos

    {
        [Key]
        public int Id { get; set; }
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public int dui { get; set; }
        public int estado { get; set; }
    }
}
