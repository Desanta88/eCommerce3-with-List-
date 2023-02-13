namespace eCommerce
{
    public class Prodotto:IEquatable<Prodotto>
    {
        private string _id;
        private string _nome;
        private string _produttore;
        private string _descrizione;
        private float _prezzo;

        private int counter { get; set; }

        public Prodotto(string pro, string name,string desc,int price)
        {
            _produttore = pro;
            _nome = name;
            _descrizione = desc;
            _prezzo = price;
        }
        public Prodotto(string pro, string name)
        {
            _produttore = pro;
            _nome = name;
        }
        public Prodotto()
        {

        }
        public virtual float getScontato()
        {
            return Prezzo;
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Produttore
        {
            get { return _produttore; }
            set { _produttore = value; }
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }
        public float Prezzo
        {
            get { return _prezzo; }
            set { _prezzo = value; }
        }
        public virtual string ToString()
        {
            return Id + ";" + Nome + ";"+Produttore + ";"+Prezzo +";"+getScontato().ToString()+ ";"+Descrizione;
        }
        public virtual Prodotto Clone(Prodotto p)
        {
            return p;
        }
        public bool Equals(Prodotto p)
        {
            if (p == null)
                return false;
            if (this == p)
                return true;
            return this.Id == p.Id;
        }
    }
}
