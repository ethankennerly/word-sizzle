using Finegamedesign.Utils;

namespace Finegamedesign.WordSizzle
{
	[System.Serializable]
	public sealed class AnagramModel
	{
		public string selection;

		public string word;

		public bool isComplete = false;
		private bool wasComplete = false;
		private bool isFull = false;

		public string state = "none";

		public Words words = new Words();
		public WordLevels levels = new WordLevels();

		public void Setup()
		{
			words.Setup();
			levels.Setup();
			Populate(levels.Current());
		}

		public void Populate(string nextWord = null)
		{
			if (nextWord == null)
			{
				nextWord = levels.Current();
			}
			word = nextWord;
			selection = "";
			isComplete = false;
			wasComplete = false;
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
				wasComplete = isComplete;
				isComplete = words.all.ContainsKey(selection);
				if (isComplete && !wasComplete)
				{
					state = "win_begin";
				}
			}
		}
	}
}
