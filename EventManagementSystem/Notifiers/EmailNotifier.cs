using EventManagementSystem.Interfaces;
using EventManagementSystem.Models;

namespace EventManagementSystem.Notifiers
{
    public class EmailNotifier : IEventNotifier // Klasse E-Mail-Benachrichtigung implementiert die Schnittstelle IEventNotifier
    {
        // Methode zum Benachrichtigen
        public void Notify(Participant participant)
        {
            // Validierung des Teilnehmer-Objekts
            if (participant == null) // Kein Teilnehmer vorhanden
            {
                Console.WriteLine("Der Teilnehmer ist ungültig. Benachrichtigung kann nicht gesendet werden.");
                return;
            }
            // Name und/oder E-Mail Adresse vom Teilnehmer sind leer oder null
            if (string.IsNullOrEmpty(participant.Name) || string.IsNullOrEmpty(participant.Email))
            {
                Console.WriteLine("Teilnehmer-Name oder E-Mail-Adresse ist ungültig. Benachrichtigung kann nicht gesendet werden.");
                return;
            }

            // Simulieren des Versands einer E-Mail-Benachrichtigung
            Console.WriteLine($"Benachrichtigung: {participant.Name} ({participant.Email}) wurde hinzugefügt.");
        }
    }
}
