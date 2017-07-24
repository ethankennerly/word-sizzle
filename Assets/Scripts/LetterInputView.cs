using System.Collections.Generic;
using UnityEngine;

namespace Finegamedesign.Utils
{
	public sealed class LetterInputView : MonoBehaviour
	{
		public WordView buttons = new WordView();
		public WordView selects = new WordView();

		public WordView hints = new WordView();
		public GameObject hintButton;

		public GameObject backspaceButton;

		public GameObject tutor;
		public GameObject tutorText;

		public LetterInputController controller = new LetterInputController();


		public void Setup()
		{
			MayFindObjects();
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

		private void MayFindObjects()
		{
			buttons.MayFindObjects(gameObject, "Buttons/", controller.model.letterMax);
			selects.MayFindObjects(gameObject, "Selects/", controller.model.letterMax);
			tutor = SceneNodeView.GetChild(gameObject, "Tutor", tutor);
			tutorText = SceneNodeView.GetChild(gameObject, "Tutor/TutorText", tutorText);
			backspaceButton = SceneNodeView.GetChild(gameObject, "BackspaceButton", backspaceButton);

			hints.MayFindObjects(gameObject, "Hints/", controller.model.letterMax);
			hintButton = SceneNodeView.GetChild(gameObject, "HintButton", hintButton);
		}
	}
}
