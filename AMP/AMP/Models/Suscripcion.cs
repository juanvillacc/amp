using System;
using System.Collections.Generic;
using System.Text;

namespace AMP.Models
{
    public class Suscripcion
    {
        public int id_usuario_suscripcion { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }
        public int id_ciudad { get; set; }
        public bool estado { get; set; }

    }
}
