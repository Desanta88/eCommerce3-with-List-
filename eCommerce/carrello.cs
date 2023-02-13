using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce
{
    public class carrello
    {
        private string _id;
        private List<Prodotto> Prodotti;
        private int i = 0, pos = 0;
        private float PrezzoTotaleSconto{ set; get; }
        private float PrezzoTotale { set; get; }

        public carrello(string iden)
        {
            _id = iden;
            Prodotti = new List<Prodotto>();
        }
        public string Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public void Aggiungi(Prodotto p)
        {
            if (p != null)
            {
                p.Id = "p" + i;
                Prodotti.Add(p);
                i++;
                PrezzoTotaleSconto=PrezzoTotaleSconto+p.getScontato();
                PrezzoTotale = PrezzoTotale + p.Prezzo;
            }
        }
        public void Rimuovi(Prodotto p)
        {
            Prodotti.Remove(p);
            PrezzoTotaleSconto = PrezzoTotaleSconto - Prodotti[pos].getScontato();
            PrezzoTotale = PrezzoTotale - Prodotti[pos].Prezzo;
        }
        public void Svuota()
        {
            for (int i = 0; i < Prodotti.Count; i++)
            {
                Prodotti.RemoveAt(i);
            }
            PrezzoTotaleSconto = 0;
            PrezzoTotale = 0;
        }
        public List<Prodotto> GetProdotti()
        {
            return Prodotti;
        }
        public int GetNProdotti()
        {
            return Prodotti.Count;
        }
        public float getTotale()
        {
            return PrezzoTotale;
        }
        public float getTotaleScontato()
        {
            return PrezzoTotaleSconto;
        }
    }
}
