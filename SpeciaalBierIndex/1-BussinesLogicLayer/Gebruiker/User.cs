using _2_InterfaceLibrary.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_BussinesLogicLayer.Gebruiker
{
    public class User
    {
        public int ID { get; set; }
        public int Rol { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public string Email { get; set; }
        public DateTime Geboortedatum { get; set; }

        public User()
        {

        }

        public User(int iD, int rol, string naam, string wachtwoord, string postcode, string huisnummer, string email, DateTime geboortedatum)
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

        public User(UserDTO dto)
        {
            this.ID = dto.ID;
            this.Rol = dto.Rol;
            this.Naam = dto.Naam;
            this.Wachtwoord = dto.Wachtwoord;
            this.Postcode = dto.Postcode;
            this.Huisnummer = dto.Huisnummer;
            this.Email = dto.Email;
            this.Geboortedatum = dto.Geboortedatum;
        }

        public UserDTO GetDTO()
        {
            return new UserDTO(ID, Rol, Naam, Wachtwoord, Postcode, Huisnummer, Email, Geboortedatum);
        }
    }
}
