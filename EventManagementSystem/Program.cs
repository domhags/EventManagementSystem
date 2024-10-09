using EventManagementSystem.Notifiers;
using EventManagementSystem.Services;

namespace EventManagementSystem
{
    class Program
    {
        static void Main(string[] args) // Main-Methode
        {
            var emailNotifier = new EmailNotifier(); // Instanziierung des E-Mail-Benachrichtigers
            var eventManager = new EventManager(emailNotifier); // Instanziierung des Event-Managers

            // Event für das Hinzufügen eines Teilnehmers abonnieren
            eventManager.ParticipantAdded += (sender, participant) =>
            {
                Console.WriteLine($"Neuer Teilnehmer hinzugefügt: {participant.Name}"); // Teilnehmermeldung
            };

            // Menüführung
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n----- Event Management System -----");
                Console.WriteLine("1. Event hinzufügen");
                Console.WriteLine("2. Teilnehmer hinzufügen");
                Console.WriteLine("3. Alle Events anzeigen");
                Console.WriteLine("4. Alle Teilnehmer anzeigen");
                Console.WriteLine("5. Beenden");
                Console.Write("Bitte eine Option wählen: ");
                string option = Console.ReadLine(); // Benutzereingabe für Menüoption

                switch (option)
                {
                    case "1":
                        AddEvent(eventManager); // Events hinzufügen
                        break;
                    case "2":
                        AddParticipant(eventManager); // Teilnehmer hinzufügen
                        break;
                    case "3":
                        DisplayEvents(eventManager); // Alle Events anzeigen
                        break;
                    case "4":
                        DisplayParticipants(eventManager); // Alle Teilnehmer anzeigen
                        break;
                    case "5":
                        exit = true; // Anwendung beenden
                        break;
                    default:
                        Console.WriteLine("Ungültige Option. Bitte erneut versuchen."); // Fehlerausgabe
                        break;
                }
            }
        }

        static void AddEvent(EventManager eventManager)
        {
            bool backToMainMenu = false;
            while (!backToMainMenu)
            {
                Console.WriteLine("\n----- Event Hinzufügen -----");
                Console.WriteLine("1. Konferenz-Event hinzufügen");
                Console.WriteLine("2. Workshop-Event hinzufügen");
                Console.WriteLine("3. Normales Event hinzufügen");
                Console.WriteLine("4. Zurück zum Hauptmenü");
                Console.Write("Bitte eine Option wählen: ");
                string option = Console.ReadLine(); // Benutzereingabe für Eventtyp

                switch (option)
                {
                    case "1":
                        AddConferenceEvent(eventManager); // Konferenz-Event hinzufügen
                        break;
                    case "2":
                        AddWorkshopEvent(eventManager); // Workshop-Event hinzufügen
                        break;
                    case "3":
                        AddNormalEvent(eventManager); // Normales Event hinzufügen
                        break;
                    case "4":
                        backToMainMenu = true; // Rückkehr zum Hauptmenü
                        break;
                    default:
                        Console.WriteLine("Ungültige Option. Bitte erneut versuchen."); // Fehlerausgabe
                        break;
                }
            }
        }

        // Methode zum Hinzufügen eines Konferenz Events
        static void AddConferenceEvent(EventManager eventManager)
        {
            // Eingabe der Eventdetails
            Console.Write("Event-Name: ");
            string eventName = Console.ReadLine();
            Console.Write("Datum (yyyy-mm-dd): ");
            DateTime eventDate;

            if (!DateTime.TryParse(Console.ReadLine(), out eventDate)) // Datum validieren
            {
                Console.WriteLine("Ungültiges Datum. Bitte geben Sie das Datum im Format yyyy-mm-dd ein."); // Fehlerausgabe
                return;
            }

            Console.Write("Ort: ");
            string eventLocation = Console.ReadLine();
            Console.Write("Maximale Teilnehmerzahl: ");
            int maxParticipants = int.Parse(Console.ReadLine());
            Console.Write("Beschreibung: ");
            string eventDescription = Console.ReadLine();
            Console.Write("Ist das Event online? (true/false): ");
            bool isOnline = bool.Parse(Console.ReadLine());

            Console.Write("Hauptredner: ");
            string speaker = Console.ReadLine();
            Console.Write("Thema: ");
            string topic = Console.ReadLine();

            // Konferenz-Event hinzufügen
            eventManager.AddConferenceEvent(eventName, eventDate, eventLocation, maxParticipants, eventDescription, isOnline, speaker, topic);
            
        }

        // Methode zum Hinzufügen eines Workshops-Events
        static void AddWorkshopEvent(EventManager eventManager)
        {
            // Eingabe der Eventdetails
            Console.Write("Event-Name: ");
            string eventName = Console.ReadLine();
            Console.Write("Datum (yyyy-mm-dd): ");
            DateTime eventDate;

            if (!DateTime.TryParse(Console.ReadLine(), out eventDate)) // Datum validieren
            {
                Console.WriteLine("Ungültiges Datum. Bitte geben Sie das Datum im Format yyyy-mm-dd ein."); // Fehlerausgabe
                return;
            }

            Console.Write("Ort: ");
            string eventLocation = Console.ReadLine();
            Console.Write("Maximale Teilnehmerzahl: ");
            int maxParticipants = int.Parse(Console.ReadLine());
            Console.Write("Beschreibung: ");
            string eventDescription = Console.ReadLine();
            Console.Write("Ist das Event online? (true/false): ");
            bool isOnline = bool.Parse(Console.ReadLine());

            Console.Write("Kursleiter: ");
            string instructor = Console.ReadLine();
            Console.Write("Benötigte Materialien (kommagetrennt): ");
            List<string> materials = Console.ReadLine().Split(',').ToList(); // Materialien aufteilen

            // Workshop-Event hinzufügen
            eventManager.AddWorkshopEvent(eventName, eventDate, eventLocation, maxParticipants, eventDescription, isOnline, instructor, materials);
        }

