# InventurListe
Das Abschlussprojekt meiner Ausbildung

**Beschreibung:**

In diesem Projekt geht es darum eine Datenbank zur Speicherung der Geräteinventur zu erstellen. Der Zugriff soll über eine Grafische Nutzeroberfläche erfolgen. Als Vorlage dient eine Excel-Liste. 

## Ist und Soll
**Ist:**

Im Moment pflegen wir die Inventur unserer Computer, Laptops und Drucker in einer Excel-Liste. Dies ist einerseits unpraktisch, da nur eine Person gleichzeitig die Liste bearbeiten kann und so öfters vergessen wird, Änderungen umzutragen. Andererseits werden Daten nicht einheitlich geschrieben. Beim einen heißt der Rechner HP400 beim anderen HP 400 Mini oder HP Mini. Das Konzept zum Benennen der Maschinen wird auch nicht immer eingehalten. Normalerweise wäre es Typ-Standort-Name, z.B. als Workstation im CCB Bethanien WS-CCB-BK420 allerdings werden hier oftmals teile des Namens vergessen oder falsch geschrieben. 
Die Tabelle hat folgende Spalten: Abteilung, Haus, Stockwerk, User, Gerät (Gerätebezeichnung), Typ (PC/Drucker/Laptop), OS, Name, IP, MAC, Inventarnummer, Vianova-Nr., ID (Für geliehene Drucker), Anmerkung. 

**Soll:**

Deshalb wäre es gut, alles geordnet in einer Datenbank zu haben, auf die mehrere User gleichzeitig zugreifen können. Das ganze wird auf einem IIS-Webserver unter Windows 10 laufen. Über ein Web Frontend soll auch von Mobilgeräten zugegriffen werden können. Eine GUI soll hierbei die Eintragung vereinfachen. Bei häufig vorkommenden Einträgen wie z.B. dem Model wären Drop-Down Listen praktisch, da diese gewährleisten, dass Beschreibungen nicht abweichen. Freie Eingaben, die einer bestimmten Struktur folgen, wie z.B. Namen, sollen durch einen Algorithmus auf die Einhaltung der Norm überprüft werden.

## Daraus ergeben sich für mich folgende Arbeitsschritte:
- [ ] Server aufsetzen - Windows mit IIS-Webserver 
- [ ] DB Erstellen (C#, ADO.NET)
   - [ ] Modelle für die einzelnen Tabellen erstellen
   - [ ] Tabellen miteinander verknüpfen
- [ ] Frontend erstellen (Aufgeteilt in 3 Seiten) 
   - [ ] Home-Seite (Übersicht und kurze Info über das Programm)
   - [ ] Inventur-Seite (Zeigt die Daten an | Funktionalität zum bearbeiten und löschen von Daten)
   - [ ] Neuer Eintrag (Name WIP) (Bietet eine Forlage um das Eintragen neuer Geräte zu erleichtern | Hierzu gehören z.B. Drop-Down Menüs für vorgegebene Werte wie z.B. Standort oder Stockwerk)
     - [ ] Überprüfung des Computernamens mittels RegEX (Gewährleistet, dass die Namen der Benamungskonvention konform sind)
   - [ ] Styling der Seiten mittels CSS (Als Vorlage dient die [Firmenwebsite](https://www.ccb.de))

