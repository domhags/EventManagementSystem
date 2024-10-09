namespace EventManagementSystem.Models
{
    public class Event // Normale Klasse Event
    {
        public string Name { get; private set; } // Name des Events
        public DateTime Date { get; private set; } // Veranstaltungsdatum des Events
        public string Location { get; private set; } // Veranstaltungsort des Event
        public int MaxParticipants { get; private set; } // Maximale Teilnehmerzahl vom Event
        public string Description { get; private set; } // Beschreibung des Events
        public bool IsOnline { get; private set; } // Gibt an, ob das Event online ist

        // Konstruktor
        public Event(string name, DateTime date, string location, int maxParticipants, string description, bool isOnline)
        {
            SetName(name);
            SetDate(date);
            SetLocation(location);
            SetMaxParticipants(maxParticipants);
            SetDescription(description);
            IsOnline = isOnline;
        }

        // Setter-Methode für den Event-Namen
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Event-Name darf nicht leer sein.", nameof(name));

            Name = name;
        }

        // Setter-Methode für das Datum
        public void SetDate(DateTime date)
        {
            if (date <= DateTime.Now)
                throw new ArgumentException("Das Datum muss in der Zukunft liegen.", nameof(date));

            Date = date;
        }

        // Setter-Methode für den Ort
        public void SetLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Der Ort darf nicht leer sein.", nameof(location));

            Location = location;
        }

        // Setter-Methode für die maximale Teilnehmerzahl
        public void SetMaxParticipants(int maxParticipants)
        {
            if (maxParticipants <= 0)
                throw new ArgumentException("Die maximale Teilnehmerzahl muss positiv sein.", nameof(maxParticipants));

            MaxParticipants = maxParticipants;
        }

        // Setter-Methode für die Beschreibung
        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Die Beschreibung darf nicht leer sein.", nameof(description));

            Description = description;
        }
    }
}