        // Methode zum Hinzufügen eines normalen Events
        static void AddNormalEvent(EventManager eventManager)
        {
            // Eingabe der Eventdetails
            Console.Write("Event-Name: ");
            string eventName = Console.ReadLine();
            Console.Write("Datum (yyyy-mm-dd): ");
            DateTime eventDate;

            if (!DateTime.TryParse(Console.ReadLine(), out eventDate)) // Datum validieren
            {
                Console.WriteLine("Ungültiges Datum. Bitte geben Sie das Datum im Format yyyy-mm-dd ein."); // Fehlerausgabe
                return;
            }

            Console.Write("Ort: ");
            string eventLocation = Console.ReadLine();
            Console.Write("Maximale Teilnehmerzahl: ");
            int maxParticipants = int.Parse(Console.ReadLine());
            Console.Write("Beschreibung: ");
            string eventDescription = Console.ReadLine();
            Console.Write("Ist das Event online? (true/false): ");
            bool isOnline = bool.Parse(Console.ReadLine());

            // Normales Event hinzufügen
            eventManager.AddNormalEvent(eventName, eventDate, eventLocation, maxParticipants, eventDescription, isOnline);
        }

        // Methode zum Hinzufügen von Teilnehmern 
        static void AddParticipant(EventManager eventManager)
        {
            // Auswahl des Teilnehmertyps
            Console.WriteLine("Wählen Sie den Typ des Teilnehmers:");
            Console.WriteLine("1. Regulärer Teilnehmer");
            Console.WriteLine("2. Student Teilnehmer");
            Console.WriteLine("3. VIP Teilnehmer");
            string participantType = Console.ReadLine();

            // Eingabe der Teilnehmerdetails (Standard Parameter)
            Console.Write("Teilnehmer-Name: ");
            string participantName = Console.ReadLine();
            Console.Write("E-Mail: ");
            string participantEmail = Console.ReadLine();
            Console.Write("Telefonnummer: ");
            string participantPhoneNumber = Console.ReadLine();
            Console.Write("Adresse: ");
            string participantAddress = Console.ReadLine();

            DateTime registrationDate = DateTime.Now; // Registrierungsdatum Heute

            // Teilnehmer je nach Typ hinzufügen
            switch (participantType)
            {
                case "1":
                    eventManager.AddParticipant(participantName, participantEmail, participantPhoneNumber, participantAddress, registrationDate);
                    break;
                case "2":
                    Console.Write("Universität: ");
                    string university = Console.ReadLine();
                    Console.Write("Matrikelnummer: ");
                    string studentId = Console.ReadLine();

                    eventManager.AddStudentParticipant(participantName, participantEmail, participantPhoneNumber, participantAddress, registrationDate, university, studentId);
                    break;
                case "3":
                    Console.Write("VIP-Stufe: ");
                    string vipLevel = Console.ReadLine();
                    Console.Write("Besondere Vorteile: ");
                    string benefits = Console.ReadLine();

                    eventManager.AddVIPParticipant(participantName, participantEmail, participantPhoneNumber, participantAddress, registrationDate, vipLevel, benefits);
                    break;
                default:
                    Console.WriteLine("Ungültiger Teilnehmer-Typ."); // Fehlerausgabe
                    return;
            }

            Console.WriteLine($"Teilnehmer '{participantName}' hinzugefügt."); // Bestätigung der Teilnehmeranmeldung        
        }

        // Methode zum Anzeigen aller Events
        static void DisplayEvents(EventManager eventManager)
        {
            Console.WriteLine("\nAlle Events:");
            if (!eventManager.Events.Any())
            {
                Console.WriteLine("Keine Events vorhanden."); // Keine Events gefunden
            }
            else
            {
                foreach (var evt in eventManager.Events)
                {
                    // Ausgabe der Eventdetails
                    Console.WriteLine($"Name: {evt.Name}, Datum: {evt.Date.ToShortDateString()}, Ort: {evt.Location}, Beschreibung: {evt.Description}, Max Teilnehmer: {evt.MaxParticipants}, Online: {evt.IsOnline}");
                }
            }
        }

        // Methode zum Anzeigen aller Teilnehmer
        static void DisplayParticipants(EventManager eventManager)
        {
            Console.WriteLine("\nAlle Teilnehmer:");
            if (!eventManager.Participants.Any())
            {
                Console.WriteLine("Keine Teilnehmer vorhanden."); // Keine Teilnehmer gefunden
            }
            else
            {
                foreach (var participant in eventManager.Participants)
                {
                    // Ausgabe der Teilnehmerdetails
                    Console.WriteLine($"Name: {participant.Name}, E-Mail: {participant.Email}, Telefonnummer: {participant.PhoneNumber}, Adresse: {participant.Address}");
                }
            }
        }
    }
}
