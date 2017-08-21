using System.Collections.Generic;

namespace Finegamedesign.Utils
{
	public sealed class TextDeck
	{
		public string resourcePath = "";

		private List<string> lines;

		public void Setup()
		{
			string[] lineArray = StringUtil.ParseLines(StringUtil.Read(resourcePath));
			lines = DataUtil.ToList(lineArray);
		}

		public string RemoveAt(float normal)
		{
			int end = lines.Count;
			int index = (int)(normal * end);
			if (index >= end)
			{
				index = end - 1;
			}
			else if (index < 0)
			{
				index = 0;
			}
			string selected = lines[index];
			DataUtil.RemoveAt(lines, index);
			return selected;
		}
	}
}
