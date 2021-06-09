# TOP2000 - Android legends

<img src="https://www.maxvandaag.nl/wp-content/uploads/2016/11/top2000_radio2_1100_300.jpg" alt="TOP2000 logo">
<br/>
@ Android Legends | 2021

In dit project bouwen wij, in opdracht van het ROC van Twente in Hengelo, een MVC applicatie over de TOP2000. Dit wordt in de taal C# gedaan.

<br/><br/>
## HOE TE INSTALLEREN
<hr/>
1. Clone de repository naar een gewenste locatie op uw pc.<br/><br/>
2. Migreer de TOP2000 database in een MySQL server. De database kan gevonden worden in `/migraties/TOP2000-official-migration.sql`. (Dit bestand maakt ook gelijk de database aan, dus niet zelfstandig een database aanmaken!).<br/><br/>
3. Open daarna de `/TOP2k2021/` map in Visual Studio. Kopieer vervolgens het `appsettings.json.example` bestand en hernoem deze naar `appsettings.json`.<br/><br/>
4. Open `appsettings.json` en verander `[FILL IN]` naar uw eigen inloggegevens. Voor meer connectie-strings, ga naar https://www.connectionstrings.com/.<br/><br/>
5. Open vervolgens de `/TOP2k2021/` map in een terminal-sessie en voer het volgende commando uit om de applicatie-migratie uit te voeren: [dotnet ef database update].<br/><br/>
6. Wanneer dit is voltooid, kunt u de applicatie starten door middel van het volgende commando: [dotnet run]. De applicatie is vervolgens te bezoeken op http://localhost:5000/.<br/><br/>
