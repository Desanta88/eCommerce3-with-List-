namespace eCommerce
{
    public partial class Form1 : Form
    {
        public Alimentare product1;
        public Elettronico product2;
        public Penne product3;
        public FogliDiCartaPerLaStampa product4;
        public List<Prodotto> prodottiPre = new List<Prodotto>();
        public List<Prodotto> prodotti = new List<Prodotto>();
        public carrello car = new carrello("dfasij");
        public string prodottoSelect;
        public int  index = 0;
        public string[] intes = new string[] { "ID", "NOME","PRODUTTORE","PREZZO","SCONTATO","DESCRIZIONE","DATA SCADENZA","MODELLO","GRAMMATURA","FUNZIONAMENTO" };
        public string[] ingredienti = new string[] { "pollo" };
        public DateTime date = new DateTime(2023, 2, 6);
        public DateTime scadenza = new DateTime(2023, 2, 28);
        public Form1()
        {
            InitializeComponent();
            product1 = new Alimentare("AIA", "cotoletta","una buonissima coto",6,ingredienti,scadenza);
            prodottiPre.Add(product1);
            product2 = new Elettronico("logitech", "mouse wireless","un bel mouse",15,"weaeawdx");
            prodottiPre.Add(product2);
            product3 = new Penne("bic", "penna blu","una penna",3,"scrivere");
            prodottiPre.Add(product3);
            product4 = new FogliDiCartaPerLaStampa("yolo", "foglio bianco", "una foglio", 4, 7);
            prodottiPre.Add(product4);
            prodottoPredefiniti(prodottiPre);
            labelPrezzoToT.Text = "Prezzo Totale senza sconto:0";
            labelPrezzoSconto.Text = "Prezzo Totale con sconto:0";
            for (int i = 0; i < intes.Length; i++)
            {
                listViewCarrello.Columns.Add(intes[i],55);
            }
        }

        public void prodottoPredefiniti(List<Prodotto> p)
        {
            foreach(Prodotto prod in p)
            {
                ListViewItem A = new ListViewItem(prod.Nome);
                listViewProdotti.Items.Add(A);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Prodotto t = new Prodotto();
            prodottoSelect = listViewCarrello.SelectedItems[0].Text;
            t.Id = prodottoSelect;
            car.Rimuovi(t);
            if (listViewCarrello.SelectedIndices.Count > 0)
                index = listViewCarrello.SelectedIndices[0];
            listViewCarrello.Items.RemoveAt(index);
            labelPrezzoToT.Text = "Prezzo Totale senza sconto:" + car.getTotale().ToString();
            labelPrezzoSconto.Text = "Prezzo Totale con sconto:" + car.getTotaleScontato().ToString();
        }

        private void svuotaCarrelloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewCarrello.Items.Clear();
            car.Svuota();
            labelPrezzoToT.Text = "Prezzo Totale senza sconto:" + car.getTotale().ToString();
            labelPrezzoSconto.Text = "Prezzo Totale con sconto:" + car.getTotaleScontato().ToString();
        }

        private void buttonAggiungi_Click(object sender, EventArgs e)
        {
            
        }

        private void SvuotaCarrello_Click(object sender, EventArgs e)
        {
            listViewCarrello.Clear();
            car.Svuota();
            labelPrezzoToT.Text = "Prezzo Totale senza sconto:" + car.getTotale().ToString();
            labelPrezzoSconto.Text = "Prezzo Totale con sconto:" + car.getTotaleScontato().ToString();
        }

        public void MettiNelCarrello(string s, Prodotto[] p)
        {
      
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            prodottoSelect = listViewProdotti.SelectedItems[0].Text;
            Prodotto temp =null;
            for (int i = 0; i < prodottiPre.Count; i++)
            {
                if (prodottoSelect == prodottiPre[i].Nome)
                {
                    temp = prodottiPre[i].Clone(prodottiPre[i]);
                    car.Aggiungi(temp);
                }
            }
            if ((DateTime.Now == scadenza && temp is Alimentare) || (DateTime.Now > scadenza && temp is Alimentare))
            {
                MessageBox.Show("il prodotto è scaduto,esso verrà eliminato");
                if (listViewProdotti.SelectedIndices.Count > 0)
                    index = listViewProdotti.SelectedIndices[0];
                listViewProdotti.Items.RemoveAt(index);
            }
            else
            {
                ListViewItem riga = new ListViewItem(temp.ToString().Split(';'));
                listViewCarrello.Items.Add(riga);
                labelPrezzoToT.Text = "Prezzo Totale senza sconto:" + car.getTotale().ToString();
                labelPrezzoSconto.Text = "Prezzo Totale con sconto:" + car.getTotaleScontato().ToString();
            }
        }
    }
}