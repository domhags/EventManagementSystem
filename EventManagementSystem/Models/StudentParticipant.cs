using System;

namespace EventManagementSystem.Models
{
    public class StudentParticipant : Participant // Klasse Studierende erbt von Teilnehmer
    {
        public string University { get; private set; } // Hochschule
        public string StudentId { get; private set; } // Matrikelnummer

        // Konstruktor
        public StudentParticipant(string name, string email, string phoneNumber, string address, DateTime registrationDate, string university, string studentId)
            : base(name, email, phoneNumber, address, DateTime.Now) // Aktuelles Datum
        {
            SetUniversity(university);
            SetStudentId(studentId);
        }

        // Setter für die Hochschule mit Validierung
        private void SetUniversity(string university)
        {
            if (string.IsNullOrWhiteSpace(university))
            {
                throw new ArgumentException("Die Hochschule darf nicht leer sein.", nameof(university));
            }

            University = university;
        }

        // Setter für die Matrikelnummer mit Validierung
        private void SetStudentId(string studentId)
        {
            if (string.IsNullOrWhiteSpace(studentId))
            {
                throw new ArgumentException("Die Matrikelnummer darf nicht leer sein.", nameof(studentId));
            }

            StudentId = studentId;
        }
    }
}
