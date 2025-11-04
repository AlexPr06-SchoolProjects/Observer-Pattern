
```markdown
# 🧩 Observer Pattern — C# Console Application

This project is a small educational demonstration of the **Observer Design Pattern** implemented in **C# (.NET 9)**.  
It allows a user to create an account, choose notification methods (e.g. Email, SMS, Slack, Telegram, etc.),  
and then receive notifications through the selected notifiers.

---

## 📁 Project Structure

```

Observer Pattern/
│
├── Observer Pattern.sln
└── Observer Pattern/
├── App/
│   └── Application.cs              # Main application logic (NotifyingApplication)
│
├── Factories/
│   └── NotifierFactory/
│       ├── NotifierCreator.cs
│       └── NotifierCreatorTypes/   # Factory classes for each notifier
│           ├── ConsoleNotifierCreator.cs
│           ├── EmailNotifierCreator.cs
│           ├── SMSNotifierCreator.cs
│           ├── SlackNotifierCreator.cs
│           ├── SoundNotifierCreator.cs
│           └── TelegramNotifierCreator.cs
│
├── Interfaces/
│   └── INotifiable.cs              # Defines notifier interface
│
├── Managers/
│   └── NotifierManager.cs          # Manages a pool of notifiers and triggers notifications
│
├── Notifiers/
│   ├── Notifier.cs                 # Base class for all notifiers
│   ├── Data/
│   │   └── NotifiableData.cs       # Shared data passed to all notifiers
│   └── NotifierTypes/
│       ├── ConsoleNotifier.cs
│       ├── EmailNotifier.cs
│       ├── SMSNotifier.cs
│       ├── SlackNotifier.cs
│       ├── SoundNotifier.cs
│       └── TelegramNotifier.cs
│
└── User/
├── Account.cs
└── User.cs                     # Represents a user with an associated account

````

---

## ⚙️ Technologies Used

- **Language:** C#  
- **Framework:** .NET 9.0  
- **Library:** [Spectre.Console](https://spectreconsole.net/) — for rich console UI prompts  
- **Design Pattern:** *Observer Pattern* + *Factory Method Pattern*

---

## 💡 Concept Overview

This project demonstrates the **Observer Pattern**, where multiple “observers” (notifiers) listen for updates from a single “subject” (the manager or application).

When an event (like “notify all”) occurs:
1. The manager triggers the notification event.
2. All subscribed notifiers (email, SMS, Slack, etc.) react to it independently.

In this project:
- `NotiferManager` acts as the **Subject / Observable**
- Classes in `NotifierTypes` act as **Observers**
- The `NotifierFactory` uses the **Factory Method** pattern to create different notifier types.

---

## 🚀 How to Run

1. **Open the solution** in Visual Studio or any C# IDE.  
   File: `Observer Pattern.sln`

2. **Restore dependencies** (Spectre.Console):
   ```bash
   dotnet restore
````

3. **Run the app:**

   ```bash
   dotnet run --project "Observer Pattern/Observer Pattern.csproj"
   ```

4. **Follow the prompts** in the console:

   * Enter user details (ID, name, password)
   * Choose which notifiers you’d like to receive messages from
   * See the notification results in real-time 💬

---

## 🧠 Example Output

```
=== 🧍 USER ACCOUNT CREATOR ===

Enter id: 1
Enter name: Alex
Enter password: *****

Whould you like we send you notifications with EmailNotifier: (y/n) y
Whould you like we send you notifications with SlackNotifier: (y/n) n
Whould you like we send you notifications with SMSNotifier: (y/n) y

[✔] EmailNotifier → We are notifying you!
[✔] SMSNotifier → We are notifying you!
```

---

## 🧱 Key Classes

| Class                          | Role                                            |
| ------------------------------ | ----------------------------------------------- |
| `NotifyingApplication`         | Coordinates the app flow and user input         |
| `NotiferManager`               | Holds and notifies all active notifiers         |
| `Notifier`                     | Abstract base class for all notification types  |
| `NotifiableData`               | Message data shared among notifiers             |
| `NotifierCreator` + subclasses | Factory classes for creating concrete notifiers |

---

## 📚 Learning Goals

* Understand and implement the **Observer Pattern**
* Practice **Factory Method** creation logic
* Work with **Spectre.Console** for interactive CLI
* Manage **user input**, **data encapsulation**, and **event-based logic**

---

## 🧾 License

This project is created for educational purposes.
Feel free to use or modify it for learning and practice.

---

## ✨ Author

**Name:** *AlexPr06*
**Assignment:** *Design Patterns Homework – Observer Pattern*
**Language:** C# / .NET 9
**Date:** *November 2025*

---

### 🔗 Example Command Summary

| Command        | Description                |
| -------------- | -------------------------- |
| `dotnet build` | Builds the project         |
| `dotnet run`   | Runs the app               |
| `tree /F /A`   | Displays project structure |

---

🎓 *“When one object changes state, all its dependents are notified automatically.” — Observer Pattern principle*

```

---
```
