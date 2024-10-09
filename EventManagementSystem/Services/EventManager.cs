using EventManagementSystem.Interfaces;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services
{
    public class EventManager // Klasse Event-Manager
    {
        // Delegatoren zum Hinzufügen von Teilnehmern und Events
        public delegate void AddParticipantDelegate(string name, string email, string phoneNumber, string address, DateTime registrationDate, params string[] additionalParams); // Zusätzliche Parameter für VIP und Studierende Teilnehmer

        public delegate void AddEventDelegate(string name, DateTime date, string location, int maxParticipants, string description, bool isOnline, params string[] additionalParams); // Zusätzliche Parameter für Workshop und Konferenz Events

        // Listen für die Events und Teilnehmer
        public List<Event> Events { get; private set; } = new List<Event>(); // Liste der Events
        public List<Participant> Participants { get; private set; } = new List<Participant>(); // Liste der Teilnehmer

        // Delegate und Event für das Hinzufügen eines Teilnehmers
        public delegate void ParticipantAddedHandler(object sender, Participant participant); // Delegate für Teilnehmerhinzufügung
        public event ParticipantAddedHandler ParticipantAdded; // Event für Teilnehmerhinzufügung

        private readonly IEventNotifier _notifier; // Benachrichtigungsdienst nur lesbar in dieser Klasse

        public EventManager(IEventNotifier notifier)
        {
            _notifier = notifier; // Initialisierung des Notifiers
        }

        // Methode, um ein Konferenz-Event hinzuzufügen
        public void AddConferenceEvent(string name, DateTime date, string location, int maxParticipants, string description, bool isOnline, string speaker, string topic)
        {
            var conferenceEvent = new ConferenceEvent(name, date, location, maxParticipants, description, isOnline, speaker, topic); // Erstellen eines Konferenz-Events
            Events.Add(conferenceEvent); // Hinzufügen des Konferenz-Events zur Event-Liste
            Console.WriteLine($"Konferenz-Event '{name}' hinzugefügt."); // Ausgabe der Bestätigung
        }

        // Methode, um ein Workshop-Event hinzuzufügen
        public void AddWorkshopEvent(string name, DateTime date, string location, int maxParticipants, string description, bool isOnline, string instructor, List<string> materials)
        {
            var workshopEvent = new WorkshopEvent(name, date, location, maxParticipants, description, isOnline, instructor, materials); // Erstellen eines Workshop-Events
            Events.Add(workshopEvent); // Hinzufügen des Workshop-Events zur Event-Liste
            Console.WriteLine($"Workshop-Event '{name}' hinzugefügt."); // Ausgabe der Bestätigung
        }

        // Methode, um ein normales Event hinzuzufügen
        public void AddNormalEvent(string name, DateTime date, string location, int maxParticipants, string description, bool isOnline)
        {
            var normalEvent = new Event(name, date, location, maxParticipants, description, isOnline); // Erstellen eines normalen Events
            Events.Add(normalEvent); // Hinzufügen des normalen Events zur Event-Liste
            Console.WriteLine($"Event '{name}' hinzugefügt."); // Ausgabe der Bestätigung
        }

        // Methode, um einen regulären Teilnehmer hinzuzufügen
        public void AddParticipant(string name, string email, string phoneNumber, string address, DateTime registrationDate)
        {
            var participant = new Participant(name, email, phoneNumber, address, registrationDate); // Erstellen eines regulären Teilnehmers
            Participants.Add(participant); // Hinzufügen des Teilnehmers zur Teilnehmerliste
            ParticipantAdded?.Invoke(this, participant); // Auslösen des Teilnehmerhinzufügungs-Events
            _notifier.Notify(participant); // Benachrichtigen des Teilnehmers
        }

        // Methode, um einen Studenten-Teilnehmer hinzuzufügen
        public void AddStudentParticipant(string name, string email, string phoneNumber, string address, DateTime registrationDate, string university, string studentId)
        {
            var participant = new StudentParticipant(name, email, phoneNumber, address, registrationDate, university, studentId); // Erstellen eines Studenten-Teilnehmers
            Participants.Add(participant); // Hinzufügen des Teilnehmers zur Teilnehmerliste
            ParticipantAdded?.Invoke(this, participant); // Auslösen des Teilnehmerhinzufügungs-Events
            _notifier.Notify(participant); // Benachrichtigen des Teilnehmers
        }

        // Methode, um einen VIP-Teilnehmer hinzuzufügen
        public void AddVIPParticipant(string name, string email, string phoneNumber, string address, DateTime registrationDate, string vipLevel, string benefits)
        {
            var participant = new VIPParticipant(name, email, phoneNumber, address, registrationDate, vipLevel, benefits); // Erstellen eines VIP-Teilnehmers
            Participants.Add(participant); // Hinzufügen des Teilnehmers zur Teilnehmerliste
            ParticipantAdded?.Invoke(this, participant); // Auslösen des Teilnehmerhinzufügungs-Events
            _notifier.Notify(participant); // Benachrichtigen des Teilnehmers
        }
    }
}
