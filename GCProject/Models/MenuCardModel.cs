using System.Windows.Input;
using GCProject.Commands;
using GCProject.ViewModels;

namespace GCProject.Models
{
	/// <summary>
	/// A class that represents a card in the menu window
	/// </summary>
	public class MenuCardModel
	{
		private string _cardText;

        public MenuCardModel()
		{
		}


		/// <summary>
		/// Constructs a card with its text and image source
		/// </summary>
		/// <param name="cardText">The card's text</param>
		/// <param name="imagePath">The image path</param>
		/// <param name="cardDescription">The card's desc. will be displayed in the tooltip</param>
		/// <param name="command">The command for this card</param>
		public MenuCardModel(string cardText, string imagePath, string cardDescription, RelayCommand command)
		{
			_cardText = cardText;
			ImagePath = imagePath;
			CardDescription = cardDescription;
			Command = command;
		}

		public string CardText
        {
            get
            {
                return _cardText;
            }
            set
            {
                _cardText = value;
            }
        }

        public string ImagePath { get; set; }

        public string CardDescription { get; set; }

        public RelayCommand Command { get; set; }
    }
}