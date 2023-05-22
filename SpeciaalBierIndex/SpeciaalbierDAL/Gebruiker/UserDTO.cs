using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_InterfaceLibrary.Gebruiker
{
    public class UserDTO
    {
        public int ID { get; set; }
        public int Rol { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public string Email { get; set; }
        public DateTime Geboortedatum { get; set; }

        public UserDTO()
        {

        }

        public UserDTO(int iD, int rol, string naam, string wachtwoord, string postcode, string huisnummer, string email, DateTime geboortedatum)
        {
            ID = iD;
            Rol = rol;
            Naam = naam;
            Wachtwoord = wachtwoord;
            Postcode = postcode;
            Huisnummer = huisnummer;
            Email = email;
            Geboortedatum = geboortedatum;
        }
    }
}
