using Observer_Pattern.App;
using Observer_Pattern.Notifiers.Data;
Console.OutputEncoding = System.Text.Encoding.UTF8;

string notifyingMessage = "We are notifying you!";
NotifiableData notifyingData = new NotifiableData(notifyingMessage);
NotifyingApplication notifyingApp = new NotifyingApplication(notifyingData);

notifyingApp.Run();
