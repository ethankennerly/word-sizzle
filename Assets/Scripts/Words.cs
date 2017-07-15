using System.Collections.Generic;

namespace Finegamedesign.Utils
{
	public sealed class Words
	{
		public string path = "TWL06.txt";

		public Dictionary<string, object> all;

		public void Setup()
		{
			if (all != null)
			{
				return;
			}
			string text = StringUtil.Read(path);
			string[] lines = text.Split('\n');
			int length = lines.Length;
			all = new Dictionary<string, object>();
			for (int i = 0; i < length; i++)
			{
				string word = lines[i];
				all[word] = true;
			}
		}
	}
}
