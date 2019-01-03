using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GCProject.Models;

namespace GCProject.ViewModels
{
	class MenuCardViewModel : AbsViewModel
	{
		private string _cardText;
		private string _imagePath;
		private string _cardDescription;
		private readonly ObservableCollection<MenuCard> _cards = new ObservableCollection<MenuCard>();
		private RelayCommand _cardCommand;

		public MenuCardViewModel()
		{
			LoadCards();
			_cardCommand = new RelayCommand((o => true), ((o) => MessageBox.Show("Hello, World!")));
		}


		/// <summary>
		/// Loads the menu cards
		/// </summary>
		private void LoadCards()
		{
			_cards.Add(new MenuCard("Stenography",
				@"C:\Users\Ishay Cena\Documents\Visual Studio 2017\Projects\GCProject\GCProject\Resources\Images\Scroll view images\stenography.png",
				"Hide a message in a WAV file using stenography",
				new RelayCommand(o => true, o => StenographyCommand())));
			_cards.Add(new MenuCard("Scan Network",
				@"C:\Users\Ishay Cena\Documents\Visual Studio 2017\Projects\GCProject\GCProject\Resources\Images\Scroll view images\2014_security_scanning.png",
				"Scan the network for devices",
				new RelayCommand(o => true, o => ScanCommand())));
		}

		private void StenographyCommand()
		{
			MessageBox.Show("Stenography not implemented yet.");
		}

		private void ScanCommand()
		{
			MessageBox.Show("Scan not implemented yet.");
		}

		public string CardText
		{
			get => _cardText;
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
			get => _imagePath;
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
			get => _cardDescription;
			set
			{
				if (_cardDescription != value)
				{
					_cardDescription = value;
					OnPropertyChanged("CardDescription");
				}
			}
		}

		public ICommand CardCommand
		{
			get => _cardCommand;
			//set
			//{
			//	if (_cardCommand != value)
			//	{
			//		_cardCommand = value;
			//		OnPropertyChanged("CardCommand");
			//	}
			//}
		}

		public ObservableCollection<MenuCard> Cards => _cards;
	}
}
