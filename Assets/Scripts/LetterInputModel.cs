using System;
using System.Collections.Generic;

namespace FineGameDesign.Utils
{
    // View displays letter texts and animations in model:
    //    Buttons
    //    Selected
    //    Submitted
    //    Hints
    // Each letter has:
    //    Animation state
    //    Text
    // Unity Toykit makes it convenient
    // to wire lists of states to to lists of animator owners,
    // And to wire lists of texts to lists of text owners.
    [System.Serializable]
    public sealed class LetterInputModel
    {
        public delegate void NextSelected(int previousNumSelected, int selectedIndex);
        public event NextSelected onNextSelected;
        public event Action onClearSelection;

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
        public string shuffleCharacter = " ";

        public string tutorState = "none";
        public string tutorText = "";
        public string taskText = "Spell a word.";

        public string addKeyText = "To spell, you can also press a key on the KEYBOARD.";
        public string shuffleKeyText = "To shuffle, you can also press the SPACE bar on the KEYBOARD.";
        public string shuffleButtonKeyText = "Shuffle\n[Space]";
        public string backspaceKeyText = "To delete a letter, you can also press backspace or delete key on the KEYBOARD.";
        public string backspaceButtonKeyText = "Delete\n[Backspace]";

        public bool isTutorKey = false;
        public bool isTutorTask = true;
        public bool isEnabled = true;
        public bool isShuffleOnPopulate = true;

        // Hides extra letters.
        // Otherwise, when going from a longer word to a shorter word,
        // then the last letters are not hidden.
        //
        // Shuffles order of button texts.
        // Otherwise, the spelling order can be inferred.
        public void Populate(string word)
        {
            buttons.texts = DataUtil.Split(word, "");
            hint.Populate(buttons.texts);
            isEnabled = true;
            if (isShuffleOnPopulate)
            {
                Shuffle();
            }
            else
            {
                ClearSelection();
            }
            MayTutorTask();
        }

        public void Shuffle(bool isButton = false)
        {
            if (!isEnabled)
            {
                return;
            }
            Deck.ShuffleList(buttons.texts);
            ClearSelection();
            MayTutorKey(isButton, shuffleKeyText);
        }

        public void ClearSelection()
        {
            int length = DataUtil.Length(buttons.texts);
            int index, end;
            buttons.states.Clear();
            for (index = 0, end = DataUtil.Length(buttons.texts); index < end; ++index)
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
            if (onClearSelection != null)
                onClearSelection();
        }

        public void Input(List<string> inputs)
        {
            if (!isEnabled)
            {
                return;
            }
            for (int index = 0, end = DataUtil.Length(inputs); index < end; ++index)
            {
                string input = inputs[index];
                if (input == shuffleCharacter)
                {
                    Shuffle();
                }
                else if (input == backspaceCharacter)
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
            if (!isEnabled)
            {
                return;
            }
            letter = letter.ToUpper();
            if (SetFirstButton(letter))
            {
                SetFirstSelect(letter);
            }
            MayTutorKey(isButton, addKeyText);
        }

        public void AddIndex(int index, bool isButton = false)
        {
            if (!isEnabled)
            {
                return;
            }
            if (SelectButton(index))
            {
                string letter = buttons.texts[index];
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
            if (!isEnabled)
            {
                return;
            }
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
            if (!isEnabled)
            {
                return;
            }
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
                isSelected = SelectButton(index);
                break;
            }
            return isSelected;
        }

        private bool SelectButton(int index)
        {
            if (buttons.states[index] == selectBeginState)
            {
                return false;
            }
            buttons.states[index] = selectBeginState;
            buttonIndexes.Add(index);
            if (onNextSelected != null)
            {
                onNextSelected(buttonIndexes.Count - 1, index);
            }
            return true;
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
