using Microsoft.Win32;
using System.Windows;
using System.IO;
namespace NiceCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <Glossar>
    /// CRUD = create, read, update, delete
    /// </Glossar>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Importiert das Objekt, damit man alle Methoden und etc benutzen kann.
            OpenFileDialog openExplorer = new OpenFileDialog();
            //Titel des Explorer Fensters oben Links
            openExplorer.Title = "Bitte eine/mehrere Dateien auswählen";
            //Dateityp Filtert
            openExplorer.Filter = "Alle files (*.*)|*.*|Nur Text files (*.txt)|*.txt";

            //öffnet denn Explorer
            if (openExplorer.ShowDialog() == true)
            {
                //Kompletter Dateipfad wird gespeichert
                string path = openExplorer.FileName;
                MessageBox.Show($"Die ausgewählte Datei: {path}");
                //In der Textbox wird der Inhalt == path gemacht
                FileName.Text = path;
                //Speichert jede Zeile des Files in je einem Array
                string[] lines = File.ReadAllLines(path);
                //Liste für die angepassten Zeilen (Listen sind einfacher für CRUD)
                List<string> newLines = new List<string>();
                //Loop durch jede Zeile durch
                foreach (string line in lines)
                {
                    //Falls Zeile leer, nicht in Liste hinzufügen
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    
                    newLines.Add(line);
                    //Wenn Zeile == }, dann wird eine leere Zeile hinzugefügt
                    if (line.Trim() == "}")
                    {
                        newLines.Add("");
                    }

                }
                //Liste kann nicht in String geschrieben werden (Environment.newLine == standartisierte Funktion, um einen Zeilenumbruch für egal welches Betriebssystem)
                string newContent = string.Join(Environment.NewLine, newLines);
                //Überschreibt File mit angegebenem Content in path xy
                File.WriteAllText(path, newContent);
                MessageBox.Show("OK");
            }

        }

    }

}
