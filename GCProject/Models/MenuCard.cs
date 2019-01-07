using System.Windows.Input;
using GCProject.Commands;
using GCProject.ViewModels;

namespace GCProject.Models
{
	/// <summary>
	/// A class that represents a card in the menu window
	/// </summary>
	public class MenuCard
	{
		private string _cardText;
		private string _imagePath;
		private string _cardDescription;
		private RelayCommand _command;

		public MenuCard()
		{
		}


		/// <summary>
		/// Constructs a card with its text and image source
		/// </summary>
		/// <param name="cardText">The card's text</param>
		/// <param name="imagePath">The image path</param>
		/// <param name="cardDescription">The card's desc. will be displayed in the tooltip</param>
		/// <param name="command">The command for this card</param>
		public MenuCard(string cardText, string imagePath, string cardDescription, RelayCommand command)
		{
			_cardText = cardText;
			_imagePath = imagePath;
			_cardDescription = cardDescription;
			_command = command;
		}


		public string CardText
		{
			get => _cardText;
			set => _cardText = value;
		}

		public string ImagePath
		{
			get => _imagePath;
			set => _imagePath = value;
		}

		public string CardDescription
		{
			get => _cardDescription;
			set => _cardDescription = value;
		}

		public RelayCommand Command
		{
			get => _command;
			set => _command = value;
		}
	}
}