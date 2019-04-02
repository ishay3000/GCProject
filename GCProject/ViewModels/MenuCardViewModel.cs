﻿using System.Collections.ObjectModel;
using System.Windows;
using GCProject.Commands;
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

		public MenuCardViewModel()
		{
			LoadCards();
			//_cardCommand = new RelayCommand((o => true), ((o) => MessageBox.Show("Hello, World!")));
		}


		/// <summary>
		/// Loads the menu cards
		/// </summary>
		private void LoadCards()
		{
			_cards.Add(new MenuCardModel("Call Manager",
				@"C:\Users\Ishay Cena\Documents\Visual Studio 2017\Projects\GCProject\GCProject\Resources\Images\Scroll view images\stenography.png",
				"Initiate a Call Manager software (Dialogic Global Call based)",
				new RelayCommand(o => true, o => StenographyCommand())));
			_cards.Add(new MenuCardModel("Scan Network",
				@"C:\Users\Ishay Cena\Documents\Visual Studio 2017\Projects\GCProject\GCProject\Resources\Images\Scroll view images\2014_security_scanning.png",
				"Scan the network for Telephony devices",
				new RelayCommand(o => true, o => ScanCommand())));
		}

		private void StenographyCommand()
		{
			MessageBox.Show("Call management is not implemented yet.");
		}

		private void ScanCommand()
		{
			MessageBox.Show("Network scanning not is implemented yet.");
		}

		// TODO reserved for future use (?)
/*		private void ViewLog()
		{
			MessageBox.Show("Log Viewing is not implemented yet.");
		}*/

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

		//public ICommand CardCommand
		//{
		//	get => _cardCommand;
		//	//set
		//	//{
		//	//	if (_cardCommand != value)
		//	//	{
		//	//		_cardCommand = value;
		//	//		OnPropertyChanged("CardCommand");
		//	//	}
		//	//}
		//}

		public ObservableCollection<MenuCardModel> Cards => _cards;
	}
}
