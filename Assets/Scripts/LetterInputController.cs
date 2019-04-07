using System;
using System.Collections.Generic;
using UnityEngine;

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
    public sealed class LetterInputController
    {
        public LetterInputModel model = new LetterInputModel();
        // Not public to avoid recursive serialization.
        internal LetterInputView view;

        private Action<Collider2D> m_OnCollisionEnter2D;
        private Action<Collider2D> m_OnCollisionStay2D;
        private Action m_OnMouseUp;

        public void Setup()
        {
            model.backspaceCharacter = KeyInputSystem.backspaceCharacter;
            UpdateButtonKeyText();

            if (m_OnCollisionEnter2D == null)
                m_OnCollisionEnter2D = UpdateInputEnter;
            if (m_OnCollisionStay2D == null)
                m_OnCollisionStay2D = UpdateInputStay;
            if (m_OnMouseUp == null)
                m_OnMouseUp = model.ClearSelection;

            ClickInputSystem.instance.onCollisionEnter2D -= m_OnCollisionEnter2D;
            ClickInputSystem.instance.onCollisionEnter2D += m_OnCollisionEnter2D;
            ClickInputSystem.instance.onCollisionStay2D -= m_OnCollisionStay2D;
            ClickInputSystem.instance.onCollisionStay2D += m_OnCollisionStay2D;
            ClickInputSystem.instance.onMouseUp -= m_OnMouseUp;
            ClickInputSystem.instance.onMouseUp += m_OnMouseUp;
        }

        ~LetterInputController()
        {
            ClickInputSystem.instance.onCollisionEnter2D -= m_OnCollisionEnter2D;
            ClickInputSystem.instance.onCollisionStay2D -= m_OnCollisionStay2D;
            ClickInputSystem.instance.onMouseUp -= m_OnMouseUp;
        }

        public void UpdateButtonKeyText()
        {
            if (model.isTutorKey)
            {
                TextView.SetText(view.backspaceButtonText, model.backspaceButtonKeyText);
                TextView.SetText(view.shuffleButtonText, model.shuffleButtonKeyText);
                TextView.SetText(view.hintButtonText, model.hint.buttonKeyText);
            }
        }

        public void Update()
        {
            UpdateKeyboardInput();
            UpdateLetters();
            AnimationView.SetState(view.tutor, model.tutorState);
            TextView.SetText(view.tutorText, model.tutorText);
        }

        private void UpdateInputStay(Collider2D target)
        {
            int addIndex = view.buttons.buttons.IndexOf(target);
            if (addIndex < 0)
                return;

            model.AddIndex(addIndex, true);
        }

        private void UpdateInputEnter(Collider2D target)
        {
            int backspaceIndex = view.selects.buttons.IndexOf(target);
            if (backspaceIndex >= 0 || target == view.backspaceButton)
            {
                model.Backspace(true);
                return;
            }
            if (target == view.hintButton)
            {
                model.HintButton();
                return;
            }
            if (target == view.shuffleButton)
            {
                model.Shuffle(true);
                return;
            }
        }

        private void UpdateKeyboardInput()
        {
            model.Input(KeyInputSystem.InputList());
        }

        private void UpdateLetters()
        {
            AnimationView.SetStates(view.buttons.states, model.buttons.states);
            TextView.SetTexts(view.buttons.texts, model.buttons.texts);

            AnimationView.SetStates(view.selects.states, model.selects.states);
            TextView.SetTexts(view.selects.texts, model.selects.texts);

            AnimationView.SetStates(view.hints.states, model.hint.selects.states);
            TextView.SetTexts(view.hints.texts, model.hint.selects.texts);
        }
    }
}
