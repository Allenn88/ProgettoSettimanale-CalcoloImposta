using System;
using System.Linq.Expressions;
using System.Globalization;
using System.ComponentModel;
namespace ProgettoSettimanale_CalcoloTasse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CALCOLO IMPOSTA");

            Console.WriteLine("Inserisci Nome Contribuente: ");
            string Nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

            Console.WriteLine("Inserire il Cognome: ");
            string Cognome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

            Console.WriteLine("Inserisci Anno di nascita: ");
            string inputAnno = Console.ReadLine();
            while (inputAnno.Length != 4)
            {
                Console.WriteLine("Inserisci Anno di nascita completo (es 1903):");
                inputAnno = Console.ReadLine();
            }
            int Anno = int.Parse(inputAnno);

            Console.WriteLine("Inserisci il mese: ");
            string inputMese = Console.ReadLine();
            int Mese;
            while (!int.TryParse(inputMese, out Mese) || Mese < 1 || Mese > 12)
            {
                Console.WriteLine("Inserisci il mese corretto:");
                inputMese = Console.ReadLine();
            }

            Console.WriteLine("Inserisci il giorno: ");
            string inputGiorno = Console.ReadLine();

            int Giorno;
            while(!int.TryParse(inputGiorno, out Giorno) || Giorno < 1 || Giorno > 31)
            {
                Console.WriteLine("inserisci il giorno corretto: ");
                inputGiorno = Console.ReadLine();
            }

            DateTime DataNascita = new DateTime(Anno, Mese, Giorno);
            
            Console.WriteLine("Inserisci Codice Fiscale: ");
            string CodiceFiscale = Console.ReadLine();
            while (CodiceFiscale.Length != 16)
            {
                Console.WriteLine("Inserisci il Codice Fiscale Corretto:"); ;
                CodiceFiscale = Console.ReadLine();
            }
            string Sesso;
            do
            {
                Console.WriteLine("Inserisci sesso: M/F");
                 Sesso = Console.ReadLine().ToUpper();

            } while (Sesso != "M" && Sesso != "F");

           
            Console.WriteLine("Inserisci comune di residenza: ");
            string Comune = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());
           
            
            Console.WriteLine("Inserisci il tuo Reddito Annuo: ");
            string inputRedditoAnnuale = Console.ReadLine();
            int RedditoAnnuale;
            while(!int.TryParse(inputRedditoAnnuale, out RedditoAnnuale))
            {
                Console.WriteLine("Inserisci un importo numerico: ");
                inputRedditoAnnuale = Console.ReadLine() ;
            }

            Contribuente contribuente = new Contribuente (Nome, Cognome, DataNascita, CodiceFiscale, Sesso, Comune, RedditoAnnuale);
            decimal imposta = contribuente.Imposta();

            Console.WriteLine("==================================");
            Console.WriteLine();
            Console.WriteLine($"Contribuente: {Nome}  {Cognome}");
            Console.WriteLine();
            Console.WriteLine($"nato il {DataNascita.ToString("MM / dd / yyyy")}, ({Sesso})");
            Console.WriteLine();
            Console.WriteLine($"Residente in {Comune}, ");
            Console.WriteLine();
            Console.WriteLine($"Codice fiscale:{CodiceFiscale}");
            Console.WriteLine();
            Console.WriteLine($"Reddito dichiarato: {RedditoAnnuale} $");
            Console.WriteLine();
            Console.WriteLine($"L'imposta da pagare é: {imposta} $");
            Console.WriteLine();
            Console.WriteLine("==================================");
        }
    }
    class Contribuente
    {
        private string _Nome;
        private string _Cognome;
        private DateTime _DataNascita;
        private string _CodiceFiscale;
        private string _Sesso;
        private string _Comune;
        private int _RedditoAnnuale;


        public string Nome
        {
            get { return _Nome; }
            set
            {
                try
                {
                    _Nome = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nell'inserimento: {ex.Message}");
                }
            }
        }
        public string Cognome
        {
            get { return _Cognome; }
            set
            {
                try
                {
                    _Cognome = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nell'inserimento: {ex.Message}");
                }
            }
        }
        public DateTime DataNascita
        {
            get { return _DataNascita; }
            set
            {
                try
                {
                    _DataNascita = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nell'inserimento: {ex.Message}");
                }
            }
        }
        public string CodiceFiscale
        {
            get
            {
                return _CodiceFiscale;
            }
            set
            {
                try
                {
                    _CodiceFiscale = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nell'inserimento: {ex.Message}");
                }

            }
        }

        public string Sesso
        {
            get
            {
                return _Sesso;
            }
            set
            {
                try
                {
                    _Sesso = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nell'inserimento: {ex.Message}");

                }
            }
        }

        public string Comune
        {
            get
            {
                return _Comune;
            }
            set
            {
                try
                {
                    _Comune = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nell'inserimento: {ex.Message}");

                }
            }
        }

        public int RedditoAnnuale
        {
            get
            {
                return _RedditoAnnuale;
            }
            set
            {
                try
                {
                    _RedditoAnnuale = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nell'inserimento: {ex.Message}");

                }
            }
        }
        public Contribuente(string nome, string cognome, DateTime DataNascita, string codiceFiscale, string sesso, string comune, int redditoAnnuale)
        {
            _Nome = nome;
            _Cognome = cognome;
            _DataNascita = DataNascita;
            _CodiceFiscale = codiceFiscale;
            _Sesso = sesso;
            _Comune = comune;
            _RedditoAnnuale = redditoAnnuale;
        }



        public decimal Imposta()
        {
            decimal reddito = RedditoAnnuale;
            decimal imposta = 0;

            if (reddito <= 15000)
            {
                imposta = reddito * 0.23m;
            }
            else if (reddito <= 28000)
            {
                imposta = 3450 + (reddito - 15000) * 0.27m;
            }
            else if (reddito <= 55000)
            {
                imposta = 6960 + (reddito - 28000) * 0.38m;
            }
            else if (reddito <= 75000)
            {
                imposta = 17220 + (reddito - 55000) * 0.41m;
            }
            else
            {
                imposta = 25420 + (reddito - 75000) * 0.43m;
            }

            return imposta;
        }
    }
}
