using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Millionaire
{
    public partial class Form1 : Form
    {   
        //variables
        public static int level = 0;
        public static int intro = 0;
        //for randomly seeding the answers to textboxes
        public static int ans1;
        public static int ans2;
        public static int ans3;
        public static int ans4;
        //variables for 50 50 elimination
        public static int f;
        public static int k;
        public static int button50o=0;
        public static int audienceo=0;
        //variables for the audience
        public static int rchoice;
        public static int number1;
        public static int number2;
        public static int number3;
        public static int number4;
        public static int number5;
        //this is for a random questiong from 0-9
        public static int question;
        //counters for blinking effect
        public static int timer = 0;
        public static int timerx = 0;
        //counter for timer
        public static int timerA = 0;
        public static int timerLose = 0;
        public static int timerWin= 0;
   

        //audio
        System.Media.SoundPlayer CD = new SoundPlayer(Properties.Resources.Countdown);
        System.Media.SoundPlayer fiftyfifty = new SoundPlayer(Properties.Resources._50_50);
        System.Media.SoundPlayer soundC = new SoundPlayer(Properties.Resources.correctAnswer);
        System.Media.SoundPlayer soundA1 = new SoundPlayer(Properties.Resources.wrongA1);
        System.Media.SoundPlayer suspence = new SoundPlayer(Properties.Resources.suspence2);
        System.Media.SoundPlayer Milans = new SoundPlayer(Properties.Resources.RA3);
        //end of audio


        //All the questions
        string[][,] jag = new string[15][,]
        {
new string[10, 5]   {
 { "Ποιος έγραψε τον μύθο του λαγού και της χελώνας", "Ο Αίσωπος","Ο Ευγένιος Τριβιζάς","Ο Άντερσεν","Ο Κάρολος Ντίκενς"} ,
 { "Ποια η επίσημη γλώσσα της Βραζιλίας", "Η Πορτογαλική","Η Γαλλική","Η Αγγλική","Η Ισπανική"} ,
 { "Ποια η ωραιότερη Θεά", "Η Αφροδίτη","Η Αθηνά","Η Ήρα","Η Δήμητρα"} ,
{ "Ποιος ο μικρότερος πλανήτης του ηλιακού μας συστήματος", "Ο Ερμής","Ο Άρης","Η Αφροδίτη","Ο Δίας"} ,
{ "Ποια η έδρα της Μπάγιερν","Το Μόναχο","Το Βερολίνο","Η Στουτγκάρδη","Το Ντορτμουντ" } ,
{ "Σε ποιό νησί του Ιονίου πηγαίνουν οι χελώνες καρέτα-καρέτα για να γεννήσουν τα αυγά τους ","Ζάκυνθος","Ιθάκη","Μύκονο","Ικαρία" } ,
{ "Ποιός Άγγλος συγγραφέας έγραψε το βιβλίο 'Όλιβερ Τουίστ'", "Ο Κάρολος Ντίκενς","Ο Ιούλιος Βέρν","Ο Μαρκ Τουέν","Ο Βίκτωρ Ουγκώ"} ,
{ "Ποιός ο θεός της θάλασσας και κυβερνήτης του ωκεανού", "Ο Ποσειδώνας","Ο Απόλλωνας","Ο Ήφαιστος","Ο Άρης"} ,
{ "Ποιό το βραβείο για τις καλύτερες κινηματογραφικές ταινίες", "OSCAR","ΕΜΜΥ","GRAMMY","RASPBERRY"} ,
{ "Ποιά η θεα της σοφίας ", "Αθηνά","Δημητρα","Αρτεμις","Ηρα"} ,
},
  new string[10, 5]   {
 { "Πόσες ήταν οι μούσες", "9","7","12","4"} ,
 { "Ποιο είναι το πιο δυνατό ναρκωτικό", "Η ηρωίνη","Η κοκκαίνη","Το χασίσι","Η μορφίνη"} ,
 { "Ποια είναι τα χρώματα του ΑΡΗ", "Κίτρινο-μαύρο","Κόκκινο-λευκό","Μωβ-Μπλε","Πράσινο-λευκό"} ,
{ "Σε ποια ήπειρο ζει η ζέμπρα", "Αφρική","Ασία","Ευρώπη","Αυστραλία"} ,
{ "Πόσες μέρες διαρκεί το μοντέρνο πένταθλο", "5 μέρες","10 μέρες","3 μέρες","7 μέρες"} ,
{ "Ποιον κράτησε στο νησί της 7 χρόνια η Καλυψώ", "Τον Οδυσσέα","Τον Αγαμέμνωνα","Τον Αχιλλέα","Τον Μενέλαο"} ,
{ "Ποιά η σύζυγος του Δία", "Ήρα","Ευρώπη","Αλκμήνη","Περσεφόνη"} ,
{ "Σε ποιό νομό ανήκει η Χίος ", "Νομό Χίου ","Νομό Λέσβου ","Νομό Καλύμνου","Νομό Ρόδου"} ,
{ "Κάθε πόσα χρόνια γίνεται το κύπελλο εθνών Ευρώπης", "Κάθε 4 χρόνια","Κάθε 2 χρόνια","Κάθε 3 χρόνια","Κάθε 5 χρόνια"} ,
{ "Πώς λέγεται το σύνολο των οστών του ανθρώπου", "Σκελετός","Οστά","Κόκκαλα","Σπονδυλική Στήλη"} ,
},
  new string[10, 5]    {
 { "Από ποια χώρα είναι το τυρί χαλούμι", "Κύπρο","Τουρκία","Ελλάδα","Αρμενία"} ,
 { "Ποιος ήταν ο Θεός του κρασιού και των διασκεδάσεων", "Ο Δίονυσος","Ο Απόλλωνας","Ο Ήφαιστος","Ο Άρης"} ,
 { "Ποιος έκοψε το κεφάλι της Μέδουσας", "Ο Περσέας","Ο Θησέας","Ο Ηρακλής","Ο Πρίαμος"} ,
{ "Ποιος ο βοηθός του Μπάτμαν", "Ρομπιν","Κατ Γουμαν","Τζόκερ","Σούπερμαν"} ,
{ "Πόσες οι λίμνες της Κρήτης", "1","4","0","6"} ,
{ "Ποια είναι η ελληνική ονομασία του πινκ πονκ", "Επιτραπέζια αντισφαίριση","Επιτραπέζια καλαθοσφαίριση","Επιτραπέζια υδατοσφαίριση","Επιτραπέζια πετοσφαίριση"} ,
{ "Πώς λεγόταν ο γιός του Δαίδαλου", "Ίκαρος","Πέρσης","Περικλής","Αχιλλέας"} ,
{ "Ποιον είχε άνδρα η ωραία Ελένη", "Τον Μενέλαο","Τον Πάρη","Τον Αγαμέμνονα","Τον Αχιλλέα"} ,
{ "Ποια δυο βασικά χρώματα μαζί κάνουν το μωβ", "Κόκκινο-μπλε","Κίτρινο-Πράσινο","Πορτοκαλί-Μπλε","Πράσινο-Μπλε"} ,
{ "Ποιος άρπαξε την ωραία Ελένη", "Ο Πάρις","Ο Δίας","Ο Έκτορας","Ο Αχιλλέας"} ,
},
  new string[10, 5]   {
 { "Από τι γίνεται η μπύρα", "Από το κριθάρι","Από το καλαμπόκι","Από το μέλι","Από λέπια ψαριών"} ,
 { "Πόσες θηλές έχει η αγελάδα", "4","6","8","12"} ,
 { "Ποιο το βασικό όργανο για τους ποντιακούς χορούς", "Η λύρα","Το μπουζούκι","Το ντέφι","Το αρμόνιο"} ,
{ "Ποια ομάδα του ΝΒΑ έχει την προσωνυμία 'κακά παιδιά'", "Detroit Pistons","Lakers","Celtics","Chicago Bulls"} ,
{ "Ποια χώρα κατασκευάζει τα αυτοκίνητα Ρολς-Ρόυς", "Η Αγγλία","Η Ιαπωνία","Η Γερμανία","Η Ιταλία"} ,
{ "Ποιος ήταν ο πιο άσχημος θεός του Ολύμπου", "Ο Ήφαιστος","Ο Άρης","Ο Ποσειδώνας","Ο Ερμής"} ,
{ "Πώς αλλιώς είναι γνωστό το χλωριούχο νάτριο", "Αλάτι","Κάρβουνο","Ασήμι","Σόδα"} ,
{ "Ποιον έλεγαν 'Γέρο του Μοριά'", "Τον Θεόδωρο Κολοκοτρώνη","Τον Αθανάσιο Διάκο","Τον Οδυσσέα Ανδρούτσο","Τον Ανδρέα Μιαούλη"} ,
{ "Πώς ονομάζεται το στρώμα του αέρα που περιβάλλει την Γη", "Ατμόσφαιρα","Στρατόσφαιρα","Τροπόσφαιρα","Μεσόσφαιρα"} ,
{ "Ποιο το μικρό όνομα του Καζαντζάκη", "Νικόλαος","Κωνσταντίνος","Χρήστος","Ιωάννης"} ,
},
  new string[10, 5]  {
{ "Που είναι το μεγαλύτερο μουσείο του κόσμου", "Στο Παρίσι","Στο Βερολίνο","Στο Λονδίνο","Στην Νέα Υόρκη"} ,
{ "Ποια Θεά βγήκε απ τους αφρούς της θάλασσας", "Η Αφροδίτη","Η Δήμητρα","Η Ρέα","Η Άρτεμις"} ,
{ "Πόσα χρόνια ζει η αγγουριά", "1","2","5","7"} ,
{ "Ποιος ο ιδρυτής της Μαθηματικής επιστήμης", "Ο Πυθαγόρας","Ο Θεμιστοκλής","Ο Αρχιμήδης","Ο Σοφοκλής"} ,
{ "Ποιος ο αρχηγός των Περσών στη μάχη των Πλαταιών", "Ο Μαρδόνιος","Ο Ηρόδοτος","Ο Παυσανίας","Ο Δαρείος"} ,
{ "Πού βρίσκεται ο θηροειδής αδένας στον άνθρωπο", "Στον λαιμό","Στον οισοφάγο","Στον φάρυγγα","Στον λάρυγγα"} ,
{ "Σε ποια ξένη χώρα πίνεται περισσότερο ούζο εκτός από την Ελλάδα", "Στην Γερμανία","Στην Ουκρανία","Στην Αυστρία","Στην Ρουμανία"} ,
{ "Ποιους νίκησε ο Δίας και εγκαταστάθηκε στον Όλυμπο", "Τους Τιτάνες","Τους Γίγαντες","Τα θεία όντα","Τους Μαινάδες"} ,
{ "Ποια χώρα έχει τους περισσότερους σεισμούς", "Η Ιαπωνία","Η Ελλάδα"," Η Ινδονησία","Το Εκουαδόρ"} ,
{ "Ποιος ήταν ο τερματοφύλακας του Άγιαξ της χρυσής εποχής", "Ο Στόουι","Ο Μπέρκαμ","Ο Μποέρ","Ο Άλμπλας"} ,
},
  new string[10, 5]  {
 { "Ποια η χώρα που προήρθε το σκάκι", "Η Ινδία","Η Αίγυπτος","Η Ιαπωνία","Η Γαλλία"} ,
 { "Ποια ομάδα κέρδισε το πρώτο μουντιάλ", "Η Ουρουγουάη","Η Αργεντινή","Η Βραζιλία","Η Γαλλία"} ,
 { "Ποιος ο πολιούχος της Αγγλίας", "Ο Άγιος Γεώργιος","Ο Άγιος Νικόλαος","Ο προφήτης Ηλίας","Ο Άγιος Αθανάσιος"} ,
{ "Ποιο ελληνικό νησί λεγόταν Σκαρπάντο", "Η Κάρπαθος","Η Αίγινα","Η Αμοργός","Η Κως"} ,
{ "Πόσες εθνικές ομάδες έχει η Μεγ. Βρετανία", "4 ομάδες","1 ομάδα","5 ομάδες","2 ομάδες"} ,
{ "Σε ποιο μέρος του κόσμου παίζεται πιο πολύ το πόλο", "Στην Αργεντινή","Στην Βραζιλία","Στην Αυστραλία","Στην Αγγλία"} ,
{ "Πόσα μινωϊκά ανάκτορα ανακαλύφθηκαν στην Κρήτη", "4","3","6","7"} ,
{ "Ποια λίμνη βρέχει την Ελλάδα, την Αλβανία και την Γιουγκοσλαβία", "Η Πρέσπα","Η Βεγορίτιδα","Η Κερκίνη","Η Βόλβη"} ,
{ "Πόσους κατοίκους είχε η Αθήνα στις αρχές του αιώνα", "165.000","240.000","125.000","93.000"} ,
{ "Ποια εθνικότητα είχε ο Ανδρέας Κέλσιος", "Σουηδική","Νορβηγική","Λετονική","Ελβετική"} ,
},
  new string[10, 5]  {
 { "Που εφευρέθηκε το μπάσκετ", "Στην Μασσαχουσέτη","Στην Ουρουγουάη","Στην Γουατεμάλα","Στην Βενεζουέλα"} ,
 { "Ποιος ο μακρύτερος ποταμός της Γαλλίας", "Ο Λίγηρας","Ο Ρήνος","Ο Γαρούνας","Ο Σηκουάνας"} ,
 { "Σε ποιο νησί του Ιονίου στις 15 Αυγούστου βγαίνουν τα φίδια της Παναγίας", "Στην Κεφαλονιά","Στην Ιθάκη","Στα Κύθηρα","Στην Ζάκυνθο"} ,
{ "Πόσο χρονών έπαιξε μπάλα ο Πελέ", "15 χρονών","16 χρονών","12 χρονών","11 χρονών"} ,
{ "Από που καταγόταν ο μεγάλος ζωγράφος Νικόλαος Γύζης", "Από την Τήνο","Από τα Χανιά","Από την Καστοριά","Από την Ξάνθη"} ,
{ "Σε ποιο ελληνικό νησί είναι το όρος Φεγγάρι", "Στην Σαμοθράκη","Στην Κάλυμνω","Στις Οινούσσες","Στην Κω"} ,
{ "Με ποιον προπονητή πήρε η Manchester United το κύπελλο κυπελλούχων Ευρώπης το 1991", "Με τον Φέργκιουσον","Με τον Μπάσμπι","Με τον Σέξτον","Με τον ΜακΓκίνες"} ,
{ "Ποια είναι η πολυπληθέστερη κοινοβουλευτική δημοκρατία στον κόσμο", "Ινδία","Αμερική","Κίνα","Ιαπωνία"} ,
{ "Ποιος είναι ο συγγραφέας του 'Μάνα Κουράγιο'", "Ο Μπρεχτ","Ο Βέντεκιντ ","Ο Λούντβιχ"," Ο Βόλφγκανγκ Γκαίτε"} ,
{ "Κοντά σε ποια μεγάλη πόλη των ΗΠΑ είναι το νησάκι Αλκατράζ", "Στον Άγιο Φραγκίσκο ","Στο Ρίτσμοντ","Στο Βαλέχο","Στο Μπέρκλεϋ"} ,
},
  new string[10, 5]   {
 { "Ποιος βγήκε παγκόσμιος πρωταθλητής φόρμουλα 1 το 1990", "Ο Αϋρτον Σέννα","Νάιτζελ Μάνσελ","Αλέν Προστ","Μίχαελ Σουμάχερ"} ,
 { "Πόσα κόκκαλα υπάρχουν στο ανθρώπινο σώμα", "206","153","325","224"} ,
 { "Σε ποιο ελληνικό νησί ακούγονται τα κοκόρια που λαλούν στην Τουρκία", "Στη Σάμο","Στην Ίω","Στη Λέσβο","Στην Χίο"} ,
{ "Ποιον Θεό οδήγησαν οι νύμφες στην σπηλιά της Δίκτης", "Τον Δία","Τον Άρη","Τον Διόνυσο","Τον Απόλλωνα"} ,
{ "Πόσες φορές πήρε τον τίτλο του παγκόσμιου πρωταθλητή βαρέων βαρών ο Μοχάμεντ Αλι", "3 φορές","4 φορές","2 φορές","6 φορές"} ,
{ "Πόσες ομάδες έλαβαν μέρος στο Μουντιάλ το 1930", "13 ομάδες","17 ομάδες","22 ομάδες","8 ομάδες"} ,
{ "Σε ποιο νησί γεννήθηκε η Άρτεμη και ο Απόλλωνας", "Στη Δήλο","Στην Αμοργό","Στην Ικαρία","Στην Ιθάκη"} ,
{ "Ποιο είναι το 2ο ψηλότερο βουνό της Πελοποννήσου", "Η Κυλλήνη","Η Τύμφη","Η Τραπεζώνα","Το Ταίναρο"} ,
{ "Ποιο έντομο ζει τα περισσότερα χρόνια", "Η βασίλισσα των τερμιτών","Η Αφρικανική μέλισσα","Η μύγα τσε τσε","Η Ασιατική σφήκα"} ,
{ "Στις όχθες ποιου ποταμού είναι κτισμένη η Βαρσοβία", "Του Βιστούλα","Του Όντερ","Του Σβίνα","Του Δνείστερου"} ,
},
  new string[10, 5]   {
{ "Γιατί ήταν φημισμένος ο Βαρώνος Μυνχάουζεν", "Για τα ψέματά του","Για τα πλούτη του","Για τον αλτρουισμό του","Για τα στρατιωτικά του επιτεύγματα"} ,
{ "Ποιο είναι το πραγματικό όνομα του Πελέ", "Εντσουν Αράντες Ντουα Σιμέντο ","Λουίς Ναζάριο ντε Λίμα","Ρικάρντο Ίζεκσον ντος Σάντος Λέιτε","Ρόμπσον Ντε Σόουζα"} ,
{ "Σε ποια χώρα πήγε ο Σάχης μετά την πτώση του από το θρόνο του Ιράν", "Στην Αίγυπτο","Στο Ιρακ","Στην Λιβύη","Στην Σαουδική Αραβία"} ,
{ "Ποιος ο πρώτος τεννίστας στον κόσμο που κέρδισε 5 συνεχόμενες φορές στο Γουίμπλεντον", "Ο Μπγιόρν Μπόργκ","Ο Ρόι Έμερσον","Ο Ουίλιαμ Ρένσοου","Ο Πιτ Σάμπρας"} ,
{ "Ποιας χώρας μουσικό όργανο είναι η μπαλαλάϊκα", "Της Ρωσίας","Της Αιγύπτου","Της Τουρκίας","Της Αρμενίας"} ,
{ "Πόσες περίπου γλώσσες και διάλεκτοι μιλούνται σε όλο τον κόσμο", "5.000","4.000","6.000","3.000"} ,
{ "Πόσα χρόνια ζει η βασίλισσα των τερμιτών", "50 χρόνια","25 χρόνια","65 χρόνια","40 χρόνια"} ,
{ "Από που κατάγεται ο Μάνθος Κατσούλης", "Από την Δράμα","Από την Λάρισα","Από την Καστοριά","Από την Ξάνθη"} ,
{ "Ποιο νησί του Αιγαίου ήταν γνωστό στην αρχαιότητα για τα χρυσορυχεία του", "Η Θάσος","Η Σαμοθράκη","Η Χίος","Η Ρόδος"} ,
{ "Ποιος ποταμός βρέχει την Μαδρίτη", "Ο Μαντζανάρης","Ο Δούρος","Ο Γουαδαλκιβίρ","Ο Τάγος	"} ,
},
  new string[10, 5]   {
 { "Ποιος γιατρός έκανε την πρώτη μεταμόσχευση καρδιάς το 1967", "Ο Κρίστιαν Μπάρναρντ","Η Έλεν Τάουσιγκ","Ο Βέρνερ Φον Μπράουν","Ο Φράνσις Μπέικον"} ,
 { "Ποιος είναι ο μέσος όρος λέξεων που εκφέρει μία γυναίκα ημερησίως", "20.000","10.000","1.500","38.000"} ,
 { "Πόσες ταινίες James Bond έχουν γυριστεί μέχρι σήμερα", "26","19","32","12"} ,
{ "Ποιο είναι το παγκόσμιο ρεκόρ σε έλξεις σε μονόζυγο που έγινε ποτέ από γυναίκα", "725","64","162","573"} ,
{ "Πόσες τρίχες κατά Μ.Ο. έχει ένας άνθρωπος στα φρύδια του", "600","1.000","250","2.000"} ,
{ "Πόσα λίτρα αίμα περιέχει ο ανθρώπινος οργανισμός", "5","3","12","20"} ,
{ "Τι ποσοστό επί τοις εκατό μεγαλώνουν οι κόρες των ματιών μας όταν κοιτάμε κάποιον που έχουμε ερωτευθεί", "45%","63%","90%","70%"} ,
{ "Πόσα γκολ έβαλε ο Μαραντόνα στην διάρκεια της καριέρας του", "293","584","169","1001"} ,
{ "Ποια χρονιά τραβήχτηκε η πρώτη φωτογραφία στον κόσμο", "1827","1889","1902","1920"} ,
{ "Ποιο είναι το ποσοστό των γνήσιων ξανθών γυναικών στον κόσμο", "3%","7%","20%","25%"} ,
},
  new string[10, 5]   {
 { "Πόσα αγκάθια έχει κατά μέσο όρο ένας σκαντζόχοιρος", "6.000","1.200","3.000","12.000"} ,
 { "Ποιο είναι το ύψος του Ντόναλντ Τραμπ", "1.88","1.82","1.75","1.94"} ,
 { "Πόσα εσώρουχα αγοράζουν κατά μ.ο οι άνδρες μέσα σε ένα χρόνο", "3,4","1,5","15,5","30"} ,
{ "Ποιο είναι το μήκος των ποδιών της Elle Macpherson", "123,5 εκ","124 εκ","115 εκ","125 εκ"} ,
{ "Πόσα γραμμάρια μέλι παράγει μια μέλισσα σε όλη της την ζωή", "45","180","400","1.500"} ,
{ "Τι μήκος έχει η γλώσσα μιας καμηλοπάρδαλης", "35 εκ","19 εκ","29 εκ","45 εκ"} ,
{ "Πόσα είδη πτηνών πετάνε προς τα πίσω", "1","0","2","10"} ,
{ "Πόσα κράτη υπάρχουν σήμερα στον κόσμο", "196","199","245","1.550"} ,
{ "Πόσες είναι οι περιβόητες στάσεις του Κάμα Σούτρα", "64","58","69","199"} ,
{ "Πόσες φορές κατά την διάρκεια της ζωής του χασμουριέται ένας μέσος άνθρωπος", "250.000","20.000","1.000.000","4.000"} ,
},
  new string[10, 5]  {
 { "Πόσο ψηλός είναι ο πύργος του Άιφελ", "325m","250m","500m","450m"} ,
 { "Πώς ονομάζεται η μπανάνα στη Μαλαισία", "πισάνγκ","μπισάνγκ","κισάνγκ","ντισάνγκ"} ,
 { "Ποιό είναι το επίθετο της Rihanna", "Φέντι","Λάιν","Έβανς","Πίνκετ"} ,
{ "Ποιός τραγουδιστής έχει το παρατσούκλι 'Η φωνή της Eurovision' αφού έχει κατακτήσει το διαγωνισμό 3 φορές", "Τζόνι Λόγκαν","Ντίμα Μπιλάν","Ζέλικο Γιοκσίμοβιτς","Ζόλι 'Αντοκ"} ,
{ "Σε ποιό νησί γεννήθηκε ο Ναπολέων", "Κορσική","Μοντεκρίστο","Πορτοφεραίο","Σαρδινία"} ,
{ "Ποιός ήταν ο πρώτος βασιλιάς του Βελγίου", "Λεοπόλδος Α","Εράσμ Λουί Σουρλέ ντε Σοκί","Αλβέρτος Α΄","Βαλδουίνος"} ,
{ "Ποιά πόλη της Αυστραλίας ήταν πρωτεύουσά της την περίοδο 1901-1927", "Μελβούρνη","Σίδνεϊ","Καμπέρα","Αδελαΐδα"} ,
{ "Πότε ήταν η πρώτη κυκλοφορία του παιχνιδιού Prince of Persia", "1989","1993","2003","1987"} ,
{ "Πως λεγόταν ο πρωταγωνιστής του Assassin's Creed 1","Αλταϊρ","Έτζιο Αουντιτόρε Ντε Φιρένζε","Χάϊθαμ Κένγουει","Τζέικομπ Φρέι"} ,
{ "Ανάμεσα σε ποια νησιά βρίσκεται η Κύθνος", "Κέα - Σέριφο","Μήλο - Πάρο","Άνδρο - Μύκονο","Ίο - Φολέγανδρο"} ,
},
  new string[10, 5]   {
 { "Ποιο απ τα παρακάτω φυτά δεν έχει φύλλα", "Epipogium aphyllum","Kokai cookei","Lotus berthelotii","Cypripedium calceolus"} ,
 { "Τι διαστάσεις έχει το Λουλούδι πτώμα ( Amorphophallus titanum )", "6 μέτρα ύψος και 3 μέτρα διάμετρο","5 μέτρα ύψος και 2,5 μέτρα διάμετρο","7 μέτρα ύψος και 4 μέτρα διάμετρο","3 μέτρα ύψος και 1,5 μέτρα διάμετρο"} ,
 { "Πόσα είδη περιλαμβάνονται στην οικογένεια αράχνη λύκος", "3200","1500","2600","780"} ,
{ "Ποιά είναι η πρωτεύουσα της Ναμίμπια", "Βίντχουκ","Γκαμπορόνε","Χαράρε","Μοζαμβίκη"} ,
{ "Από ποια χρώματα αποτελείται η σημαία της Αιγύπτου", "Κόκκινο - Λευκό - Μαύρο","Πορτοκαλί - Λευκό - Πράσινο","Κόκκινο - Μαύρο","Λευκό - Πράσινο"} ,
{ "Πόσα αστεράκια έχει η σημαία του Πράσινου Ακρωτηρίου", "10","18","26","12"} ,
{ "Από πόσα χρώματα αποτελείται η σημαία της Ζιμπάμπουε", "5","3","2","6"} ,
{ "Ποιος ο πληθυσμός των Ηνωμένων Πολιτειών της Αμερικής", "321,4 εκατομμύρια","341,4 εκατομμύρια","402,4 εκατομμύρια","297,4 εκατομμύρια"} ,
{ "Ποια χρονιά μπήκε το πινκ πονκ ως άθλημα στους Ολυμπιακούς Αγώνες", "Το 1988","Το 1992","Το 1984","Το 1980"} ,
{ "Σε ποιο σώμα ανήκει το 'Καλλιτεχνικό πατινάζ'", "ISU","IIHF","FIL","UIPM"} ,
},
  new string[10, 5]   {
 { "Τι ύψος είχε ο Τούπακ Σακούρ", "176cm","186cm","179cm","182cm"} ,
 { "Σε ποια ταινία πρωταγωνίστησε για πρώτη φορά ο ηθοποιός Τζέικ Τζίλενχαλ", "Highway","Donnie Darko","Zodiac","Homegrown"} ,
 { "Μετά το Star Wars ποια ήταν η ταινία με τις περισσότερες πωλήσεις το 2015", "Jurassic World","Furious 7","Avengers: Age of Ultron","Minions"} ,
{ "Από πόσα κομμάτια των ABBA αποτελείται η ταινία ΜΑΜΜΑ ΜΙΑ", "18","28","16","26"} ,
{ "Πόσα Όσκαρ έχει συνολικά η πρώτη ταινία Star Wars", "6","5","8","4"} ,
{ "Ποιό είναι το όνομα του πιο παλαιού τυπωμένου βιβλίου που έχει διασωθεί μέχρι σήμερα", "The Diamond Sutra","The Arabian Nights","The Iliad","The Republic"} ,
{ "Πόσα είδη καρχαριών υπάρχουν", "440","270","190","63"} ,
{ "Πότε εκγαινιάστηκαν οι εργασίες της Διώρυγας της Κορίνθου", "1882","1892","1872","1862"} ,
{ "Σύμφωνα με μελέτες της Αγγλίας πόσα Gb(giga byte) ΄κατεβάζει΄ ο μέσος χρήστης το μήνα ", "13GB","27GB","130GB","112GB"} ,
{ "Ποιο από τα παρακάτω λαχανικά έχει τη μεγαλύτερη περιεκτικότητα σε θρεπτικά συστατικά", "Το κατσαρό λάχανο","Το σπανάκι","Το καρότο","Το μπρόκολο"} ,
},
  new string[10, 5]   {
 { "Σε ποιο απο τα παρακάτω παιχνίδια του SNES αν πατούσες Start και μετά Select μπορούσες να περάσεις το συγκεκριμένο επίπεδο", "Donkey Kong Country","Super Mario World","The Legend of Zelda","Super Mario Kart"} ,
 { "Σε ποιο παιχνίδι ένας από τους βασικούς κακούς είναι η 'Mary the Giant Cow'", "Death Smiles","Metal Slug","Sine Mora","Ikaruga"} ,
 { "Ποιο είναι το μέγιστο επίπεδο που μπορεί να έχουν οι χαρακτήρες στο Kingdom Hearts 2", "99","100","110","90"} ,
{ "Στο Final Fantasy IX ποιο είναι το επίθετο του χαρακτήρα Zidane", "Tribal","Alexandros","Carol","Steiner"} ,
{ "Στο Final Fantasy X ποιος/α είναι ο/η βασικός/ή αντίπαλος/η του Auron", "Yunalesca","Leblanc","Yu Yevon","Seymour Guado"} ,
{ "Τι είδος τέρας είναι ο Bowser της διάσημης σειράς Mario", "Koopa","Goomba","Broozer","Galoomba"} ,
{ "Στο αρχικό παιχνίδι της σειράς Kingdom Hearts ποιο όπλο χρησιμοποιεί συχνά ο πρωταγωνιστής Sora", "Keyblade","Knifeblade","Gunblade","Kingblade"} ,
{ "Ποιας γενιάς θεωρείται η κονσόλα Playstation 2 ", "πέμπτη γενιά ","έκτη γενιά","τέταρτη γενιά","έβδομη γενιά"} ,
{ "Πόσες μορφές μπορεί να πάρει ο Sora στο παιχνίδι  Kingdom Hearts 2: Final Mix+", "3","4","5","6"} ,
{ "Την πρώτη φορά που αντιμετωπίζουμε τους Luca Goers στο mini-game Blitzball στο παιχνίδι Final Fantasy X ,ποιο είναι το όνομα του πιο δυνατού παίχτη της ομάδας", "Graav","Bickson","Balgerda","Doram"} ,
}
        };

        public Form1()
        {
            InitializeComponent();
            //make the textboxes parents to the labels(a,b,c,d)
            labelparents(label6,textBox1);
            labelparents(label7,textBox2);
            labelparents(label8,textBox3);
            labelparents(label9,textBox4);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            suspenceT.Start();
            //get the path for the intro video
            string filepath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            filepath = Path.GetDirectoryName(filepath);
            filepath = filepath.Substring(6);
            axWindowsMediaPlayer1.URL = filepath + "\\GMI.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }


        //test add question button
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Επόμενη Ερώτηση";
            button1.Enabled = false;
            button6.Enabled = false;
            button5.Enabled = false;
            button1.Visible = false;

            if (button50o == 0)
            { button5.Enabled = true; }
            if (audienceo == 0)
            { button6.Enabled = true; }
            enableT();
            question=randomnum1();
            switch (level)
            {
                case 0:
                    Countdown();
                    white();
                    textBox5.Clear();
                    reset();
                    AddQ(level, question);
 
                    break;
                case 1:
                    Countdown();
                    white();
                    textBox5.Clear();
                    reset();
                    AddQ(1, question);
                   
                    break;
                case 2:
                    textBox5.Clear();
                    Countdown();
                    white(); reset();
                    AddQ(2, question);
                  
                    break;
                case 3:
                    Countdown();
                    white();
                    textBox5.Clear(); reset();
                    AddQ(3, question);
                  
                    break;
                case 4:
                    Countdown();
                    white();
                    textBox5.Clear(); reset();
                    AddQ(4, question);
                  
                    break;
                case 5:
                    Countdown();
                    white();
                    textBox5.Clear(); reset();
                    AddQ(5, question);
                  
                    break;
                case 6:
                    Countdown();
                    white();
                    textBox5.Clear(); reset();
                    AddQ(6, question);
                  
                    break;
                case 7:
                    Countdown(); white();
                    textBox5.Clear(); reset();
                    AddQ(7, question);
                  
                    break;
                case 8:
                    Countdown(); white();
                    textBox5.Clear(); reset();
                    AddQ(8, question);
                   
                    break;
                case 9:
                    Countdown(); white();
                    textBox5.Clear(); reset();
                    AddQ(9, question);
                  
                    break;
                case 10:
                    Countdown(); white();
                    textBox5.Clear(); reset();
                    AddQ(10, question);
                  
                    break;
                case 11:
                    Countdown(); white();
                    textBox5.Clear(); reset();
                    AddQ(11, question);
                   
                    break;
                case 12:
                    Countdown(); white();
                    textBox5.Clear(); reset();
                    AddQ(12, question);
                   
                    break;
                case 13:
                    Countdown(); white();
                    textBox5.Clear(); reset();
                    AddQ(13, question);
                   
                    break;
                case 14:
                    Countdown(); white();
                    textBox5.Clear(); reset();
                    AddQ(14, question);
                  
                    break;
            }
           

            //if load game think about it 
        }
        //end of test add question button

        //checking answers
        private async void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            sus(textBox1);
           await Task.Delay(6000);
            change(textBox2, textBox1, textBox3, textBox4, level, question,prize(level));

        }

        private async void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            sus(textBox2);
            await Task.Delay(6000);
            change(textBox1, textBox2, textBox3, textBox4, level, question, prize(level));
        }

        private async void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            sus(textBox3);
            await Task.Delay(6000);
            change(textBox1, textBox3, textBox2, textBox4, level, question,prize(level));
        }

        private async void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            sus(textBox4);
            await Task.Delay(6000);
            change(textBox1, textBox4, textBox3, textBox2, level, question,prize(level));
        }
        //end of checking answers

        //Check answers
        public void change(TextBox text1, TextBox text2, TextBox text3, TextBox text4, int x, int y, Label w)
        {
                if (text2.Text.ToString() == jag[x][y, 1].ToString())
                {

                if (level == 14)
                {
                    text2.BackColor = Color.Green;
                    timer = 0;
                    timer1.Start();
                    StopCountdown();
                    Milans.Play();
                    label4.Text = w.Text.ToString();
                    disabelT();
                    panel3.Visible = true;
                    timer9.Start();
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button1.Text = "ΞΕΚΙΝΑ";
                    button3.Visible = true;
                }
                else
                {
                    text2.BackColor = Color.Green;
                    timer = 0;
                    timer1.Start();
                    StopCountdown();
                    soundC.Play();
                    level++;
                    label4.Text = w.Text.ToString();
                    disabelT();
                    WinMsg();
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button1.Enabled = true;
                    button1.Visible = true;
                }
                }
                else if (text1.Text.ToString() == jag[x][y, 1].ToString())
                {
                    text2.BackColor = Color.Red;
                    text1.BackColor = Color.Orange;
                    timerx = 0;
                    timer3.Start();
                    StopCountdown();
                    soundA1.Play();
                    button5.Enabled = false;
                    button6.Enabled = false;
                    disabelT();
                    LoseMsg();
                button1.Text = "ΞΕΚΙΝΑ";
              
                button3.Visible = true;

            }
                else if (text3.Text.ToString() == jag[x][y, 1].ToString())
                {
                    text2.BackColor = Color.Red;
                    text3.BackColor = Color.Orange;
                    timerx = 0;
                    timer3.Start();
                    StopCountdown();
                    soundA1.Play();
                    button5.Enabled = false;
                    button6.Enabled = false;
                    disabelT();
                    LoseMsg();
                button1.Text = "ΞΕΚΙΝΑ";
             
                button3.Visible = true;
            }
                else
                {

                    text2.BackColor = Color.Red;
                    text4.BackColor = Color.Orange;
                    timerx = 0;
                    timer3.Start();
                    StopCountdown();
                    soundA1.Play();
                    button5.Enabled = false;
                    button6.Enabled = false;
                    disabelT();
                    LoseMsg();
                button1.Text = "ΞΕΚΙΝΑ";
              
                button3.Visible = true;
            }
            
            circularProgressBar1.Visible = false;
        }
        //end check answers

        //test only// reset textBC
        public void white()
        {

            textBox1.BackColor = Color.Black;
            textBox2.BackColor = Color.Black;
            textBox3.BackColor = Color.Black;
            textBox4.BackColor = Color.Black;
        }

        //50 50
        public void fifty(int x, int y)
        {
            if (textBox1.Text.ToString() == jag[x][y, 1].ToString())
            {
                while (true)
                {
                    Random l = new Random();
                    f = l.Next(1, 5);
                    k = l.Next(1, 5);
                    if (k != f && k != 1 && f != 1)
                    { break; }

                }
                if (f == 2)
                { textBox2.Visible = false;
                    label7.Visible = false;
                }
                else if (f == 3)
                { textBox3.Visible = false;
                    label8.Visible = false;
                }
                else { textBox4.Visible = false; label9.Visible = false; }

                if (k == 2)
                { textBox2.Visible = false; label7.Visible = false; }
                else if (k == 3)
                { textBox3.Visible = false; label8.Visible = false; }
                else { textBox4.Visible = false; label9.Visible = false; }

            }
            else if (textBox2.Text.ToString() == jag[x][y, 1].ToString())
            {
                while (true)
                {
                    Random l = new Random();
                    f = l.Next(1, 5);
                    k = l.Next(1, 5);
                    if (k != f && k != 2 && f != 2)
                    { break; }

                }
                if (f == 1)
                { textBox1.Visible = false; label6.Visible = false; }
                else if (f == 3)
                { textBox3.Visible = false; label8.Visible = false; }
                else { textBox4.Visible = false; label9.Visible = false; }

                if (k == 1)
                { textBox1.Visible = false; label6.Visible = false; }
                else if (k == 3)
                { textBox3.Visible = false; label8.Visible = false; }
                else { textBox4.Visible = false; label9.Visible = false; }

            }
            else if (textBox3.Text.ToString() == jag[x][y, 1].ToString())

            {
                while (true)
                {
                    Random l = new Random();
                    f = l.Next(1, 5);
                    k = l.Next(1, 5);
                    if (k != f && k != 3 && f != 3)
                    { break; }

                }
                if (f == 1)
                { textBox1.Visible = false; label6.Visible = false; }
                else if (f == 2)
                { textBox2.Visible = false; label7.Visible = false; }
                else { textBox4.Visible = false; label9.Visible = false; }

                if (k == 1)
                { textBox1.Visible = false; label6.Visible = false; }
                else if (k == 2)
                { textBox2.Visible = false; label7.Visible = false; }
                else { textBox4.Visible = false; label9.Visible = false; }

            }
            else
            {
                while (true)
                {
                    Random l = new Random();
                    f = l.Next(1, 5);
                    k = l.Next(1, 5);
                    if (k != f && k != 4 && f != 4)
                    { break; }

                }
                if (f == 1)
                { textBox1.Visible = false; label6.Visible = false; }
                else if (f == 2)
                { textBox2.Visible = false; label7.Visible = false; }
                else { textBox3.Visible = false; label8.Visible = false; }

                if (k == 1)
                { textBox1.Visible = false; label6.Visible = false; }
                else if (k == 2)
                { textBox2.Visible = false; label7.Visible = false; }
                else { textBox3.Visible = false; label8.Visible = false; }
            }
            button50o = 1;
            CD.Play();
           
        }
        //end of 50 50

        //test reset
        public void reset()
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
        }
        //end of test reset

        private void button2_Click(object sender, EventArgs e)
        {
            timer5.Stop();
        }

        //audience
        public void audience(int min, int max, int x , int y)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            number1 = 0;
            number2 = 0;
            number3 = 0;
            number4 = 0;
            number5 = 0;

            //if level >7 <10 correct maybe the biggest %% (1/4 to be wrong)
            if (level >= 7 && level <=10)
            {
                rchoice = r.Next(1, 5);
                if (rchoice == 1)
                {
                    while (number5 != 100)
                    {
                        number1 = r.Next(min, max);
                        number2 = r.Next(number1);
                        number3 = r.Next(number2);
                        number4 = r.Next(number3);
                        number5 = number1 + number2 + number3 + number4;
                    }

                    if (textBox1.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number1);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number1,number2,number3,number4);
                    }
                    else if (textBox2.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number1);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number1, number3, number4);
                    }
                    else if (textBox3.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number3);
                        chart1.Series["Series1"].Points.AddXY("Γ", number1);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number3, number1, number4);
                    }
                    else
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number4);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number1);
                        audiencelabels(number4, number2, number3, number1);
                    }  
                }
                else if (rchoice == 2)
                {
                    while (number5 != 100)
                    {
                        number1 = r.Next(min, max);
                        number2 = r.Next(number1);
                        number3 = r.Next(number2);
                        number4 = r.Next(number3);
                        number5 = number1 + number2 + number3 + number4;
                    }

                    if (textBox1.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number1);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number1, number2, number3, number4);
                    }
                    else if (textBox2.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number1);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number1, number3, number4);
                    }
                    else if (textBox3.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number3);
                        chart1.Series["Series1"].Points.AddXY("Γ", number1);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number3, number1, number4);
                    }
                    else
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number4);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number1);
                        audiencelabels(number4, number2, number3, number1);
                    }
                }
                else if (rchoice == 3)
                {
                    while (number5 != 100)
                    {
                        number1 = r.Next(min, max);
                        number2 = r.Next(number1);
                        number3 = r.Next(number2);
                        number4 = r.Next(number3);
                        number5 = number1 + number2 + number3 + number4;
                    }

                    if (textBox1.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number1);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number1, number2, number3, number4);
                    }
                    else if (textBox2.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number1);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number1, number3, number4);
                    }
                    else if (textBox3.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number3);
                        chart1.Series["Series1"].Points.AddXY("Γ", number1);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number3, number1, number4);
                    }
                    else
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number4);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number1);
                        audiencelabels(number4, number2, number3, number1);
                    }
                }
                else if (rchoice==4)
                {
                    while (number5 != 100)
                    {
                        number1 = r.Next(min, max);
                        number2 = r.Next(number1);
                        number3 = r.Next(number2);
                        number4 = r.Next(number3);
                        number5 = number1 + number2 + number3 + number4;
                    }


                    if (textBox1.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number1);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number1, number2, number3, number4);
                    }
                    else if (textBox2.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number3);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number1);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number3, number2, number1, number4);
                    }
                    else if (textBox3.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number4);
                        chart1.Series["Series1"].Points.AddXY("Β", number3);
                        chart1.Series["Series1"].Points.AddXY("Γ", number2);
                        chart1.Series["Series1"].Points.AddXY("Δ", number1);
                        audiencelabels(number4, number3, number2, number1);
                    }
                    else
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number3);
                        chart1.Series["Series1"].Points.AddXY("Β", number1);
                        chart1.Series["Series1"].Points.AddXY("Γ", number2);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number3, number1, number2, number4);
                    }
                }


            }
            //if level >10 correct maybe the biggest %% (1/3 to be wrong)
            else if (level >10)
            {
                rchoice = r.Next(1, 4);
                if (rchoice == 1)
                {
                    while (number5 != 100)
                    {
                        number1 = r.Next(min, max);
                        number2 = r.Next(number1);
                        number3 = r.Next(number2);
                        number4 = r.Next(number3);
                        number5 = number1 + number2 + number3 + number4;
                    }

                    if (textBox1.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number1);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number1, number2, number3, number4);
                    }
                    else if (textBox2.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number1);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number1, number3, number4);
                    }
                    else if (textBox3.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number3);
                        chart1.Series["Series1"].Points.AddXY("Γ", number1);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number3, number1, number4);
                    }
                    else
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number4);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number1);
                        audiencelabels(number4, number2, number3, number1);
                    }
                }
                else if (rchoice == 2)
                {
                    while (number5 != 100)
                    {
                        number1 = r.Next(min, max);
                        number2 = r.Next(number1);
                        number3 = r.Next(number2);
                        number4 = r.Next(number3);
                        number5 = number1 + number2 + number3 + number4;
                    }

                    if (textBox1.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number1);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number1, number2, number3, number4);
                    }
                    else if (textBox2.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number1);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number1, number3, number4);
                    }
                    else if (textBox3.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number3);
                        chart1.Series["Series1"].Points.AddXY("Γ", number1);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number3, number1, number4);
                    }
                    else
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number4);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number1);
                        audiencelabels(number4, number2, number3, number1);
                    }
                }
                else if (rchoice == 3)
                {
                    while (number5 != 100)
                    {
                        number1 = r.Next(min, max);
                        number2 = r.Next(number1);
                        number3 = r.Next(number2);
                        number4 = r.Next(number3);
                        number5 = number1 + number2 + number3 + number4;
                    }


                    if (textBox1.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number2);
                        chart1.Series["Series1"].Points.AddXY("Β", number1);
                        chart1.Series["Series1"].Points.AddXY("Γ", number3);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number2, number1, number3, number4);
                    }
                    else if (textBox2.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number3);
                        chart1.Series["Series1"].Points.AddXY("Β", number2);
                        chart1.Series["Series1"].Points.AddXY("Γ", number1);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number3, number2, number1, number4);
                    }
                    else if (textBox3.Text.ToString() == jag[x][y, 1].ToString())
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number4);
                        chart1.Series["Series1"].Points.AddXY("Β", number3);
                        chart1.Series["Series1"].Points.AddXY("Γ", number2);
                        chart1.Series["Series1"].Points.AddXY("Δ", number1);
                        audiencelabels(number4, number3, number2, number1);
                    }
                    else
                    {
                        chart1.Series["Series1"].Points.AddXY("Α", number3);
                        chart1.Series["Series1"].Points.AddXY("Β", number1);
                        chart1.Series["Series1"].Points.AddXY("Γ", number2);
                        chart1.Series["Series1"].Points.AddXY("Δ", number4);
                        audiencelabels(number3, number1, number2, number4);
                    }
                }
            }
            else
            {
                //if level <7 biggest %% == correct answer
                while (number5 != 100)
                {
                    number1 = r.Next(min, max);

                    number2 = r.Next(number1);

                    number3 = r.Next(number2);

                    number4 = r.Next(number3);

                    number5 = number1 + number2 + number3 + number4;
                }
                if (textBox1.Text.ToString() == jag[x][y, 1].ToString())
                {
                    chart1.Series["Series1"].Points.AddXY("Α", number1);
                    chart1.Series["Series1"].Points.AddXY("Β", number2);
                    chart1.Series["Series1"].Points.AddXY("Γ", number3);
                    chart1.Series["Series1"].Points.AddXY("Δ", number4);
                    audiencelabels(number1, number2, number3, number4);
                }
                else if (textBox2.Text.ToString() == jag[x][y, 1].ToString())
                {
                    chart1.Series["Series1"].Points.AddXY("Α", number2);
                    chart1.Series["Series1"].Points.AddXY("Β", number1);
                    chart1.Series["Series1"].Points.AddXY("Γ", number3);
                    chart1.Series["Series1"].Points.AddXY("Δ", number4);
                    audiencelabels(number2, number1, number3, number4);
                }
                else if (textBox3.Text.ToString() == jag[x][y, 1].ToString())
                {
                    chart1.Series["Series1"].Points.AddXY("Α", number2);
                    chart1.Series["Series1"].Points.AddXY("Β", number3);
                    chart1.Series["Series1"].Points.AddXY("Γ", number1);
                    chart1.Series["Series1"].Points.AddXY("Δ", number4);
                    audiencelabels(number2, number3, number1, number4);
                }
                else 
                {
                    chart1.Series["Series1"].Points.AddXY("Α", number4);
                    chart1.Series["Series1"].Points.AddXY("Β", number2);
                    chart1.Series["Series1"].Points.AddXY("Γ", number3);
                    chart1.Series["Series1"].Points.AddXY("Δ", number1);
                    audiencelabels(number4, number2, number3, number1);
                }

            }
        }
        //end of audience

        //right wrong back lights
        public void blinker(Label x)
        {
            x.BackColor = Color.Orange;
        }
        public void blinker1(Label x)
        {
            x.BackColor = Color.Green;
        }
        public void blinker2(Label x)
        {
            x.BackColor = Color.Orange;
        }
        public void blinker3(Label x)
        {
           x.BackColor = Color.Red;
        }
        //end of right wrong back lights 

        //right wrong blink effect
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (level == 14)
            {
                if (timer < 12)
                {
                    timer2.Stop();
                    blinker(prize(level));
                    timer++;
                    timer2.Start();
                }
                else
                {
                    timer1.Stop();
                    timer2.Stop();
                }
            }
            else
            {
                if (timer < 12)
                {
                    timer2.Stop();
                    blinker(prize(level - 1));
                    timer++;
                    timer2.Start();
                }
                else
                {
                    timer1.Stop();
                    timer2.Stop();
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (level == 14)
            {
                timer1.Stop();
                blinker1(prize(level));
                timer++;
                timer1.Start();
            }
            else
            { 
            timer1.Stop();
            blinker1(prize(level - 1));
            timer++;
            timer1.Start();
        }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (timerx < 19)
            {
                if (prize(level) == prize1)
                {
                    timer4.Stop();
                    blinker2(prize(level));
                    timerx++;
                    timer4.Start();
                }
                else
                {
                    timer4.Stop();
                    blinker2(prize(level - 1));
                    timerx++;
                    timer4.Start();
                }
            }
            else
            {
                timer3.Stop();
                timer4.Stop();
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (prize(level) == prize1)
            {
                timer3.Stop();
                blinker3(prize(level));
                timerx++;
                timer3.Start();
            }
            else
            {
                timer3.Stop();
                blinker3(prize(level - 1));
                timerx++;
                timer3.Start();
            }
        }
        //end of right wrong blink effect

        //func add question
        public void AddQ(int x, int y)
        {
            while (true)
            {
                Random u = new Random();
                ans1 = u.Next(1, 5);
                ans2 = u.Next(1, 5);
                ans3 = u.Next(1, 5);
                ans4 = u.Next(1, 5);
                if (ans1 != ans2 && ans1 != ans3 && ans1 != ans4 && ans2 != ans3 && ans2 != ans4 && ans3 != ans4)
                { break; }
            }
            textBox1.Text = jag[x][y, ans1].ToString();
            textBox2.Text = jag[x][y, ans2].ToString();
            textBox3.Text = jag[x][y, ans3].ToString();
            textBox4.Text = jag[x][y, ans4].ToString();
            textBox5.Text = jag[x][y, 0].ToString();
        }
        //end of add question functio

        //test 2 different ways for random numbers
        //new random is seeded on current time tick so it doesn't work properly
        public int randomnum()
        {
            var random = new Random((int)DateTime.Now.Ticks);
            var randomValue = random.Next(0, 15);
            return randomValue;
        }
        public int randomnum1()
        {
            int addqs = 0;
            Random add = new Random(DateTime.Now.Millisecond);
            return addqs = add.Next(0, 10);
        }
        //end test 2 different ways 

        //button for 50 50
        private void button5_Click(object sender, EventArgs e)
        {
            fifty(level, question);
            button5.BackgroundImage = Properties.Resources.Classic5050used;
            Thread y = new Thread(CD.Play);
            Thread x = new Thread(fiftyfifty.Play);
            x.Start();
            System.Threading.Thread.Sleep(1000);
            y.Start();
            button5.Enabled = false;
        }
        //end of button 50 50

        //end session
        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //end end session

        //countdown timer
        private void timer5_Tick(object sender, EventArgs e)
        {
            try
            {
                circularProgressBar1.Value -= 1;
                circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            }
            catch (Exception)
            {
                return;
            }
            if (circularProgressBar1.Value==0)
            {
                button1.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                disabelT();
                LoseMsg();
                StopCountdown();
            }
        }
        //end of countdown timer

        //countdown timer
        public void Countdown()
        {  circularProgressBar1.Visible = true;
            circularProgressBar1.Value = 30;
            timer5.Start();
            CD.Play();
        }
        //end of countdown timer

        //stopcountdown
        public void StopCountdown()
        {
            timer5.Stop();

            CD.Stop();
        }
        //end stopcountdown

        //return a label based on level
        public  Label prize(int x)
        {
            if (x == 0)
                return prize1;
            else if (x == 1)
                return prize2;
            else if (x == 2)
                return prize3;
            else if (x == 3)
                return prize4;
            else if (x == 4)
                return prize5;
            else if (x == 5)
                return prize6;
            else if (x == 6)
                return prize7;
            else if (x == 7)
                return prize8;
            else if (x == 8)
                return prize9;
            else if (x == 9)
                return prize10;
            else if (x == 10)
                return prize11;
            else if (x == 11)
                return prize12;
            else if (x == 12)
                return prize13;
            else if (x == 13)
                return prize14;
            else return prize15;
        
        }
        //end of return a label

        //audience button
        private void button6_Click(object sender, EventArgs e)
        {
            switch (level)
            {
                case 0:
                    audience(88, 96, level, question);
                    break;
                case 1:
                    audience(80, 91, level, question);
                    break;
                case 2:
                    audience(78, 86, level, question);
                    break;
                case 3:
                    audience(75, 85, level, question);
                    break;
                case 4:
                    audience(73, 83, level, question);
                    break;
                case 5:
                    audience(58, 68, level, question);
                    break;
                case 6:
                    audience(50, 65, level, question);
                    break;
                case 7:
                    audience(45, 60, level, question);
                    break;
                case 8:
                    audience(45, 53, level, question);
                    break;
                case 9:
                    audience(43, 51, level, question);
                    break;
                case 10:
                    audience(40, 49, level, question);
                    break;
                case 11:
                    audience(37, 42, level, question);
                    break;
                case 12:
                    audience(28, 34, level, question);
                    break;
                case 13:
                    audience(27, 33, level, question);
                    break;
                case 14:
                    audience(26, 33, level, question);
                    break;
            }
            audienceo = 1;
            button6.Enabled = false;
            button6.BackgroundImage = Properties.Resources.ClassicATAused;
            panel1.Visible = true;
            timerA = 0;
            timer6.Start();
            }
        //end of audience button

        //timer for Audience
        private void timer6_Tick(object sender, EventArgs e)
        {
            timerA++;
            if (timerA==5)
            { timer6.Stop();
                panel1.Visible = false;
            }
        }
        //end of timer Audience

        //labels for audience numbers
        public void audiencelabels(int x , int z ,int w ,int q)
        { label1.Text = x.ToString()+"%";
            label2.Text = z.ToString()+"%";
            label3.Text = w.ToString()+"%";
            label5.Text = q.ToString()+"%";
        }
        //end of labels for audience numbers

        //lose message
        public void LoseMsg()
        {
            panel2.Visible = true;
            if (level >= 0 && level < 6)
            { label10.Text = "0 €"; }
            else if (level > 6 && level < 11)
            { label10.Text = "1.000 €"; }
            else if (level > 11 && level < 16)
            { label10.Text = "32.000 €"; } 
            timerLose = 0;
            timer7.Start();
        }
        //end lose message

        //timer lose message
        private void timer7_Tick(object sender, EventArgs e)
        {
            timerLose++;
            if (timerLose==5)
            { panel2.Visible = false;
                timer7.Stop();
            }

        }
        //end timer lose message

        //win message
        public void WinMsg()
        {
        panel2.Visible = true;
        label10.Text ="Συγχαρητήρια κέρδισες :" + label4.Text;
        timerWin = 0;
        timer8.Start();
    }
        //end win message

        //timer win message
        private void timer8_Tick(object sender, EventArgs e)
        {
            timerWin++;
            if (timerWin==4)
            { timer8.Stop();
                panel2.Visible = false;
            }
        }
        //end of timer win message

        //disable textboxes
        public void disabelT()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }
        //end disable textboxes

        //enable textboxes
        public void enableT()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }
        // end enable texboxes
     
        //suspence effect
        public async void sus(TextBox text)
        {
            if (level >= 0)
            {
                StopCountdown();
                suspence.Play();
                disabelT();
                button5.Enabled = false;
                button6.Enabled = false;
                text.BackColor = Color.Orange;
              
            }
        }
        //end of suspence effect

        //reset the game 
        public void resetGame()
        {
            level = 0;
            button50o = 0;
            audienceo = 0;
            button5.BackgroundImage = Properties.Resources.Classic5050;
            button6.BackgroundImage = Properties.Resources.ClassicATA;
            button5.Enabled = false;
            button6.Enabled =false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            reset();
            white();
            button1.Text = "ΞΕΚΙΝΑ";
            prize1.BackColor = Color.Transparent;
            prize2.BackColor = Color.Transparent;
            prize3.BackColor = Color.Transparent;
            prize4.BackColor = Color.Transparent;
            prize5.BackColor = Color.Transparent;
            prize6.BackColor = Color.Transparent;
            prize7.BackColor = Color.Transparent;
            prize8.BackColor = Color.Transparent;
            prize9.BackColor = Color.Transparent;
            prize10.BackColor = Color.Transparent;
            prize11.BackColor = Color.Transparent;
            prize12.BackColor = Color.Transparent;
            prize13.BackColor = Color.Transparent;
            prize14.BackColor = Color.Transparent;
            prize15.BackColor = Color.Transparent;
            panel3.Visible = false;
            panel2.Visible = false;
            button3.Visible = false;
            button1.Visible = true;
            button1.Enabled = true;
            label4.Text = "Λεφτά:";
        }
        //end of reset the game

        //reset game button
        private void button3_Click_1(object sender, EventArgs e)
        {
        resetGame();
        }
        //end of reset game button


        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
         
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            panel4.Visible = false;
        }

        private void suspenceT_Tick(object sender, EventArgs e)
        {
            intro++;
            if (intro==22)
            { panel4.Visible = false; }
        }

        public void labelparents(Label x,TextBox y)
        { var labelpos = this.PointToScreen(x.Location);
            labelpos = y.PointToClient(labelpos);
            x.Parent = y;
            x.Location = labelpos;
            x.BackColor = Color.Transparent;}

        private void timer9_Tick(object sender, EventArgs e)
        {
            timer12.Stop();
            label15.ForeColor = Color.White;
            label11.ForeColor = Color.Black;
            timer10.Start();

        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            timer9.Stop();
            label11.ForeColor = Color.White;
            label13.ForeColor = Color.Black;
            timer11.Start();
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            timer10.Stop();
            label13.ForeColor = Color.White;
            label14.ForeColor = Color.Black;
            timer12.Start();
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            timer11.Stop();
            label14.ForeColor = Color.White;
            label15.ForeColor = Color.Black;
            timer9.Start();
        }

        private void σχετικάΜεΤονΠοργραμματιστήToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Georgi Grigorov" + "\r\n" + "Τεχνικός Λογισμικού " + "\r\n" + "Λογισμ Δ1 " + "\r\n" + "ΙΕΚ Ακμή 2016-2017 ");
        }
    }
}
