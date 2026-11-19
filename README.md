# NO-FISH

Ein rundenbasiertes Roguelike für das Terminal, entwickelt in C# (.NET 10).

## Voraussetzungen

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Starten

1. ZIP-Datei entpacken.
2. Ein Terminal öffnen und in den Ordner `project` wechseln:
   ```bash
   cd NO-FISH/project
   ```
3. Das Terminal leeren:
   ```bash
   clear      # Linux / macOS (Bash)
   ```
   ```bat
   cls        # Windows (Eingabeaufforderung oder PowerShell)
   ```
4. Das Spiel starten:
   ```bash
   dotnet run
   ```

> **Warum vorher leeren?** Das Spiel zeichnet seine Menüs ab der aktuellen Cursorposition neu. Steht noch alter Text im Terminal, kann die Darstellung verrutschen oder überlagert werden.

## Spielablauf

1. **Hauptmenü:** Spiel starten, Einstellungen öffnen oder beenden.
2. **Erkundung:** Du wählst ein Gebiet (*The Beach* oder *The Forest*). Jedes Gebiet zeigt seine möglichen Ereignisse samt Wahrscheinlichkeit an. Nach der Auswahl wird zufällig ein Ereignis ausgelöst:
   - **Kampf** gegen einen Gegner
   - **Beute**, z. B. Heiltränke oder Gold
3. **Kampf:** Rundenbasiert. Du wählst eine Aktion, danach greift der Gegner an.
   - **Attack:** Schaden in Höhe deiner Stärke, mit Chance auf einen kritischen Treffer (doppelter Schaden)
   - **Heal:** +5 HP, sofern du einen Heiltrank besitzt
   - **Escape:** 50 % Chance zu fliehen
4. Ein Sieg bringt Gold und führt zurück zur Erkundung. Sinken deine HP auf 0, ist das Spiel vorbei (**Game Over**).

> Tipp: Das Monster im Wald ist sehr stark – hier ist Flucht meist die bessere Wahl.

## Steuerung

| Taste | Funktion |
| --- | --- |
| `↑` / `↓` | Auswahl in Menüs bewegen |
| `Enter` | Auswahl bestätigen / Einstellung umschalten |
| `Z` | Einstellungsmenü verlassen |
| beliebige Taste | Nach Meldungen weiter |
