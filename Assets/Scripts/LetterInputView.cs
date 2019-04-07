using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FineGameDesign.Utils
{
    public sealed class LetterInputView : MonoBehaviour
    {
        public WordView buttons = new WordView();
        public WordView selects = new WordView();

        public WordView hints = new WordView();
        public Collider2D hintButton;
        public TextMeshPro hintButtonText;

        public Collider2D backspaceButton;
        public TextMeshPro backspaceButtonText;
        public Collider2D shuffleButton;
        public TextMeshPro shuffleButtonText;

        public Animator tutor;
        public TextMeshPro tutorText;

        public LetterInputController controller = new LetterInputController();

        public void Setup()
        {
            controller.model.isTutorKey = IsKeyboard();
            controller.view = this;
            controller.Setup();
        }

        private bool IsKeyboard()
        {
#if UNITY_WEBGL
            return true;
#elif UNITY_STANDALONE
            return true;
#else
            return false;
#endif
        }
    }
}
