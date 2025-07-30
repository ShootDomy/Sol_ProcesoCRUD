using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCRUD.Entidades
{
    public class Contactos
    {
        public string Con_uuid { get; set; }
        public string Con_nombre { get; set; }
        public string Con_telefono { get; set; }
        public string Con_correo { get; set; }
        public DateTime Con_fecha_nac { get; set; }
        public string Car_uuid { get; set; }
        public Boolean Con_activo { get; set; }

    }
}
