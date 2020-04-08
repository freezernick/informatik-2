# Idee / Konzept
Mit dem 'GameMaster' wollen wir ein Tool entwickeln, dass es jedem ohne technisches Vorwissen ermöglicht, eine KI oder eher einen Bot zu entwickeln, die für den Nutzern das Spielen von Computer- und Browsergames übernimmt.
Es sollte dafür eine grafische Oberfläche gegen, mit der dann anhand von Parametern die Funktionsweise geändert werden kann.

# Umsetzung

## Entwicklungsumgebung

![](images/page/vs_still.png)

Der 'GameMaster' wird in C# entwickelt. Für die Oberfläche verwenden wir [WindowsForms.](https://github.com/dotnet/winforms). Als IDE verwenden wir [Visual Studio 2019](https://visualstudio.microsoft.com/), da in der Software ein Editor implementiert ist, mit dem man die Benutzeroberfläche mithilfe einiger vorgefertigter Elemente zusammenbauen kann.

TODO: GIF GUI Editing

## Bibliotheken

### Emgu CV

Als Tool zur Bildanalyse dient eine OpenCV-Implementierung für C# namens [Emgu CV.](https://github.com/emgucv/emgucv).

TODO: Erklärung OpenCV

### GameOverlay.Net

Für das Overlay verwenden wir [GameOverlay.Net.](https://github.com/michel-pi/GameOverlay.Net)

TODO: Erklärung / Bild

## 'GameMaster TestGame Library'

![](images/page/testgame.png)

Um unser Projekt unter optimalen Bedingungen testen zu können, haben wir zusaätzlich noch ein kleines Spiel gebaut, in dem man kleine Vierecke einsammeln muss. Das Repository befindet sich [hier](https://github.com/freezernick/gm-test-game-library). Auch dieses Spiel ist mit C# und Windows Forms erstellt worden.

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

# Funktionalität

