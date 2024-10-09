using System;
using System.Collections.Generic;

namespace EventManagementSystem.Models
{
    public class WorkshopEvent : Event // Klasse Workshop-Event erbt von der Klasse Event
    {
        public string Instructor { get; private set; } // Kursleiter
        public List<string> RequiredMaterials { get; private set; } // Benötigte Materialien als Liste

        // Konstruktor
        public WorkshopEvent(string name, DateTime date, string location, int maxParticipants, string description, bool isOnline, string instructor, List<string> requiredMaterials)
            : base(name, date, location, maxParticipants, description, isOnline)
        {
            SetInstructor(instructor);
            SetRequiredMaterials(requiredMaterials);
        }

        // Setter für den Kursleiter mit Validierung
        private void SetInstructor(string instructor)
        {
            if (string.IsNullOrWhiteSpace(instructor))
            {
                throw new ArgumentException("Der Kursleiter darf nicht leer sein.", nameof(instructor));
            }

            Instructor = instructor;
        }

        // Setter für benötigte Materialien mit Validierung
        private void SetRequiredMaterials(List<string> requiredMaterials)
        {
            if (requiredMaterials == null || requiredMaterials.Count == 0)
            {
                throw new ArgumentException("Die Liste der benötigten Materialien darf nicht leer sein.", nameof(requiredMaterials));
            }

            RequiredMaterials = new List<string>(requiredMaterials); // Erstellen einer neuen Liste für die Materialien
        }
    }
}
