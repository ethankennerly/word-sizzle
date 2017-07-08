using System.Collections.Generic;
using UnityEngine;

namespace Finegamedesign.Utils
{
	public sealed class LetterInputView : MonoBehaviour
	{
		public WordView buttons = new WordView();
		public WordView selects = new WordView();
		public LetterInputController controller = new LetterInputController();

		public void Setup()
		{
			MayFindObjects();

			controller.view = this;
			controller.Setup();
		}

		private void MayFindObjects()
		{
			if (buttons.states == null || buttons.states.Count == 0)
			{
				buttons.states = SceneNodeView.GetChildrenByPattern(
					gameObject, "Buttons/LetterContainer_{0}",
					controller.model.letterMax);
			}
			if (buttons.texts == null || buttons.texts.Count == 0)
			{
				buttons.texts = SceneNodeView.GetChildrenByPattern(
					gameObject, "Buttons/LetterContainer_{0}/LetterButton/Text",
					controller.model.letterMax);
			}

			if (selects.states == null || selects.states.Count == 0)
			{
				selects.states = SceneNodeView.GetChildrenByPattern(
					gameObject, "Selects/LetterContainer_{0}",
					controller.model.letterMax);
			}
			if (selects.texts == null || selects.texts.Count == 0)
			{
				selects.texts = SceneNodeView.GetChildrenByPattern(
					gameObject, "Selects/LetterContainer_{0}/LetterButton/Text",
					controller.model.letterMax);
			}
		}
	}
}
