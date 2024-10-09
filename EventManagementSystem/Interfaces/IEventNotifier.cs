using EventManagementSystem.Models;

namespace EventManagementSystem.Interfaces
{
    // Schnittstelle für Event-Benachrichtigungen
    public interface IEventNotifier
    {
        // Methode zur Benachrichtigung eines Teilnehmers
        void Notify(Participant participant);
    }
}
