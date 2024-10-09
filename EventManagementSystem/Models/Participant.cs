using System;

namespace EventManagementSystem.Models
{
    public class Participant // Klasse Teilnehmer
    {
        public string Name { get; private set; } // Name des Teilnehmers
        public string Email { get; private set; } // E-Mail des Teilnhemers
        public string PhoneNumber { get; private set; } // Telefonnummer des Teilnehmers
        public string Address { get; private set; } // Adresse des Teilnehmers
        public DateTime RegistrationDate { get; private set; } // Registrierungsdatum des Teilnehmers

        // Konstruktor
        public Participant(string name, string email, string phoneNumber, string address, DateTime registrationDate)
        {
            SetName(name);
            SetEmail(email);
            SetPhoneNumber(phoneNumber);
            SetAddress(address);
            registrationDate = DateTime.Now; // Aktuelles Datum wird verwendet
        }

        // Setter-Methode für den Namen
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Teilnehmername darf nicht leer sein.", nameof(name));
            }

            Name = name;
        }

        // Setter-Methode für die E-Mail
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new ArgumentException("Bitte geben Sie eine gültige E-Mail-Adresse ein.", nameof(email));
            }

            Email = email;
        }

        // Setter-Methode für die Telefonnummer
        public void SetPhoneNumber(string phoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.Length < 10)
            {
                throw new ArgumentException("Die Telefonnummer muss mindestens 10 Ziffern enthalten.", nameof(phoneNumber));
            }

            PhoneNumber = phoneNumber;
        }

        // Setter-Methode für die Adresse
        public void SetAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Die Adresse darf nicht leer sein.", nameof(address));
            }

            Address = address;
        }
    }
}
