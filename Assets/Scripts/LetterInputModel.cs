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

		public string selection = "";

		public string emptyState = "";
		public string beginState = "begin";
		public string selectedState = "selected";

		public void Populate(string word)
		{
			int length = DataUtil.Length(word);
			buttons.texts = DataUtil.Split(word, "");
			buttons.states.Clear();
			for (int index = 0, end = length; index < end; ++index)
			{
				buttons.states.Add(beginState);
			}

			selects.texts.Clear();
			selects.states.Clear();
			for (int index = 0, end = length; index < end; ++index)
			{
				selects.texts.Add(emptyState);
				selects.states.Add(beginState);
			}
			selection = "";
		}

		public void Add(string letter)
		{
			letter = letter.ToUpper();
			if (SetFirstButton(letter))
			{
				SetFirstSelect(letter);
			}
		}

		private bool SetFirstButton(string letter)
		{
			bool isSelected = false;
			for (int index = 0, end = buttons.texts.Count; index < end; ++index)
			{
				string text = buttons.texts[index];
				if (letter != text)
				{
					continue;
				}
				if (buttons.states[index] == selectedState)
				{
					continue;
				}
				buttons.states[index] = selectedState;
				buttons.texts[index] = letter;
				isSelected = true;
				break;
			}
			return isSelected;
		}

		private void SetFirstSelect(string letter)
		{
			for (int selectIndex = 0, end = selects.states.Count; selectIndex < end; ++selectIndex)
			{
				if (selects.states[selectIndex] == selectedState)
				{
					continue;
				}
				selects.states[selectIndex] = selectedState;
				selects.texts[selectIndex] = letter;
				selection += letter;
				break;
			}
		}
	}
}
