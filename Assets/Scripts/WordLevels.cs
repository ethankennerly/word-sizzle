using System.Collections.Generic;

namespace Finegamedesign.Utils
{
	public sealed class WordLevels
	{
		public string path = "anagram_words.txt";

		public List<string> words;

		private Staircase staircase = new Staircase();
		public int Number { get { return staircase.GetNumber(); } }
		public int Total { get { return staircase.GetTotal(); } }

		// Step was 50.
		// 2017-07-22 Jennifer Russ: Looks up:  airshot, disinter, two more.
		// 2017-07-22 Jennifer Russ: [When jumping each 50, there are only about 60 anagrams to solve.]
		// Step 20.  Step was 24.
		// 2017-08-26 Jennifer Russ: Said words are always in same order.
		private int step = 20;

		public void Setup()
		{
			if (words != null)
			{
				return;
			}
			string text = StringUtil.Read(path);
			string[] lines = text.Split('\n');
			words = new List<string>();
			for (int i = 0, length = lines.Length; i < length; ++i)
			{
				string word = lines[i];
				words.Add(word);
			}
			staircase.Setup(step, words.Count);
		}

		public string Current()
		{
			return words[staircase.GetIndex()];
		}

		// Random offset.  Number increases by one.
		public void Next()
		{
			staircase.Next();
		}
	}
}
