using System.Collections.Generic;

namespace Finegamedesign.Utils
{
	public sealed class TextDeck
	{
		public string resourcePath = "";
		public int resetCount = 0;
		// Ratio scales with number of lines.
		// Resetting limits how many strings are used when repeatedly removing a string.
		public float resetRatio = 0.25f;

		private List<string> originalLines;
		private List<string> lines;

		// Expects resource path was already set.
		public void Setup()
		{
			string[] lineArray = StringUtil.ParseLines(StringUtil.Read(resourcePath));
			originalLines = DataUtil.ToList(lineArray);
			Reset();
		}

		public string RemoveAt(float normal)
		{
			MayReset();
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

		private void Reset()
		{
			lines = new List<string>(originalLines);
		}

		private void MayReset()
		{
			int count = lines.Count;
			if (count <= resetCount)
			{
				Reset();
			}
			float lineRatio = (float)count / originalLines.Count;
			if (lineRatio <= resetRatio)
			{
				Reset();
			}
		}
	}
}
