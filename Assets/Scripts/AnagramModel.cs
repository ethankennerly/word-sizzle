using Finegamedesign.Utils;

namespace Finegamedesign.WordSizzle
{
	[System.Serializable]
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
			state = "play_begin";
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
