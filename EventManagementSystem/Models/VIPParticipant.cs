using System;

namespace EventManagementSystem.Models
{
    public class VIPParticipant : Participant // Klasse VIP-Teilnehmer erbt von der Klasse Teilnhemer
    {
        public string VIPLevel { get; private set; } // VIP-Stufe
        public string Benefits { get; private set; } // Besondere Vorteile

        // Konstruktor
        public VIPParticipant(string name, string email, string phoneNumber, string address, DateTime registrationDate, string vipLevel, string benefits)
            : base(name, email, phoneNumber, address, DateTime.Now)
        {
            SetVIPLevel(vipLevel);
            SetBenefits(benefits);
        }

        // Setter für die VIP-Stufe mit Validierung
        private void SetVIPLevel(string vipLevel)
        {
            if (string.IsNullOrWhiteSpace(vipLevel))
            {
                throw new ArgumentException("Die VIP-Stufe darf nicht leer sein.", nameof(vipLevel));
            }

            VIPLevel = vipLevel;
        }

        // Setter für die besonderen Vorteile mit Validierung
        private void SetBenefits(string benefits)
        {
            if (string.IsNullOrWhiteSpace(benefits))
            {
                throw new ArgumentException("Die besonderen Vorteile dürfen nicht leer sein.", nameof(benefits));
            }

            Benefits = benefits;
        }
    }
}
