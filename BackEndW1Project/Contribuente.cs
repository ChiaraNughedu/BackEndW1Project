namespace BackEndW1Project
{
    public class Contribuente
    {
        private string nome;
        private string cognome;
        private DateTime dataNascita;
        private string luogoDiNascita;
        private string codiceFiscale;
        private char sesso;
        private string comuneResidenza;
        private double redditoAnnuale;

        public string Nome
        {
            get
            {
                return nome;
            } 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Inserisci il nome.");
                nome = value;
            }
        }

        public string Cognome
        {
            get
            {
                return cognome;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Inserisci il cognome");
                cognome = value;
            }
        }

        public DateTime DataNascita
        {
            get
            {
                return dataNascita;
            }
            set
            {
                dataNascita = value;
            }
        }
        public string LuogoDiNascita
        {
            get
            {
                return luogoDiNascita;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Inserisci il luogo di nascita");
                luogoDiNascita = value;
            }
        }

        public string CodiceFiscale
        {
            get
            {
                return codiceFiscale;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Inserisci Codice Fiscale");
                codiceFiscale = value;
            }
        }

        public char Sesso
        {
            get
            {
                return sesso;
            }
            set
            {
                if (value != 'M' && value != 'F')
                    throw new ArgumentException("Specifica il sesso (M/F)");
                sesso = value;
            }
        }

        public string ComuneResidenza
        {
            get
            {
                return comuneResidenza;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Inserisci il Comune di Residenza");
                comuneResidenza = value;
            }
        }

        public double RedditoAnnuale
        {
            get
            {
                return redditoAnnuale;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Il reddito inserito deve avere un valore valido.");
                redditoAnnuale = value;
            }
        }

        public Contribuente(string nome, string cognome, DateTime dataNascita, string luogoDiNascita, char sesso, string codiceFiscale,  string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            LuogoDiNascita = luogoDiNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }
        public double CalcolaImposta()
        {
            double imposta = 0;
            double reddito = RedditoAnnuale;

            if (reddito >= 75001)
            {
                imposta = 25420 + (reddito - 75001) * 0.43;
            }
            else if (reddito >= 55001 && reddito <= 75000)
            {
                imposta = 17220 + (reddito - 55001) * 0.41;
            }
            else if (reddito >= 28001 && reddito <= 55000)
            {
                imposta = 6960 + (reddito - 28001) * 0.38;
            }
            else if (reddito >= 15001 && reddito <= 28000)
            {
                imposta = 3450 + (reddito - 15001) * 0.27;
            }
            else
            {
                imposta = reddito * 0.23;
            }

            return imposta;
        }
    }
}
