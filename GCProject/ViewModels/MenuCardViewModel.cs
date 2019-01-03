using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCProject.Models;

namespace GCProject.ViewModels
{
	class MenuCardViewModel : AbsViewModel
	{
		private string _cardText;
		private string _imagePath;
		private readonly ObservableCollection<MenuCard> _cards = new ObservableCollection<MenuCard>();
		
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

		public ObservableCollection<MenuCard> Cards => _cards;
	}
}
