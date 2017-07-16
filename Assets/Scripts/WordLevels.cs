using System.Collections.Generic;

namespace Finegamedesign.Utils
{
	public sealed class WordLevels
	{
		public string path = "anagram_words.txt";

		public List<string> words;
		public int index = 0;
		public int step = 50;

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
		}
	}
}
