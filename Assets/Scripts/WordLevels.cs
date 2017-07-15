using System.Collections.Generic;

namespace Finegamedesign.Utils
{
	public sealed class WordLevels
	{
		public string path = "anagram_words.txt";

		public List<string> words;
		public int index = 0;

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

		public void Next()
		{
			if (index + 1 < DataUtil.Length(words))
			{
				++index;
			}
		}
	}
}
