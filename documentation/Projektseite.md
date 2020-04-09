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

Um unser Projekt unter optimalen Bedingungen testen zu können, haben wir zusätzlich noch ein kleines Spiel gebaut, in dem man kleine blaue Vierecke einsammeln muss.
Es besteht lediglich aus zwei Bildschirmen: Dem Menü und dem Spiel.

### Das Menü

![](images/page/tg_menu.png)

Das Menü ist sehr simpel und erfüllt keine weitere Funktion als darüber das Spiel starten zu können. Wir haben dieses Fenster vor dem Hintergrund erstellt, dass wir Text-Erkennung, also den Startknopf, und simulierte Mauseingaben, also das drücken dieses Knopfes, durch den GameMaster testen können.
Die Simplizität des Benutzeroberfläche spiegelt sich auch im Code wieder.

```c#

[...]

public partial class MainForm : Form
{
    public MainForm() => InitializeComponent();

```
*Aus [MainForm.cs](../TestGame/MainForm.cs)*

`InitializeComponent` ist eine Funktion, die von dem Windows-Forms-Designer benötigt wird und wird deshalb hier im Constructor aufgerufen.

```c#
    private void BtStart_Click(object sender, EventArgs e)
    {
        Hide();
        new Collector(this).Show();
    }
```
Es folgen zwei Event-Handler für die `Click`-Events der beiden Knöpfe des Menüs. Da unser Programm beendet wird, wenn wir das Hauptfenster komplett schließen, können wir es nur "verstecken", wenn wir in einen anderen Bildschirm wechseln wollen. Deshalb rufen wir hier die Funktion `Hide` auf. Damit wir später vom Spielbildschirm wieder in den Hauptbildschirm wechseln können, müssen wir dem Spielfenster die Instanz des Menüs mitteilen. Das machen wir über den Constructor des Spielfensters. Mit `this`-wird die aktuelle Instanz der MainForm-Klasse als Parameter des Constructors übertragen. Anschließden lassen wir mit `Show` das gerade erstellte Fenster anzeigen.

```c#
        private void BtExit_Click(object sender, EventArgs e) => Close();
```

Für den Beenden-Knopf wird nur die Funktion `Close` aufgerufen, die dann das Fenster, und somit das ganze Programm, schließt bzw. beendet.

<details>
<summary>Vollständiger Code der MainForm.cs</summary>

```c#
using System;
using System.Windows.Forms;

namespace TestGame
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        private void BtStart_Click(object sender, EventArgs e)
        {
            Hide();
            new Collector(this).Show();
        }

        private void BtExit_Click(object sender, EventArgs e) => Close();
    }
}
```
</details>

### Das Spiel

![](images/page/tg.png)

```c#
public partial class Collector : Form
{
    private readonly MainForm Main;

    private bool RunningDown = false;
    private bool RunningUp = false;
    private bool RunningLeft = false;
    private bool RunningRight = false;

    private Rectangle obstacle;
    private Rectangle Goal;
    private readonly Random RDM = new Random();

    private int Score = 0;
```

Erstmal definieren wir die wichtigsten Variablen des Spiels: Die Referenz zur MainForm-Instanz, einige Booleans für die Spielerbewegung, zwei Rechtecke, die das Hindernis und das Ziel repräsentieren und die wir später für die Kollisionsabfrage verwenden, sowie ein Random-Stream, den wir für die neue Position des Ziels verwenden werden, sowie eine Variable für die Punktzahl.

```c#
    public Collector(MainForm main)
    {
        InitializeComponent();
        FormBorderStyle = FormBorderStyle.None;
        CenterToScreen();
```

Mit `FormBorderStyle = FormBorderStyle.None;` und `CenterToScreen();` verändern wir die Weise, wie das Fenster angezeigt wird. Das ließe sich auch über das Eigenschaftsfenster in Visual Studio realisieren, aber hier haben wir es über den Code realisiert, weil wir nur diese zwei Zeilen einstellen mussten.

```c#
        KeyDown += KeyPress;
        KeyUp += KeyRelease;
```

Danach weisen wir für das `KeyDown`- und das `KeyUp`-Event Funktionen zu, die als Event-Handler dienen sollen.

