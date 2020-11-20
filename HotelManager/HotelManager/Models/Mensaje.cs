using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManager.Models
{
    public class Mensaje
    {
        public string ID { get; set; }
        public string Msg { get; set; }
        public int Tipo { get; set; }
        public string IDHuesped { get; set; }
        public int Estatus { get; set; }
        public Mensaje()
        {
            ID = string.Empty;
            Msg = string.Empty;
            Tipo = 0;
            IDHuesped = string.Empty;
            Estatus = 1;
        }


    }
}
