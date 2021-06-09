<p align="center">
  <img src="https://github.com/gstratigopoulos96/Asteko_KTEL/blob/master/MobileApp/Icons/Icon.png" alt="image" width="500" height="400"/>
</p>

# Αστeκό ΚΤΕΛ

Το Αστeκό ΚΤΕΛ είναι μια εφαρμογή που αναπτύχθηκε στα πλαίσια της εξαμηνιαίας εργασίας στο προπτυχιακό μάθημα της Τεχνολογίας Λογισμικού. Η ιδέα της ομάδας μας ήταν να φτιάξουμε ένα σύστημα το οποίο συμβάλλει στην αποσυμφόρηση του αστικού κτελ της Πάτρας κατα της περίοδο της πανδιαμίας του κορονοϊού. Η λογική πάνω στην οποία δουλεύει η εφαρμογή είναι ότι όταν κάποιος θέλει επιβιβαστεί σε κάποιο δρομολόγιο θα πρέπει προηγουμένος να έχει αγοράσει εισιτήριο μέσω της εφαρμογής με την προϋπόθεση ότι το πλήθος των επιβατών δεν υπερβεί ένα άνω φράγμα (threshold) που έχει οριστεί ώστε να μην υπάρχει συνωστισμός. Επιπλέον ο οδηγός ενός λεωφορείου θα μπορεί να καταγγέλει μέσω της εφαρμογής κάποιον πελάτη-επιβάτη αν δεν τηρεί τα μέτρα ύγειονομικής προστασίας που έχουν οριστεί από το Υπουργείο υγείας.

## Μέλη ομάδας

[Γερογιάννης Δημήτριος](https://github.com/dimitrisgerog)  
[Κύρος Στέργιος](https://github.com/stergioskyros)  
[Στρατηγόπουλος Γεώργιος](https://github.com/gstratigopoulos96)  
[Τριπολίτης Ιωάννης-Νικόλαος](https://github.com/JohnTripGR) 

## Γλώσσα προγραμματισμού

Η γλώσσα προγραμματισμού στην οποία γράφτηκε η εφαρμογή είναι η Visual C# της Microsoft.

## Framework

Το Framework στο οποίο γράφτηκε η εφαρμογή είναι το .net Core 3.1. Επίσης το GUI κατασκευάστηκε μέσω της τεχνολογίας Windows Forms που προσφέρει η γλώσσα.

## Σχετικά με την εφαρμογή

Οι ρόλοι της εφαρμογής είναι οι ακόλουθοι:
1. Πελάτης-Επιβάτης
2. Οδηγός λεωφορείων
3. Προϊστάμενος
4. Υπεύθυνος κατανομής δρομολογίων
5. Υπεύθυνος διασφάλισης υπηρεσιών

Η εφαρμογή αποτελείται από 3 solutions.

1. Classes  
2. DesktopApp  
3. MobileApp

Το solution **Classes** περιέχει τις κλάσεις που χρησιμοποιούνται στην εφαρμογή. Το solution **DesktopApp** περιέχει το GUI των ρόλων *προϊστάμενος*, *υπεύθυνος κατανομής δρομολογίων*, *υπεύθυνος διασφάλισης υπηρεσιών*. Τέλος το solution **MobileApp** περιέχει το GUI των ρόλων *οδηγός λεωφορείων* και *πελάτης-επιβάτης*.

## Οδηγίες για να μπορέσετε να τρέξετε την εφαρμογή

**Προσοχή: Η εφαρμογή τρέχει μόνο στα windows 10.**

### 1ο στάδιο
Θα πρέπει αρχικά να διαθέτε εγκατεστημένη την **MySQL**. Επίσης θα πρέπει να ρυθμίσετε το **ConnectionString** που υπάρχει στην κλάση **ConnectionInfo** μέσα στο solution **Classes** αλλάζοντας τα πεδία *server*, *userid*, *password* και *database* ανάλογα με το όνομα του server που θα φτιάξετε, το userid, password καθώς και το όνομα της βάσης(database πεδίο).

```csharp
public static class ConnectionInfo
{
    public static string ConnectionString => @"server=localhost;userid=root;password=1234;database=project_db";
}
```

### 2ο στάδιο
Θα πρέπει να φτιάξετε την βάση με τη χρήση του κώδικα της βάσης που θα βρείτε στο [αρχείο](https://github.com/gstratigopoulos96/Asteko_KTEL/blob/master/databasesrc.sql) της βάσης.

### 3ο στάδιο
Θα πρέπει να κάνετε:

1. Ανοίγεται το αρχείο **SoftwareTechnologyProject.sln** με τη χρήση του Visual Studio 2019.
1. Build (F6).
2. Επιλογή Debug ή Release mode.
3. Επιλογή **DesktopApp** ή **MobileApp**.
4. Run.

Παρακάτω φαίνονται μερικές φωτογραφίες που δείχνουν τη σειρά των βημάτων.

<p align="center">
  <img src="https://github.com/gstratigopoulos96/Asteko_KTEL/blob/master/Photos/openproject.png" alt="image"/>
  <img src="https://github.com/gstratigopoulos96/Asteko_KTEL/blob/master/Photos/build.jpg" alt="image"/>
  <img src="https://github.com/gstratigopoulos96/Asteko_KTEL/blob/master/Photos/debug-release%20mode.png" alt="image"/>
  <img src="https://github.com/gstratigopoulos96/Asteko_KTEL/blob/master/Photos/select%20project.png" alt="image"/>
</p>

Εναλλακτικά μετά την ολοκλήρωση των παραπάνω βημάτων για για τα 2 projects (DekstopApp, MobileApp) θα μπορείτε να ανοίξετε την εφαρμογή χωρίς τη χρήση του Visual Studio 2019 απλά κάνοντας execute τα αρχεία **DesktopApp.exe** ή **MobileApp.exe** που θα δημιουργηθούν στους παρακάτω φακέλους ανάλογα με το αν έχετε κάνει Run σε Debug ή Release mode.

`...\DesktopApp\bin\Debug\netcoreapp3.1\`  
`...\DesktopApp\bin\Release\netcoreapp3.1\`  
`...\MobileApp\bin\Debug\netcoreapp3.1\`  
`...\MobileApp\bin\Release\netcoreapp3.1\`  

#### Προσοχή
Δεν θα μπορέσετε να τρέξετε την εφαρμογή μέσω των **DesktopApp.exe** ή **MobileApp.exe** αν τα μετακινήσετε σε κάποιο άλλο φάκελο όπου δεν υπάρχουν τα υπόλοιπα αρχεία του αντίστοιχου φακέλου `...\netcoreapp3.1` από τον οποίο πήρατε το executable.

## License
[MIT](https://choosealicense.com/licenses/mit/)