```c#
        obstacle = new Rectangle(
            panel2.Location.X,
            panel2.Location.Y,
            panel2.Width,
            panel2.Height

        );
        Goal = new Rectangle(
            panel3.Location.X,
            panel3.Location.Y,
            panel3.Width,
            panel3.Height

        );

        Main = main;
    }
```
In diesem Abschnitt setzen wir die Ursprungswerte für die Rechtecke des Hindernisses und des Zielobjekts und weisen die über die Constructor-Parameter mitgegebene MainForm-Instanz der `Main`-Variable zu. Die visuelle Repräsentation der Objekte auf der Karte lösen wir über Panel-Elemente. Die Positionen und Größen, die wir vorher im Designer festgelegt haben, verwenden wir hier als Startwerte.


```c#
    private bool CheckMovement(Point NextLocation)
    {
        [...]
    }
```

Als nächstes kommt unsere `CheckMovement`-Funktion. Mit ihr überprüfen wir, ob die Koordinaten des Punktes, der als Parameter durchgegeben wird, für den Spieler erreichbar ist. Liegt der Wert außerhalb des Spielfeldes bzw. des Fensterrahmens oder innerhalb des Hindernis-Rechtecks wird `false` ausgegeben. `True` wird also ausgegeben, wenn der Punkt erreichbar ist. Darüberhinaus prüfen wir, ob der Punkt innerhalb des Zielobjektes liegt.

```c#
        if (NextLocation.X >= 586 || NextLocation.X < 0 || NextLocation.Y >= 449 || NextLocation.Y < 0)
            return false;

        if (obstacle.Contains(NextLocation))
            return false;
```

In der ersten Abfrage überprüfen wir, ob der Punkt noch im Spielbereich liegt. Mit der zweiten Abfrage schauen wir mit der `Contains`-Funktion, ob die das Rechteck des Hindernisses den Punkt enthält.

```c#
        if (Goal.Contains(NextLocation))
        {
            Point NewLocation = new Point(RDM.Next(0, this.Size.Width), RDM.Next(0, this.Size.Height));
```

Mit der nächsten Abfrage überprüfen wir, ob der Punkt innerhalb des Zielobjektes liegt. Wenn dem so sein sollte, erstellen wir einen neuen Punkt mithilfe des Random-Streams `RDM`, den wir vorher erstellt hatten. Für die `x`- und `y`-Werte legen wir jeweils die Breite bzw. die Höhe des Spielfensters als Maximalwert fest.

```c#
            while (obstacle.Contains(NewLocation.X, NewLocation.Y))
            {
                NewLocation = new Point(RDM.Next(0, this.Size.Width), RDM.Next(0, this.Size.Height));
            }
```

Mit dieser `while`-Schleife sagen wir, dass, solange der neue Punkt innerhalb des Hindernisses liegt, die Generierung des Punktes wiederholt werden muss. Schließlich wäre das Ziel nicht erreichbar, wenn es innerhalb dieses Rechteckes liegen würde.

```c#
            panel3.Location = NewLocation;
            Goal = new Rectangle(
                panel3.Location.X,
                panel3.Location.Y,
                panel3.Width,
                panel3.Height
            );
            Score++;
        }
        return true;
```

Liegt der Punkt an einer gültigen Position, können wir das Panel des Ziels an die neue Position verschieben und das Rechteck, das das Ziel im Code repräsentiert aktualisieren, die Punktzahl erhöhen und schließlich `true` ausgeben, damit der Spieler sich auch bewegen kann.

```c#
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                RunningUp = true;
            if (e.KeyCode == Keys.S)
                RunningDown = true;
            if (e.KeyCode == Keys.A)
                RunningLeft = true;
            if (e.KeyCode == Keys.D)
                RunningRight = true;

            if (e.KeyCode == Keys.OemMinus)
                Environment.Exit(1);

            if (e.KeyCode == Keys.Oemplus)
            {
                Close();
                Main.Show();
            }
        }

```

Mit diesem Event-Handler verarbeiten wir das KeyDown-Event des Fensters. Mit W/A/S/D (oben, links, unten, rechts) soll der Spieler bewegt werden. Deshalb setzen wir den sobald eine dieser Tasten gedrückt wird, den dazugehörigen "Running"-Boolean. Außerdem erlauben wir noch mit "-" das Spiel bzw. das ganze Programm zu beenden und mit "+" wieder ins Menü zu gelangen.

