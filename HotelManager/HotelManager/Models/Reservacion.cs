using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManager.Models
{
    public class Reservacion
    {


        public string ID { get; set; }
        public string IDCliente { get; set; }
        public int Room { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }
        public int Estatus { get; set; }
        public Reservacion()
        {
            ID = string.Empty;
            IDCliente = string.Empty;
            Room = 0;
            Estatus = 0;
            Entrada = DateTime.Now;
            Salida = DateTime.Now.AddDays(1);
        }




        public bool ValidaReservacion()
        {
            if (Estatus == 1)
            {
                if (Salida.Date < DateTime.Today && Entrada.Date > DateTime.Today)
                {
                    Estatus = 0;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

