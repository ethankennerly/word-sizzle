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
		public int letterMax = 12;

		public WordViewModel buttons = new WordViewModel();
		public WordViewModel selects = new WordViewModel();
		public WordViewModel submits = new WordViewModel();

		public HintModel hint = new HintModel();

		public List<int> buttonIndexes = new List<int>();

		public string selection = "";

		public string emptyState = "";
		public string noneState = "none";
		public string beginState = "begin";
		public string selectBeginState = "select_begin";
		public string selectEndState = "select_end";

		public string backspaceCharacter = "\b";

		public string tutorState = "none";
		public string tutorText = "";
		public string taskText = "Spell a word.";
		public string addKeyText = "To spell, you can also press a key on the KEYBOARD.";
		public string backspaceKeyText = "To delete a letter, you can also press backspace or delete on the KEYBOARD.";

		public bool isTutorKey = false;
		public bool isTutorTask = true;

		// Hides extra letters.
		// Otherwise, when going from a longer word to a shorter word,
		// then the last letters are not hidden.
		//
		// Shuffles order of button texts.
		// Otherwise, the spelling order can be inferred.
		public void Populate(string word)
		{
			int length = DataUtil.Length(word);
			int index, end;
			buttons.texts = DataUtil.Split(word, "");
			hint.Populate(buttons.texts);
			Deck.ShuffleList(buttons.texts);
			buttons.states.Clear();
			for (index = 0, end = length; index < end; ++index)
			{
				buttons.states.Add(beginState);
			}
			for (; index < letterMax; ++index)
			{
				buttons.states.Add(noneState);
			}

			selects.texts.Clear();
			selects.states.Clear();
			for (index = 0, end = length; index < end; ++index)
			{
				selects.texts.Add(emptyState);
				selects.states.Add(beginState);
			}
			for (; index < letterMax; ++index)
			{
				selects.texts.Add(emptyState);
				selects.states.Add(noneState);
			}
			selection = "";
			buttonIndexes.Clear();
			MayTutorTask();
		}

		public void Input(List<string> inputs)
		{
			for (int index = 0, end = DataUtil.Length(inputs); index < end; ++index)
			{
				string input = inputs[index];
				if (input == backspaceCharacter)
				{
					Backspace();
				}
				else if (hint.Input(input))
				{
				}
				else
				{
					Add(input);
				}
			}
		}

		public void Add(string letter, bool isButton = false)
		{
			letter = letter.ToUpper();
			if (SetFirstButton(letter))
			{
				SetFirstSelect(letter);
			}
			MayTutorKey(isButton, addKeyText);
		}

		private void MayTutorTask()
		{
			if (isTutorTask)
			{
				tutorState = "begin";
				tutorText = taskText;
				isTutorTask = false;
			}
		}

		public void HintButton()
		{
			hint.Select(true);
			MayTutorKey(true, hint.tutorKeyText);
		}

		// If tutoring and pressing a button, sets tutor text and state.
		// Otherwise if tutor state was showing, hides tutor state.
		private void MayTutorKey(bool isButton, string text)
		{
			if (isTutorKey && isButton)
			{
				tutorState = "begin";
				tutorText = text;
			}
			else if (tutorState != "none" && tutorState != "end")
			{
				tutorState = "end";
			}
		}

		public void Backspace(bool isButton = false)
		{
			int index = DataUtil.Length(selection) - 1;
			if (index < 0)
			{
				return;
			}
			selection = selection.Substring(0, index);
			selects.states[index] = selectEndState;
			selects.texts[index] = emptyState;
			int buttonIndex = buttonIndexes[index];
			buttons.states[buttonIndex] = selectEndState;
			DataUtil.RemoveAt(buttonIndexes, index);
			MayTutorKey(isButton, backspaceKeyText);
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
				if (buttons.states[index] == selectBeginState)
				{
					continue;
				}
				buttons.states[index] = selectBeginState;
				buttons.texts[index] = letter;
				buttonIndexes.Add(index);
				isSelected = true;
				break;
			}
			return isSelected;
		}

		private void SetFirstSelect(string letter)
		{
			for (int selectIndex = 0, end = selects.states.Count; selectIndex < end; ++selectIndex)
			{
				if (selects.states[selectIndex] == selectBeginState)
				{
					continue;
				}
				selects.states[selectIndex] = selectBeginState;
				selects.texts[selectIndex] = letter;
				selection += letter;
				break;
			}
		}
	}
}