Und damit die Spielfigur sich nicht unendlich lang bewegt, müssen wir natürlich noch den Handler für das KeyUp-Event so programmieren, dass die "Running"-Boleans wieder auf `false` gesetzt werden.

```c#
        private void KeyRelease(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                RunningUp = false;
            if (e.KeyCode == Keys.S)
                RunningDown = false;
            if (e.KeyCode == Keys.A)
                RunningLeft = false;
            if (e.KeyCode == Keys.D)
                RunningRight = false;
        }
```

Danach folgen die eigentlichen Bewegungsfunktionen. Wir nehmen hier mal `GoUp` als Beispiel.

```c#
        private void GoUp()
        {
            Point NextLocation = new Point(panel1.Location.X, panel1.Location.Y - 3);
            if (CheckMovement(NextLocation))
                panel1.Location = NextLocation;
        }
```

In dieser Funktion wird der Punkt berechnet, zu dem sich der Spieler bewegen würden. In diesem Fall muss die `x`-Koordinate gleich bleiben, während der `y`-Wert verringert wird, da der Koordinatenursprung in der linken, oberen Ecke des Fensters ist. Dann rufen wir mit einer if-Abfrage unsere `CheckMovement`-Funktion auf, und wenn der Ort gültig ist, setzten wir die Position des Spieler-Panels. Die restlichen Bewegungsfunktionen unterscheiden sich nur durch das Vorzeichen bzw. die Achse.

Und abschließend kommt die `Tick`-Funktion des Timers, den wir auch als Windows-Forms-Element zum Fenster hinzugefügt haben.

```c#
        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = $"Score: {Score.ToString()}";

            if (RunningUp == true)
                GoUp();
            if (RunningDown == true)
                GoDown();
            if (RunningLeft == true)
                GoLeft();
            if (RunningRight == true)
                GoRight();
        }
```
<details>

<summary>Vollständiger Code der Collector.cs</summary>

