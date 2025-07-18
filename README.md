# BiohackingHub

**BiohackingHub** ist ein persönliches Dashboard zur digitalen Selbstverbesserung.  
Entwickelt im Rahmen einer Ausbildung zum Fachinformatiker für Anwendungsentwicklung, unterstützt es den Nutzer dabei, tägliche Routinen wie Aufgaben, Training, Wasseraufnahme und Reflektion zu verfolgen – strukturiert, motivierend und optisch modern.

---

## Projektziel

Dieses Projekt entstand aus dem Wunsch, alltägliche Gewohnheiten sichtbar zu machen und Achtsamkeit sowie Produktivität zu kombinieren.  
Es wurde im Rahmen einer schulischen Ausbildung als Demonstration moderner Webentwicklung mit .NET Core und C# realisiert.

---

## Über den Entwickler

Ich bin Auszubildender im Bereich Anwendungsentwicklung mit Fokus auf .NET-Technologien.
**BiohackingHub** wurde als praktisches Schul Projekt konzipiert.

---

## Features

- **Dashboard**
  - Übersicht von Tageszielen
  - Aufgabenfortschritt & Streak-Anzeige
  - Anzeige eines zufälligen „Wissens-Snippets“
  - Letzter Reflektionseintrag

- **Tagesdaten erfassen**
  - Aufgaben, Training, Supplemente & Wasseraufnahme
  - Persönliche Reflektion schreiben

- **Datenbasiertes Feedback**
  - Trainingshistorie (TrainingDays)
  - Wasserverbrauch (pro Tag)
  - Automatische Streak-Berechnung für Journaling

---

## 📄 Projektdokumentation

Die vollständige Dokumentation (PDF) inklusive Installation, Screenshots, Tests und Quellcodebeschreibung befindet sich unter:

[docs/Projektdokumentation.pdf](https://drive.google.com/file/d/1UyD0R1aPebNY6nk2OmH0ZCvshmMQpOlx/view?usp=drive_link)

---

## Tech Stack

| Technologie           | Beschreibung                                 |
|-----------------------|----------------------------------------------|
| **ASP.NET Core**      | Razor Pages Framework                        |
| **Entity Framework**  | ORM für Datenbankzugriff (Code First)        |
| **C# 9**              | Backend-Programmiersprache                   |
| **SQLite**            | Datenbank für lokale Persistenz              |
| **Bootstrap 5**       | Responsives UI & moderne Komponenten         |
| **Visual Studio**     | Hauptentwicklungsumgebung                    |

---

## Setup-Anleitung

### Voraussetzungen
- .NET SDK 6.0 oder höher
- Visual Studio 2022 oder höher (mit ASP.NET & Webentwicklung)
- EF Core CLI (`dotnet-ef`)

### Projekt klonen
```bash
git clone https://github.com/W3Tx/biohackinghub.git
cd biohackinghub
````

### Datenbank erstellen

```bash
dotnet ef database update
```

### Anwendung starten

```bash
dotnet run
```

Anschließend im Browser öffnen unter:

```
https://localhost:5001
```

---

## Datenmodell (Auszug)

| Modell             | Beschreibung                                        |
| ------------------ | --------------------------------------------------- |
| `TaskItem`         | Tagesaufgaben mit „Erledigt“-Status                 |
| `TrainingBlock`    | Trainingsblöcke mit Beschreibung                    |
| `SupplementIntake` | Supplementeinnahme (Name & Tageszeit)               |
| `WaterIntake`      | Anzahl der Gläser Wasser pro Tag                    |
| `JournalEntry`     | Freitextreflektionen mit Tagesstempel               |
| `KnowledgeSnippet` | Kleine Tages-Impulse zur Motivation & Produktivität |

---

```
DailyPerformanceDashboard/
│
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── js/
│   └── lib/
│       └── favicon.ico
│
├── Assets/
│   └── images/
│       └── screenshots/
│           ├── Dashboard.png
│           ├── Dashboard_XD.png
│           └── Tagesdaten.png
│
├── Migrations/
│
├── Models/
│   ├── AppDbContext.cs
│   ├── JournalEntry.cs
│   ├── KnowledgeSnippet.cs
│   ├── SupplementIntake.cs
│   ├── TaskItem.cs
│   ├── TrainingBlock.cs
│   └── WaterIntake.cs
│
├── Pages/
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   ├── _ValidationScriptsPartial.cshtml
│   ├── DailyInput.cshtml
│   ├── DailyInput.cshtml.cs
│   ├── Dashboard.cshtml
│   ├── Dashboard.cshtml.cs
│   ├── Index.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
│
├── appsettings.json
├── launchSettings.json
├── package.json
├── performance.db
└── Program.cs
```

---

## Screenshots & Mockups
> Diese Sektion zeigt Beispielansichten

#### Beispiel / Dashboard Übersicht / Adobe XD Design Mockup & Layout 
![Dashboard-Mockup](https://github.com/W3Tx/BioHacking-Hub/blob/main/DailyPerformanceDashboard/Assets/images/screenshots/Dashboard_XD.png)

#### Desktop / Dashboard aktuell
![Dashboard](https://github.com/W3Tx/BioHacking-Hub/blob/main/DailyPerformanceDashboard/Assets/images/screenshots/Dashboard.png)

#### Desktop / Tagesdaten aktuell
![Tagesdaten](https://github.com/W3Tx/BioHacking-Hub/blob/main/DailyPerformanceDashboard/Assets/images/screenshots/Tagesdaten.png)

---

#### Mobile / Dashboard aktuell
![Dashboard-Mobile](https://github.com/W3Tx/BioHacking-Hub/blob/main/DailyPerformanceDashboard/Assets/images/screenshots/Mobile_Ansicht_Dashboard_1.png)

![Dashboard-Mobile](https://github.com/W3Tx/BioHacking-Hub/blob/main/DailyPerformanceDashboard/Assets/images/screenshots/Mobile_Ansicht_Dashboard_2.png)

#### Mobile / Tagesdaten aktuell
![Tagesdaten-Mobile](https://github.com/W3Tx/BioHacking-Hub/blob/main/DailyPerformanceDashboard/Assets/images/screenshots/Mobile_Ansicht_Daten.png)

---

## Roadmap / ToDos

* [ ] Aufgabenstatus mit Checkbox ändern
* [ ] Statistik-Ansicht mit Diagrammen für Wasser, Training & Streaks
* [ ] Benutzerkonten (Login & persönliche Daten)
* [ ] Dark Mode
* [ ] Mobile UX verbessern

---
