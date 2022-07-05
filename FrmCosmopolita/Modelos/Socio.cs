using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmCosmopolita.Modelos
{
    public class Socio
    {
        public int Id { get; set; }
        //DataAnnotations: son anotaciones de Entity FrameWork que imponen restricciones en el motor de bases de datos
        [Required]
        public string? Apellido_Nombre { get; set; }
        public string? Dirección { get; set; }
        public string? Teléfono { get; set; }
    }
}
