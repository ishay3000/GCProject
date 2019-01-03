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


		/// <summary>
		/// Constructs a card with its text and image source
		/// </summary>
		/// <param name="cardText"></param>
		/// <param name="imagePath"></param>
		public MenuCard(string cardText, string imagePath, string cardDescription)
		{
			_cardText = cardText;
			_imagePath = imagePath;
			_cardDescription = cardDescription;
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
	}
}