```c#
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestGame
{
    public partial class Collector : Form
    {
        private readonly MainForm Main;

        private bool RunningDown = false;
        private bool RunningUp = false;
        private bool RunningLeft = false;
        private bool RunningRight = false;

        private Rectangle obstacle;
        private Rectangle Goal;
        private readonly Random RDM = new Random();

        private int Score = 0;

        public Collector(MainForm main)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            CenterToScreen();
            KeyDown += KeyPress;
            KeyUp += KeyRelease;
            obstacle = new Rectangle(
                panel2.Location.X,
                panel2.Location.Y,
                panel2.Width,
                panel2.Height

            );
            Goal = new Rectangle(
               panel3.Location.X,
               panel3.Location.Y,
               panel3.Width,
               panel3.Height

            );

            Main = main;
        }

        private bool CheckMovement(Point NextLocation)
        {
            if (NextLocation.X >= 586 || NextLocation.X < 0 || NextLocation.Y >= 449 || NextLocation.Y < 0)
                return false;

            if (obstacle.Contains(NextLocation))
                return false;

            if (Goal.Contains(NextLocation))
            {
                Point NewLocation = new Point(RDM.Next(0, this.Size.Width), RDM.Next(0, this.Size.Height));
                while (obstacle.Contains(NewLocation.X, NewLocation.Y))
                {
                    NewLocation = new Point(RDM.Next(0, this.Size.Width), RDM.Next(0, this.Size.Height));
                }
                panel3.Location = NewLocation;
                Goal = new Rectangle(
                   panel3.Location.X,
                   panel3.Location.Y,
                   panel3.Width,
                   panel3.Height
                );
                Score++;
            }
            return true;
        }

        private new void KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                RunningUp = true;
            if (e.KeyCode == Keys.S)
                RunningDown = true;
            if (e.KeyCode == Keys.A)
                RunningLeft = true;
            if (e.KeyCode == Keys.D)
                RunningRight = true;

            if (e.KeyCode == Keys.OemMinus)
                Environment.Exit(1);

            if (e.KeyCode == Keys.Oemplus)
            {
                Close();
                Main.Show();
            }
        }

        private void KeyRelease(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                RunningUp = false;
            if (e.KeyCode == Keys.S)
                RunningDown = false;
            if (e.KeyCode == Keys.A)
                RunningLeft = false;
            if (e.KeyCode == Keys.D)
                RunningRight = false;
        }

        private void GoUp()
        {
            Point NextLocation = new Point(panel1.Location.X, panel1.Location.Y - 3);
            if (CheckMovement(NextLocation))
                panel1.Location = NextLocation;
        }

        private void GoDown()
        {
            Point NextLocation = new Point(panel1.Location.X, panel1.Location.Y + 3);
            if (CheckMovement(new Point(NextLocation.X, NextLocation.Y + panel1.Height)))
                panel1.Location = NextLocation;
        }

        private void GoLeft()
        {
            Point NextLocation = new Point(panel1.Location.X - 3, panel1.Location.Y);
            if (CheckMovement(NextLocation))
                panel1.Location = NextLocation;
        }

        private void GoRight()
        {
            Point NextLocation = new Point(panel1.Location.X + 3, panel1.Location.Y);
            if (CheckMovement(new Point(NextLocation.X + panel1.Width, NextLocation.Y)))
                panel1.Location = NextLocation;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = $"Score: {Score.ToString()}";

            if (RunningUp == true)
                GoUp();
            if (RunningDown == true)
                GoDown();
            if (RunningLeft == true)
                GoLeft();
            if (RunningRight == true)
                GoRight();
        }
    }
}
```
</details>

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
*Aus [Main.cs](../GameMaster/Forms/Main.cs#145)*

In beiden Fällen wird zuerst überprüft, ob die MainForm `_main` bereits existiert, oder ob diese noch initialisiert werden muss. Anschließend wird die MainForm entweder direkt angezeigt oder zurückgegeben. 


Diese Klasse wird auch direkt beim Programmstart verwendet:

```c#
internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        [...]
        Application.Run(MainFormHelper.Get());
    }
}
```
*Aus [Program.cs](../GameMaster/Program.cs)*


### MainForm


```c#
public partial class MainForm : GameMasterForm, IProcessInterface
{
    public Configuration SelectedRuleset;
    public List<Configuration> Games;
    private bool Running;
    public VM Vm { get; private set; }

    public MainForm()
    {
        InitializeComponent();
        Games = new List<Configuration>();
        Tray.Icon = SystemIcons.Application;
        Tray.Click += Tray_MouseDoubleClick;
        CheckForIllegalCrossThreadCalls = false;
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Checks if there are items in the box
        if (listBox1.Items.Count == 0)
        {
            btStart.Enabled = false;
            btEditProp.Enabled = false;
            btDelete.Enabled = false;
            return;
        }

        btEditProp.Enabled = true;
        btDelete.Enabled = true;

        if (listBox1.SelectedItem != null)
        {
            SelectedRuleset = Games[listBox1.SelectedIndex];
            if (SelectedRuleset.ValidAction() && !Running)
            {
                btStart.Enabled = true;
            }
            else
            {
                btStart.Enabled = false;
            }
        }
    }

    private void btNew_Click(object sender, EventArgs e)
    {
        SelectedRuleset = new Configuration();
        FormHandler.Get<EditForm>().Text = "New Config";
        FormHandler.Get<EditForm>().Show();
        Hide();
    }

    private void btEditProp_Click(object sender, EventArgs e)
    {
        EditorForm editor = new EditorForm();
        editor.Text = "Edit " + SelectedRuleset.Name;
        editor.Show();
        Hide();
    }

    private void btAdd_Click(object sender, EventArgs e)
    {
        new DownloadForm().Show();
        Hide();
    }

    public void UpdateList()
    {
        listBox1.Items.Clear();
        foreach (Configuration config in Games)
        {
            listBox1.Items.Add(config.Name);
        }
    }

    private void lErscheinungsdatum_Load(object sender, EventArgs e)
    {
        Configuration.DiscoverRulesets();
        UpdateList();
        if (listBox1.Items.Count > 0)
            listBox1.SelectedIndex = 0;
    }

    private void btStart_Click(object sender, EventArgs e) => Vm = new VM(SelectedRuleset);

    private void Tray_MouseDoubleClick(object sender, EventArgs e)
    {
        Vm.Interrupt();
        MainFormHelper.Show();
        Tray.Visible = false;
        WindowState = FormWindowState.Normal;
    }

    private void SourceCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start(GameMaster.Properties.Resources.Repository);

    private void button1_Click(object sender, EventArgs e)
    {
        var confirmResult = MessageBox.Show("Are you sure to delete this ruleset? This cannot be undone!", "Confirmation needed", MessageBoxButtons.YesNo);
        if (confirmResult == DialogResult.Yes)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            SelectedRuleset.Delete();
            SelectedRuleset = null;
        }
    }

    /// <summary>
    /// Called when the game process is started
    /// </summary>
    public void ProcessStarted()
    {
        Running = true;
        Tray.Visible = true;
        Hide();
    }

    /// <summary>
    /// Called when the game process has been terminated
    /// </summary>
    public void ProcessEnded()
    {
        Running = false;
        MainFormHelper.Show();
        WindowState = FormWindowState.Normal;
        Tray.Visible = false;
        Vm = null;
    }
}
```

#### DownloadForm

```c#
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;

namespace GameMaster
{
    public partial class DownloadForm : GameMasterForm
    {
        private string DownloadDirectory = AppContext.BaseDirectory + @"\downloads";

        public DownloadForm() => InitializeComponent();

        private void btExit_Click(object sender, EventArgs e)
        {
            MainFormHelper.Show();
            Close();
        }

        private void tbQuelle_TextChanged(object sender, EventArgs e)
        {
            if (!ValidateUrl(tbQuelle.Text))
            {
                btStart.Enabled = false;
                return;
            }
            btStart.Enabled = true;
        }

        /// <summary>
        /// Checks if the given string is a valid URL.
        /// Also ensures it's a .zip
        /// </summary>
        /// <param name="Url">The string to be checked</param>
        /// <returns>Whether it's valid or not</returns>
        private bool ValidateUrl(string Url)
        {
            // Is using http / https
            if (!Url.StartsWith("http://") && !Url.StartsWith("https://"))
            {
                return false;
            }

            // Target is a .zip archive
            if (!Url.EndsWith(".zip"))
            {
                return false;
            }

            string[] substrings = Url.Split('/');

            /// Target archive has a name
            /// (Checks if there are characters between the last '/' and the .zip)
            if (substrings.Last() == ".zip")
            {
                return false;
            }
            return true;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(DownloadDirectory))
            {
                rtbStatus.AppendText("Download directory doesn't exist!\n");
                rtbStatus.AppendText("Creating...\n");
                Directory.CreateDirectory(DownloadDirectory);
            }
            using (WebClient wc = new WebClient())
            {
                string DownloadUrl = tbQuelle.Text;

                // Upgrade insecure requests
                if (DownloadUrl.StartsWith("http://"))
                {
                    rtbStatus.AppendText("\nUpgrading insecure request...\n");
                    DownloadUrl.Replace("http://", "https://");
                }
                rtbStatus.AppendText("Downloading now...\n");
                wc.DownloadProgressChanged += WC_DownloadProgressChanged;
                wc.DownloadFileCompleted += WC_DownloadFileCompleted;
                wc.DownloadFileAsync(
                    new System.Uri(DownloadUrl),
                    Path.Combine(DownloadDirectory, "Download.zip")
                );
            }
        }

        private void WC_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) => pbProgress.Value = e.ProgressPercentage;

        private void WC_DownloadFileCompleted(object sender, EventArgs e)
        {
            rtbStatus.AppendText("Finished!\n");
            ZipHandling();
        }

        private void ZipHandling()
        {
            rtbStatus.AppendText("Extracting archive...\n");
            string TempDirectory = AppContext.BaseDirectory + @"\temp";
            ZipFile.ExtractToDirectory(Path.Combine(DownloadDirectory, "Download.zip"), TempDirectory);
            rtbStatus.AppendText("Done! Checking files...\n");
            string[] Files = Directory.GetFiles(TempDirectory);
            foreach (string File in Files)
            {
                if (File.Contains(".xml"))
                {
                    rtbStatus.AppendText("Found 1 ruleset!\n");
                    FileHandling(true, File);
                    return;
                }
            }
            string[] dirs = Directory.GetDirectories(TempDirectory);
            int SetCount = 0;
            foreach (string dir in dirs)
            {
                string[] substrings = dir.Split('\\');
                foreach (string File in Directory.GetFiles(Path.Combine(TempDirectory, substrings.Last())))
                {
                    if (File.Contains(".xml"))
                    {
                        SetCount++;
                        FileHandling(false, substrings.Last());
                    }
                }
            }
            rtbStatus.AppendText("Found " + SetCount.ToString() + " rulesets!\n");
        }

        /// <summary>
        /// Moves the rulesets to the proper folder
        /// </summary>
        /// <param name="isConfigInRoot">Whether the .succ is directly in the temp directory or in a subdirectory</param>
        /// <param name="Name">Either the name of the .succ or the name of the subdirectory</param>
        private void FileHandling(bool isConfigInRoot, string Name)
        {
            //if (isConfigInRoot)
            //{
            //    DataFile dataFile = new DataFile(Path.Combine(AppContext.BaseDirectory + @"\temp\") + Name);
            //    string id = dataFile.Get<string>("ID");
            //    Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory + @"\rulesets\", id));
            //    string[] files = Directory.GetFiles(AppContext.BaseDirectory + @"\temp\");
            //    foreach (string file in files)
            //    {
            //        File.Move(AppContext.BaseDirectory + @"\temp\" + file, Path.Combine(AppContext.BaseDirectory + @"\rulesets\" + Name) + file);
            //    }
            //}
            //else
            //{
            //    Directory.Move(Path.Combine(AppContext.BaseDirectory + @"\temp", Name), AppContext.BaseDirectory + @"\rulesets\" + Name);
            //}
        }
    }
}
```
### Rulesets

Bevor wir uns den eigentlichen Editor genauer anschauen, werden wir einen Blick auf die eigentlichen Rulesets werfen und wie diese aufgebaut sind und gespeichert werden.

```c#
[XmlRoot("configuration")]
[XmlInclude(typeof(Templates.Template2D))]
[XmlInclude(typeof(Templates.Platformer))]
[XmlInclude(typeof(Events.CustomEvent))]
[XmlInclude(typeof(Events.StartupEvent))]
[XmlInclude(typeof(Events.ShutdownRequestEvent))]
[XmlInclude(typeof(Events.KeyPressEvent))]
[XmlInclude(typeof(Events.TickEvent))]
[XmlInclude(typeof(Actions.Avoid))]
[XmlInclude(typeof(Actions.Click))]
[XmlInclude(typeof(Actions.ExecuteCustomEvent))]
[XmlInclude(typeof(Actions.Log))]
[XmlInclude(typeof(Actions.Move))]
[XmlInclude(typeof(Actions.OverlayLog))]
[XmlInclude(typeof(Worlds.GameWorld))]
[XmlInclude(typeof(Worlds.StartupWorld))]
public class Configuration
{
    public Configuration()
    {
        Name = "Default Name";
        ID = "defaultid";
        Executable = "";
        Template = new Platformer();
        CustomEvents = new List<Event>();
        LeftSideObjects = new List<LeftSide>();
    }

    public String Name;
    public String ID;
    public String Executable;
    public Template Template;
    public List<Event> CustomEvents;
    public List<LeftSide> LeftSideObjects;

    [XmlIgnore]
    public string Folder;

    /// <summary>
    /// Saves the specified ruleset as an XML to the specified path
    /// </summary>
    /// <param name="ruleset">The ruleset to be saved</param>
    public static void Save(Configuration ruleset)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
        TextWriter writer = new StreamWriter(Path.Combine(Utility.RulesetDirectory + ruleset.Folder) + "\\config.xml");
        serializer.Serialize(writer, ruleset);
        writer.Flush();
        writer.Close();
    }

    /// <summary>
    /// Deletes a ruleset
    /// </summary>
    public void Delete()
    {
        MainForm Main = MainFormHelper.Get();
        Main.Games.Remove(this);
        Main.UpdateList();
        Directory.Delete(Path.Combine(Utility.RulesetDirectory, Folder), true);
    }

    /// <summary>
    /// Checks if the executable specified in the StartAction property is valid
    /// </summary>
    /// <returns>Whether the start action is valid or not</returns>
    public bool ValidAction()
    {
        if (File.Exists(Executable) && Executable.EndsWith(".exe"))
            return true;
        return false;
    }

    /// <summary>
    /// Loops over every folder inside the ruleset directory and looks for valid config.xml files. Valid configurations are added to the list of the  main form.
    /// </summary>
    public static void DiscoverRulesets()
    {
        if (!Directory.Exists(Utility.RulesetDirectory))
        {
            Directory.CreateDirectory(Utility.RulesetDirectory);
            return;
        }

        foreach (string directory in Directory.GetDirectories(Utility.RulesetDirectory))
        {
            string file = directory + "\\config.xml";
            if (!File.Exists(file))
                continue;

            XmlSerializer deserializer = new XmlSerializer(typeof(Configuration));
            TextReader reader = new StreamReader(file);
            try
            {
                object obj = deserializer.Deserialize(reader);
                Configuration ruleset = (Configuration)obj;
                reader.Close();
                string[] pathElements = directory.Split('\\');
                ruleset.Folder = pathElements[pathElements.Length - 1];
                MainFormHelper.Get().Games.Add(ruleset);
            }
            catch
            {
                reader.Close();
                continue;
            }
        }
    }
}

```

### Editor

#### Metadata-Editor

#### Cropping-Tool

TODO: Image

Das Cropping-Tool kann dazu verwendet werden, um den wichtigen Bereich eines Referenzbildes aus dem ünnötigen Rest herauszuschneiden und gesondert, als eigentliche Referenz zu speichern.

```c#
public partial class ImageEditor : Form
{
    private World.ImageRecognition item;
    private Image loadedImage;
    private Bitmap @new;
    private int x;
    private int y;
    private int width;
    private int height;
    private Pen CropPen = new Pen(Color.Red);
    private bool cropping = false;

    public ImageEditor(World.ImageRecognition item = null)
    {
        InitializeComponent();
        this.item = item;
    }

    ~ImageEditor()
    {
        CropPen.Dispose();
        loadedImage.Dispose();
        @new.Dispose();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        openFileDialog1.ShowDialog();
        openFileDialog1.FileOk += fileSelected;
    }

    private void fileSelected(object sender, CancelEventArgs e)
    {
        FileStream fs = new FileInfo(openFileDialog1.FileName).OpenRead();
        loadedImage = Image.FromStream(fs);
        pictureBox1.Image = Utility.ResizeImage(loadedImage, pictureBox1.Width, pictureBox1.Height);
        fs.Close();
    }

    private void ImageEditor_Load(object sender, EventArgs e)
    {
        openFileDialog1.InitialDirectory = AppContext.BaseDirectory;
        cropWindow = pictureBox1.CreateGraphics();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        //item.UpdateReference(@new);
        pictureBox2.Image = pictureBox2.Image;
        pictureBox3.Image = null;
    }

    private void button2_Click(object sender, EventArgs e) => Close();

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        x = e.X;
        y = e.Y;
        cropping = true;
    }

    private Rectangle Selection;

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        if (loadedImage == null)
            return;

        width = e.X - x;
        height = e.Y - y;
        if (width > 0 && height > 0)
        {
            Selection = new Rectangle(x, y, width, height);
            Bitmap test = Utility.ResizeImage(new Bitmap(loadedImage), pictureBox1.Width, pictureBox1.Height);
            @new = test.Clone(Selection, loadedImage.PixelFormat);
            pictureBox3.Image = @new;
        }
        Reset();
    }

    private void Reset()
    {
        cropping = false;
        x = 0;
        y = 0;
        width = 0;
        height = 0;
    }

    private Graphics cropWindow;

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (cropping && loadedImage != null)
        {
            cropWindow = pictureBox1.CreateGraphics();
            cropWindow.DrawImage(Utility.ResizeImage(loadedImage, pictureBox1.Width, pictureBox1.Height), new Point(0, 0));
            width = e.X - x;
            height = e.Y - y;
            cropWindow.DrawRectangle(CropPen, x, y, width, height);
        }
    }
}
```