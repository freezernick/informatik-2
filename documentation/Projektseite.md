# Idee / Konzept
Mit dem 'GameMaster' wollen wir ein Tool entwickeln, dass es jedem ohne technisches Vorwissen ermöglicht, eine KI oder eher einen Bot zu entwickeln, die für den Nutzern das Spielen von Computer- und Browsergames übernimmt.
Es sollte dafür eine grafische Oberfläche gegen, mit der dann anhand von Parametern die Funktionsweise geändert werden kann.

# Die Anwendung

## Der Startbildschirm

![](images/page/main.png)

Startet man den 'GameMaster' ist dieser Bildschirm das erste was man sieht. Man bekommt eine Liste mit bereits installierten Rulesets. Wenn man eins ausgewählt hat, kann man es starten - solange man das Spiel, für das das Ruleset konfiguriert wurde, installiert hat - bearbeiten oder löschen. Außerdem kann man jederzeit ein neues Ruleset erstellen, oder versuchen fertiggestellte Rulesets herunterzuladen. 

## Editor

TODO: Bild + Erklärung

### Welten-System

TODO: Erklärung, ggf. Diagramm?

### Metadaten

TODO: Bild + Erklärung

## Downloadfenster

TODO: Bild + Erklärung 

## Ein Ruleset Starten

### Input Rerouting

### Overlay

# Umsetzung

## Entwicklungsumgebung

![](images/page/vs_still.png)

Der 'GameMaster' wird in C# entwickelt. Für die Oberfläche verwenden wir [WindowsForms.](https://github.com/dotnet/winforms). Als IDE verwenden wir [Visual Studio 2019](https://visualstudio.microsoft.com/), da in der Software ein Editor implementiert ist, mit dem man die Benutzeroberfläche mithilfe einiger vorgefertigter Elemente zusammenbauen kann.

TODO: GIF GUI Editing

## 'GameMaster TestGame Library'

![](images/page/testgame.png)

Um unser Projekt unter optimalen Bedingungen testen zu können, haben wir zusätzlich noch ein kleines Spiel gebaut, in dem man kleine blaue Vierecke einsammeln muss.

## GameMaster

### MainFormHelper

Da die Instanz des Hauptbildschirmes, der MainForm, über die komplette Laufzeit des Programms erhalten bleiben muss, da ansonsten das Programm beendet wird, können wir dieses Fenster nicht löschen, wenn wir in ein anderes wechseln möchten. Wir können es lediglich verstecken und irgendwo speichern. Außerdem müssen wir auch manchmal auf die MainForm-Instanz zugreifen, um einige Variablen zu setzen. Deshalb haben wir die statische `MainFormHelper`-Klasse erstellt. Diese enthält eine statische `MainForm`-Variable, die die Singleton-Instanz unserer MainForm darstellt. Zusätzlich verfügt sie über zwei Funktionen: `Show`, die wir aufrufen, wenn wir das Fenster anzeigen wollen, und `Get`, die wir verwenden, wenn wir eine Referenz zur MainForm brauchen, um z.B. Variable zu ändern.

```c#
public static class MainFormHelper
    {
        private static MainForm _main;

        public static void Show()
        {
            if (_main == null) { _main = new MainForm(); }
            _main.Show();
        }

        public static MainForm Get()
        {
            if (_main == null) { _main = new MainForm(); }
            return _main;
        }
    }

```
*Aus [Main.cs](../GameMaster/Forms/Main.cs)*