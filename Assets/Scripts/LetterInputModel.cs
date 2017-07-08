using System.Collections.Generic;

namespace Finegamedesign.Utils
{
	// View displays letter texts and animations in model:
	//	Buttons
	//	Selected
	//	Submitted
	//	Hints
	// Each letter has:
	//	Animation state
	//	Text
	// Unity Toykit makes it convenient
	// to wire lists of states to to lists of animator owners,
	// And to wire lists of texts to lists of text owners.
	[System.Serializable]
	public sealed class LetterInputModel
	{
		public int letterMax = 3;

		public WordViewModel buttons = new WordViewModel();
		public WordViewModel selects = new WordViewModel();
		public WordViewModel submits = new WordViewModel();
		public WordViewModel hints = new WordViewModel();

		public string beginState = "begin";
		public string selectedState = "selected";

		public void Populate(string word)
		{
			buttons.texts = DataUtil.Split(word, "");
			buttons.states.Clear();
			for (int index = 0, end = buttons.texts.Count; index < end; ++index)
			{
				buttons.states.Add(beginState);
			}
		}

		public void Add(string letter)
		{
			int index = buttons.texts.IndexOf(letter);
			if (index < 0)
			{
				return;
			}
			buttons.states[index] = selectedState;
		}
	}
}
