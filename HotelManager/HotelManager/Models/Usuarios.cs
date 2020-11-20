using System;
using System.Collections.Generic;
using System.Text;
using HotelManager.Models;
namespace HotelManager.Models
{
    public class Usuarios
    {
        public string ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Msg { get; set; }
        public int Res { get; set; }
        public int Tipo { get; set; }
        public Usuarios()
        {
            ID = string.Empty;
            Login = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Msg = 0;
            Res = 0;
            Tipo = 1;
        }


    }
}