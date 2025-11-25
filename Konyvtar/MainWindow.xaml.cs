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
		}
	}
}