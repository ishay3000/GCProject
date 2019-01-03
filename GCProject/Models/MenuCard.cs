namespace GCProject.Models
{
	/// <summary>
	/// A class that represents a card in the menu window
	/// </summary>
	public class MenuCard
	{
		private string _cardText;
		private string _imagePath;

		/// <summary>
		/// Constructs a card with its text and image source
		/// </summary>
		/// <param name="cardText"></param>
		/// <param name="imagePath"></param>
		public MenuCard(string cardText, string imagePath)
		{
			_cardText = cardText;
			_imagePath = imagePath;
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
	}
}