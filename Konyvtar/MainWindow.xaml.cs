using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Konyvtar
{
	public partial class MainWindow : Window
	{
		string fajl = "olvasok.txt";
		List<Olvaso> olvasok = new List<Olvaso>();

		public MainWindow()
		{
			InitializeComponent();
			BetoltesFajlbol();
			ListBoxFrissit();
		}

		private void btnMentes_Click(object sender, RoutedEventArgs e)
		{
			if (!int.TryParse(tbEletkor.Text, out int eletkor))
			{
				tbUzenet.Text = "Hibás életkor!";
				return;
			}

			ComboBoxItem kivalasztott = cbMufaj.SelectedItem as ComboBoxItem;
			string mufaj = kivalasztott?.Content.ToString() ?? "";

			List<string> ertesitesekList = new List<string>();
			if (chkHirlevel.IsChecked == true) ertesitesekList.Add("Hírlevél");
			if (chkSms.IsChecked == true) ertesitesekList.Add("SMS");
			string ertesitesek = string.Join(", ", ertesitesekList);

			string tagsag = "";
			if (rbNormal.IsChecked == true) tagsag = "Normál";
			else if (rbDiak.IsChecked == true) tagsag = "Diák";
			else if (rbNyugdijas.IsChecked == true) tagsag = "Nyugdíjas";

			Olvaso uj = new Olvaso()
			{
				Nev = tbNev.Text,
				Eletkor = eletkor,
				Mufaj = mufaj,
				Ertesitesek = ertesitesek,
				Tagsag = tagsag
			};

			olvasok.Add(uj);

			using (StreamWriter sw = new StreamWriter(fajl, true))
			{
				sw.WriteLine($"{uj.Nev};{uj.Eletkor};{uj.Mufaj};{uj.Ertesitesek};{uj.Tagsag}");
			}

			ListBoxFrissit();

			tbUzenet.Text = "Sikeres regisztráció!";
		}

		private void BetoltesFajlbol()
		{
			if (!File.Exists(fajl)) return;

			string[] sorok = File.ReadAllLines(fajl);

			foreach (var sor in sorok)
			{
				string[] adatok = sor.Split(';');
				if (adatok.Length == 5)
				{
					olvasok.Add(new Olvaso()
					{
						Nev = adatok[0],
						Eletkor = int.Parse(adatok[1]),
						Mufaj = adatok[2],
						Ertesitesek = adatok[3],
						Tagsag = adatok[4]
					});
				}
			}
		}

		private void ListBoxFrissit()
		{
			lbOlvasok.Items.Clear();
			foreach (var o in olvasok)
			{
				lbOlvasok.Items.Add(o);
			}
		}
	}
}