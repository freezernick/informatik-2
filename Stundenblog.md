# Protokoll 'GameMaster'

*Informatik-Projekt von Jakob Wagner und Nick Lamprecht*

## Vorwort

Hier befindet sich das Stundentagebuch zu unserem Projekt. Zu unserer Projektseite geht es [hier](Projektseite.md).

## Stundenblog

### Dezember

#### 4. Dezember

Heute haben wir diskutiert, ob wir im zweiten Halbjahr weiter an 'Survisland' arbeiten, oder ein neues Projekt anfangen wollen. Schlußendlich haben wir uns für eine Anwendung entschieden, die in der Lage ist das Spielen von Computer- und Browsergames zu übernehmen. Wir haben die Anwendung den 'GameMaster' getauft.

#### 5. Dezember

Nachdem wir bereits den Rahmen für unser Projekt festgelegt hatten, ging es heute um die Details des Projekts. Wir wollen, dass der GameMaster vom Nutzer programmiert werden kann, um die Handlungen, die in einem beliebigen Spiel durchgeführt werden müssen, zu simulieren. Das Scripten soll dabei in einer grafischen Oberfläche stattfinden. Im Gegensatz zu klassichen Scripts / Bots soll der GameMaster nicht Input vom User voraussetzen oder Daten aus dem RAM auslesen, sondern anhand von Bildanalyse erkennen, was er tun muss. Die Konfigurationen nennen wir 'Ruleset'.
Für das UI werden wir Windows Forms verwenden.
Darüberhinaus haben wir heute das Repository und das Projekt für Visual Studio erstellt.

#### 10. Dezember

Heute haben wir mit dem User Interface begonnen. Die Anwendung hat einen Startbildschirm, in dem der Nutzer ein fertiges Ruleset starten, ein neues erstellen oder ein vorhandenes bearbeiten kann.

TODO: Bild Hauptbildschirm


#### 11. Dezember

Auch heute haben wir noch am Interface der Anwendung gearbeitet und zum Beispiel das Fenster zum bearbeiten der Metadaten eines Rulesets erstellt.

TODO: Bild Edit Form

#### 12. Dezember

Nachdem wir nun bereits einige Fenster erstellt haben, ging es heute darum einfache Funktionalitäten zu den Knöpfen hinzuzufügen, um so zum Beispiel von einem Fenster ins andere zu gelangen.
Außerdem haben wir ein neues Fenster hinzugefügt, dass das herunterladen von fertigen Rulesets erlaubt.

#### 19. Dezember

Heute haben wir an einige Fenster erstellt, die wir später brauchen werden, wenn wir den Editor für die Rulesets erstellen.

TODO: Bild

#### 14. Januar

Wir haben heute die Funktionalität der neuen Fenster eingebaut.

#### 15. Januar

Heute haben wir parallel an der Klasse, die die geladenen Rulesets repräsentiert, und weiterer Funktionalität des User Interfaces gearbeitet.

#### 16. Januar

Die heutige Informatikstunde war dem Beheben von einigen kleineren Fehlern gewidmet.

#### 22. Januar

Nachdem wir nun die meisten Bugs behoben hatte, haben wir heute sowohl Code-Refactoring betrieben, als auch einige Verbesserungen am Hauptbildschirm durchgeführt.

#### 23. Januar

TODO: SUCC

```yml
Name: Collector
Author: Nick
ID: nick-collector
Version: 1
FriendlyVersion: 1.0.0
LastChanged: 2020-01-28 14:50:42
Categories:
    - Test Kategorie
    - Platformer
StartAction: C:\Users\buyin\source\repos\testgame\bin\Debug\TestGame.exe
```
*Beispiel Ruleset*

TODO: Downloads

#### 29. & 30. Januar

(Ausfall)

* zip handling & SUCC

#### 4. Februar

#### 5. Februar

Heute ging es um kleine UX Verbesserungen und darum, dass sich der Hauptbildschirm des GameMasters minimiert, wenn der Nutzer ein Ruleset startet. Und wenn die Prozess des Rulesets beendet wird, sollte der GameMaster sich natürlich wieder selbstständig öffnen.

#### 6. Februar

#### 12. Februar

#### 13. Februar

#### 14. Februar

#### 19. Februar

#### 20. Februar

#### 21. Feburar

(ausfall)

#### 26., 27. & 28. Februar

(ausfall)

#### 4. & 5. März

(ausfall)

#### 6. März

Wir sind heute für das Speichern der Rulesets von der SUCC Library, die wir bisher verwendet haben, auf den .NET XML-Serializer umgestiegen. Diese Lösung ist zwar auch nicht optimal, da wir jetzt für jede Klasse, die der Nutzer verwenden könnte eine extra Zeile schreiben müssen (und das jetzt schon absurd aussieht), allerdings ist das System jetzt robuster und bereitet weniger Probleme.

```c#
[...]
namespace GameMaster.Ruleset
{
    [XmlRoot("configuration")]
    [XmlInclude(typeof(Templates.Template2D))]
    [XmlInclude(typeof(Templates.Platformer))]
    [XmlInclude(typeof(Events.CustomGlobalEvent))]
    [XmlInclude(typeof(Events.CustomWorldEvent))]
    [XmlInclude(typeof(Events.WorldShutdownRequestEvent))]
    [XmlInclude(typeof(Events.GlobalShutdownRequestEvent))]
    [XmlInclude(typeof(Events.TickEvent))]
    [XmlInclude(typeof(Events.WorldStartupEvent))]
    [XmlInclude(typeof(Actions.Avoid))]
    [XmlInclude(typeof(Actions.Click))]
    [XmlInclude(typeof(Actions.ExecuteCustomEvent))]
    [XmlInclude(typeof(Actions.Log))]
    [XmlInclude(typeof(Actions.Move))]
    [XmlInclude(typeof(Actions.OverlayLog))]
    [XmlInclude(typeof(Worlds.GameWorld))]
    [XmlInclude(typeof(Worlds.StartupWorld))]
    public class Configuration
    { [...]
```
*[Configuration.cs](GameMaster/Ruleset/Configuration.cs)*

Die gespeicherten Konfigurationen sehen leider nicht mehr so übersichtlich aus, lassen sich aber dennoch verstehen.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Name>Game Master Test Game Configuration</Name>
  <ID>collector</ID>
  <Executable>C:\Users\buyin\source\repos\testgame\bin\Debug\TestGame.exe</Executable>
  <Template xsi:type="Platformer">
    <Name>Platformer</Name>
  </Template>
  <CustomEvents />
  <LeftSideObjects>
    <LeftSide xsi:type="TickEvent">
      <Name>Tick Event</Name>
      <Description>This event is triggered after a set amount of miliseconds. Useful for recurring actions. Timeframe can be changed in the template settings.</Description>
      <EventObjects>
        <RightSide xsi:type="OverlayLog">
          <Name>Overlay Log</Name>
        </RightSide>
      </EventObjects>
    </LeftSide>
  </LeftSideObjects>
</configuration>
```
*Rulesets als XML*