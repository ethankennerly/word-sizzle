namespace Finegamedesign.Utils
{
	public sealed class TimerTextDeck
	{
		public string[] resourcePaths = {
			"fast.txt",
			"slow.txt"
		};
		public Timer timer;
		private TextDeck[] decks;
		public string Selected { get; private set; }

		public void Setup()
		{
			decks = new TextDeck[resourcePaths.Length];
			for (int index = 0, end = resourcePaths.Length; index < end; ++index)
			{
				TextDeck deck = new TextDeck();
				deck.resourcePath = resourcePaths[index];
				deck.Setup();
				decks[index] = deck;
			}
			Selected = "";
		}

		public string Select()
		{
			int index = timer.StateIndex;
			TextDeck deck = decks[index];
			Selected = deck.RemoveAt(timer.NormalInState);
			return Selected;
		}
	}
}
