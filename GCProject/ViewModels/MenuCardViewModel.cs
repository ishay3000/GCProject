using System.Collections.ObjectModel;
using System.Windows;
using GCProject.Commands;
using GCProject.miscellanies;
using GCProject.Models;

namespace GCProject.ViewModels
{
	public class MenuCardViewModel : BaseViewModel
	{
		private string _cardText;
		private string _imagePath;
		private string _cardDescription;
		private readonly ObservableCollection<MenuCardModel> _cards = new ObservableCollection<MenuCardModel>();
		//private RelayCommand _cardCommand;

		private static readonly MenuCardViewModel Instance = new MenuCardViewModel();

		public static MenuCardViewModel INSTANCE => Instance;

		private MenuCardViewModel()
		{
			LoadCards();
		}


		/// <summary>
		/// Loads the menu cards
		/// </summary>
		private void LoadCards()
		{
			_cards.Add(new MenuCardModel("Call Manager",
				@"../Resources/Images/Scroll view images/Call_Manager.png",
				"Initiate a Call Manager software (using Dialogic Global Call)",
				new RelayCommand(o => true, o => StenographyCommand())));
			
			//"../Resources/Images/Scroll view images/Call_Manager.png"
			_cards.Add(new MenuCardModel("Scan Network",
				@"../Resources/Images/Scroll view images/2014_security_scanning.png",
				"Scan the network for Telephony devices",
				new RelayCommand(o => true, o => ScanCommand())));
		}

		private void StenographyCommand()
		{
			MessageBox.Show("Call management is not implemented yet.");
		}

		private void ScanCommand()
		{
			//MessageBox.Show("Network scanning not is implemented yet.");
			FrameManager.MovePage(ControlsTitles.ScanResults);
		}

		// TODO reserved for future use (?)
/*		private void ViewLog()
		{
			MessageBox.Show("Log Viewing is not implemented yet.");
		}*/

		public string CardText
        {
            get { return _cardText; }
            set
			{
				if (_cardText != value)
				{
					_cardText = value;
					OnPropertyChanged("CardText");
				}
			}
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set
			{
				if (_imagePath != value)
				{
					_imagePath = value;
					OnPropertyChanged("ImagePath");
				}
			}
        }

        public string CardDescription
        {
            get { return _cardDescription; }
            set
			{
				if (_cardDescription != value)
				{
					_cardDescription = value;
					OnPropertyChanged("CardDescription");
				}
			}
        }

        public ObservableCollection<MenuCardModel> Cards => _cards;
	}
}
