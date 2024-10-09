using System;

namespace EventManagementSystem.Models
{
    public class ConferenceEvent : Event // Klasse Konferenz-Event erbt von der Klasse Event
    {
        public string Speaker { get; private set; } // Hauptredner
        public string Topic { get; private set; } // Thema der Konferenz

        // Konstruktor
        public ConferenceEvent(string name, DateTime date, string location, int maxParticipants, string description, bool isOnline, string speaker, string topic)
            : base(name, date, location, maxParticipants, description, isOnline)
        {
            SetSpeaker(speaker);
            SetTopic(topic);
        }

        // Setter für den Hauptredner mit Validierung
        private void SetSpeaker(string speaker)
        {
            if (string.IsNullOrWhiteSpace(speaker))
            {
                throw new ArgumentException("Der Hauptredner darf nicht leer sein.", nameof(speaker));
            }

            Speaker = speaker;
        }

        // Setter für das Thema mit Validierung
        private void SetTopic(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentException("Das Thema darf nicht leer sein.", nameof(topic));
            }

            Topic = topic;
        }
    }
}
