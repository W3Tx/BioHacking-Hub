# BiohackingHub

**BiohackingHub** ist ein personalisiertes Dashboard für tägliche Leistungs- und Gesundheitsverfolgung. Es kombiniert moderne Webtechnologien mit achtsamkeitsorientierten Features, um deinen Alltag messbar besser zu gestalten.

---

## Features

- **Dashboard-Ansicht**
  - Übersicht von Tageszielen, Aufgaben, Trainings und Supplements
  - Tägliches Wissens-Snippet für Mindset & Lernen
  - Reflektionsbereich für Selbstbeobachtung

- **Eingabe-Maske**
  - Aufgaben, Trainings, Supplemente und Reflektion bequem eintragen
  - Wasseraufnahme mit +1-Button dokumentieren

- **Streaks & Historie**
  - Berechnung deiner „Day Streak“
  - Anzeige vergangener Erfolge

---

## Tech Stack

| Technologie       | Beschreibung                           |
|------------------|----------------------------------------|
| **ASP.NET Core** | Backend-Logik mit Razor Pages          |
| **Entity Framework Core** | Datenbankzugriff (SQLite/MSSQL)     |
| **Bootstrap 5**  | UI-Komponenten & Responsive Design     |
| **C# 10**        | Programmiersprache                     |
| **EF Code First**| Datenmodellierung                     |

---

## Setup-Anleitung

### Klonen
```bash
git clone https://github.com/dein-benutzername/biohackinghub.git
cd biohackinghub
````

### Starten

1. Datenbank anlegen:

   ```bash
   dotnet ef database update
   ```

2. Projekt starten:

   ```bash
   dotnet run
   ```

3. Öffne `https://localhost:5001` oder `http://localhost:5000`

---

## Datenmodell (Auszug)

* `TaskItem` – Tägliche Aufgaben
* `TrainingBlock` – Dokumentierte Workouts
* `SupplementIntake` – Eingenommene Nahrungsergänzungsmittel
* `JournalEntry` – Reflektionseintrag
* `WaterIntake` – Getrunkene Gläser Wasser
* `KnowledgeSnippet` – Zufällig angezeigte Wissenshäppchen

---

## Screenshots & Mockups
> Diese Sektion zeigt Beispielansichten

#### Dashboard Übersicht
![Dashboard](Assets/images/screenshots/Dashboard_XD.png)

#### Tagesdaten-Eingabe

---

## Roadmap / ToDos

* [ ] Aufgabenstatus änderbar machen (✔/✗)
* [ ] Diagramme für Wasser & Trainingsverlauf
* [ ] User-System für Mehrbenutzermodus
* [ ] Dark Mode

```
