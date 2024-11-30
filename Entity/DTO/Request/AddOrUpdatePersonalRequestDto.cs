using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO.Request
{
    public class AddOrUpdatePersonalRequestDto
    {
        public int IdPersonal { get; set; }
        public string TipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
