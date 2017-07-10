namespace Finegamedesign.WordSizzle
{
	public sealed class AnagramModel
	{
		public string selection;

		public string word;

		public bool isComplete = false;

		public string state = "none";

		public void Populate(string nextWord)
		{
			word = nextWord;
			selection = "";
			isComplete = false;
			state = "begin";
		}

		public void Update(float deltaTime)
		{
			isComplete = selection == word;
			if (isComplete)
			{
				state = "win_begin";
			}
		}
	}
}
