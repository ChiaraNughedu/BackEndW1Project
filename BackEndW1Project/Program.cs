using BackEndW1Project;

        try
        {
            string nome = InserisciDato("Nome");
            string cognome = InserisciDato("Cognome");
            DateTime dataNascita = InserisciData("Data di nascita");
            string luogoDiNascita = InserisciDato("Luogo di Nascita");
            string codiceFiscale = InserisciDato("Codice Fiscale");
            char sesso = InserisciSesso("Sesso");
            string comuneResidenza = InserisciDato("Comune di Residenza");
            double redditoAnnuale = InserisciReddito("Reddito Annuale");

            
            Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, luogoDiNascita, sesso, codiceFiscale, comuneResidenza, redditoAnnuale);

            double imposta = contribuente.CalcolaImposta();

            Console.WriteLine("\nCALCOLO IMPOSTA DA VERSARE");
            Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome};");
            Console.WriteLine($"Nato il: {contribuente.DataNascita:dd/MM/yyyy} a {contribuente.LuogoDiNascita};");
            Console.WriteLine($"Sesso: {contribuente.Sesso};");
            Console.WriteLine($"Residente a: {contribuente.ComuneResidenza};");
            Console.WriteLine($"Codice Fiscale: {contribuente.CodiceFiscale};");
            Console.WriteLine($"Reddito dichiarato: {contribuente.RedditoAnnuale:F2};");
            Console.WriteLine($"Imposta da versare: {imposta:F2};");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }
    

    static string InserisciDato(string campo)
    {
        string valore;
        do
        {
            Console.Write($"Inserisci il {campo}: ");
            valore = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(valore))
            {
                Console.WriteLine($"{campo} non può essere vuoto. Riprova.");
            }
        } while (string.IsNullOrWhiteSpace(valore));

        return valore;
    }
static DateTime InserisciData(string campo)
{
    DateTime data;
    while (true)
    {
        try
        {
            Console.Write($"Inserisci {campo}: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Inserire la data di nascita.");
            }

            data = DateTime.Parse(input);
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Formato data non valido. Usa il formato DD/MM/YYYY.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message); 
        }
    }
    return data;
}
static char InserisciSesso(string campo)
    {
        char sesso;
        while (true)
        {
            try
            {
                Console.Write($"Inserisci {campo}: ");
                sesso = Char.ToUpper(Console.ReadLine()[0]);
                if (sesso != 'M' && sesso != 'F')
                {
                    throw new ArgumentException("Valore non valido. Inserisci 'M' o 'F'.");
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return sesso;
    }

    static double InserisciReddito(string campo)
    {
        double reddito;
        while (true)
        {
            try
            {
                Console.Write($"Inserisci {campo}: ");
                reddito = double.Parse(Console.ReadLine());
                if (reddito < 0)
                {
                    throw new ArgumentException("Il reddito non può essere negativo. Riprova.");
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato del reddito non valido. Inserisci un numero valido.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return reddito;
    }