<p align="center">
  <img src="https://github.com/gstratigopoulos96/Asteko_KTEL/blob/master/MobileApp/Icons/Icon.png" alt="image" width="500" height="400"/>
</p>

# Αστeκό ΚΤΕΛ

Το Αστeκό ΚΤΕΛ είναι μια εφαρμογή που αναπτύχθηκε στα πλαίσια της εξαμηνιαίας εργασίας στο προπτυχιακό μάθημα της Τεχνολογίας Λογισμικού. Η ιδέα της ομάδας μας ήταν να φτιάξουμε ένα σύστημα το οποίο συμβάλλει στην αποσυμφόρηση του αστικού κτελ της Πάτρας κατα της περίοδο της πανδιαμίας του κορονοϊού. Η λογική πάνω στην οποία δουλεύει η εφαρμογή είναι ότι όταν κάποιος θέλει επιβιβαστεί σε κάποιο δρομολόγιο θα πρέπει προηγουμένος να έχει αγοράσει εισιτήριο μέσω της εφαρμογής με την προϋπόθεση ότι το πλήθος των επιβατών δεν υπερβεί ένα άνω φράγμα (threshold) που έχει οριστεί ώστε να μην υπάρχει συνωστισμός. Επιπλέον ο οδηγός ενός λεωφορείου θα μπορεί να καταγγέλει μέσω της εφαρμογής κάποιον πελάτη-επιβάτη αν δεν τηρεί τα μέτρα ύγειονομικής προστασίας που έχουν οριστεί από το Υπουργείο υγείας.

## Μέλη ομάδας

Γερογιάννης Δημήτριος  
Κύρος Στέργιος  
Στρατηγόπουλος Γεώργιος  
Τριπολίτης Ιωάννης-Νικόλαος 

## Γλώσσα προγραμματισμού

Η γλώσσα προγραμματισμού στην οποία γράφτηκε η εφαρμογή είναι η Visual C# της Microsoft.

## Framework

Το framework στο οποίο γράφτηκε η εφαρμογή είναι το .net Core 3.1. Επίσης το GUI κατασκευάστηκε μέσω της τεχνολογίας Windows Forms που προσφέρει η γλώσσα.

## Σχετικά με την εφαρμογή

Οι ρόλοι της εφαρμογής είναι οι ακόλουθοι:
1. Πελάτης-Επιβάτης
2. Οδηγώς λεωφορείων
3. Προϋστάμενος
4. Υπεύθυνος κατανομής δρομολογίων
5. Υπεύθυνος διασφάλισης υπηρεσιών

Η εφαρμογή αποτελείται από 3 solutions.

1. Classes  
2. DesktopApp  
3. MobileApp

Το solution **Classes** περιέχει τις κλάσεις που χρησιμοποιούνται στην εφαρμογή. Το solution **DesktopApp** περιέχει το GUI των ρόλων *προϋστάμενος*, *υπεύθυνος κατανομής δρομολογίων*, *υπεύθυνος διασφάλισης υπηρεσιών*. Τέλος το solution **MobileApp** περιέχει το GUI των ρόλως *οδηγών λεωφορείων* και *πελάτης-επιβάτης*.

## Οδηγίες για να μπορέσετε να τρέξετε την εφαρμογή

Θα πρέπει αρχικά να διαθέτε εγκατεστημένη την **MySQL**. Επίσης θα πρέπει να ρυθμίσετε το **ConnectionString** που υπάρχει στην κλάση **ConnectionInfo** μέσα στο solution **Classes** αλλάζοντας τα πεδία *server*, *userid*, *password* και *database* ανάλογα με το όνομα του server που θα φτιάξετε, το userid, password καθώς και το όνομα της βάσης(database πεδίο).

```csharp
public static class ConnectionInfo
{
    public static string ConnectionString => @"server=localhost;userid=root;password=1234;database=project_db";
}
```

