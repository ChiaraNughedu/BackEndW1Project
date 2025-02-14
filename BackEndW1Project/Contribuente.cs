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

            while (reddito > 0)
            {
                if (reddito > 75000)
                {
                    imposta += (reddito - 75000) * 0.43;
                    reddito = 75000;
                }
                else if (reddito > 55000)
                {
                    imposta += (reddito - 55000) * 0.41;
                    reddito = 55000;
                }
                else if (reddito > 28000)
                {
                    imposta += (reddito - 28000) * 0.38;
                    reddito = 28000;
                }
                else if (reddito > 15000)
                {
                    imposta += (reddito - 15000) * 0.27;
                    reddito = 15000;
                }
                else
                {
                    imposta += reddito * 0.23;
                    reddito = 0;
                }
            }

            return imposta;
        }
    }
}
