using Finegamedesign.Utils;

namespace Finegamedesign.WordSizzle
{
	[System.Serializable]
	public sealed class AnagramModel
	{
		public string selection;

		public string word;

		public bool isComplete = false;
		private bool isFull = false;

		public string state = "none";

		public Words words = new Words();

		public void Setup()
		{
			words.Setup();
		}

		public void Populate(string nextWord)
		{
			word = nextWord;
			selection = "";
			isComplete = false;
			state = "play_begin";
		}

		public void Update(float deltaTime)
		{
			UpdateComplete();
		}

		private void UpdateComplete()
		{
			isFull = DataUtil.Length(selection) == DataUtil.Length(word);
			if (isFull)
			{
				isComplete = words.all.ContainsKey(selection);
				if (isComplete)
				{
					state = "win_begin";
				}
			}
		}
	}
}
