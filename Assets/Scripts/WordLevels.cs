using System.Collections.Generic;

namespace Finegamedesign.Utils
{
	public sealed class WordLevels
	{
		public string path = "anagram_words.txt";

		public List<string> words;
		public int index = 0;
		// Step was 50.
		// 2017-07-22 Jennifer Russ: Looks up:  airshot, disinter, two more.
		// 2017-07-22 Jennifer Russ: [When jumping each 50, there are only about 60 anagrams to solve.]
		public int step = 24;

		public int Number { get; private set; }
		public int Total { get; private set; }

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
			Number = 1;
			Total = (int)UnityEngine.Mathf.Ceil((float)lines.Length / step);
		}

		public string Current()
		{
			return words[index];
		}

		public void Next(int nextStep = -999)
		{
			if (nextStep == -999)
			{
				nextStep = step;
			}
			int nextIndex = index + nextStep;
			if (nextIndex < DataUtil.Length(words))
			{
				index = nextIndex;
			}
			Number = index / step;
		}
	}
}
