using System.Collections.Generic;

namespace Finegamedesign.Utils
{
	[System.Serializable]
	public sealed class HintModel
	{
		public List<string> answers = new List<string>();
		public WordViewModel selects = new WordViewModel();
		public bool isButton = false;
		public int revealCount = 0;

		public int letterMax = 12;
		public string hintCharacter = " ";
		public string selectBeginState = "select_begin";
		public string emptyState = "";
		public string noneState = "none";

		public string tutorKeyText = "To hint, you can also press the SPACE bar on the KEYBOARD.";

		private static void Copy<T>(List<T> froms, List<T> tos)
		{
			tos.Clear();
			for (int index = 0, end = froms.Count; index < end; ++index)
			{
				tos.Add(froms[index]);
			}
		}

		// Hides letters.
		public void Populate(List<string> nextAnswers)
		{
			Copy(nextAnswers, answers);
			selects.texts.Clear();
			selects.states.Clear();
			for (int index = 0, end = letterMax; index < end; ++index)
			{
				selects.texts.Add(emptyState);
				selects.states.Add(noneState);
			}
			revealCount = 0;
		}

		public bool Input(string input)
		{
			if (input == hintCharacter)
			{
				Select();
				return true;
			}
			return false;
		}

		public void Select(bool isButtonPressed = false)
		{
			if (revealCount >= answers.Count - 1)
			{
				return;
			}
			isButton = isButtonPressed;
			selects.texts[revealCount] = answers[revealCount];
			selects.states[revealCount] = selectBeginState;
			++revealCount;
		}
	}
}
