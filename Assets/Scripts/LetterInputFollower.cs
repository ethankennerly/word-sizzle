using System;
using UnityEngine;

namespace FineGameDesign.Utils
{
    public sealed class LetterInputFollower : MonoBehaviour
    {
        public LetterInputView inputView;
        public Follower follower;

        private event Action<int, Vector3> m_OnNextPositionSelected;

        private LetterInputModel.NextSelected m_OnNextSelected;

        /// <summary>
        /// Expects letter input view was already setup.
        /// </summary>
        private void OnEnable()
        {
            AddNextSelectedListeners(inputView);
        }

        private void OnDiable()
        {
            RemoveNextSelectedListeners(inputView);
        }

        private void AddNextSelectedListeners(LetterInputView inputView)
        {
            if (m_OnNextSelected == null)
                m_OnNextSelected = PublishNextPositionSelected;
            inputView.controller.model.onNextSelected -= m_OnNextSelected;
            inputView.controller.model.onNextSelected += m_OnNextSelected;

            if (follower != null)
            {
                follower.Setup();
                m_OnNextPositionSelected -= follower.onNextPosition;
                m_OnNextPositionSelected += follower.onNextPosition;

                inputView.controller.model.onClearSelection -= follower.onClear;
                inputView.controller.model.onClearSelection += follower.onClear;
            }
        }

        private void RemoveNextSelectedListeners(LetterInputView inputView)
        {
            inputView.controller.model.onNextSelected -= m_OnNextSelected;
            if (follower != null)
            {
                m_OnNextPositionSelected -= follower.onNextPosition;
                inputView.controller.model.onClearSelection -= follower.onClear;
            }
        }

        private void PublishNextPositionSelected(int previousNumSelected, int selectedIndex)
        {
            if (m_OnNextPositionSelected == null)
                return;

            Vector3 selectedPosition = inputView.buttons.buttons[selectedIndex].transform.position;
            m_OnNextPositionSelected(previousNumSelected, selectedPosition);
        }
    }
}
