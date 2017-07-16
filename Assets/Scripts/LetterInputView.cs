using System.Collections.Generic;
using UnityEngine;

namespace Finegamedesign.Utils
{
	public sealed class LetterInputView : MonoBehaviour
	{
		public WordView buttons = new WordView();
		public WordView selects = new WordView();
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
		}
	}
}
