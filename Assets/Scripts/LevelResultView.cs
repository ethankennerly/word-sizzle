using UnityEngine;
using FineGameDesign.Utils;

namespace FineGameDesign.WordSizzle
{
    public sealed class LevelResultView : MonoBehaviour
    {
        public GameObject animatorOwner;
        public GameObject tutor;
        public GameObject nextButton;
        public string nextButtonPath = "LevelResultContainer/Panel/NextButton";
        public string tutorPath = "LevelResultContainer/Tutor";
        public LevelResultController controller;

        public void Setup()
        {
            if (animatorOwner == null)
            {
                animatorOwner = gameObject;
            }
            nextButton = SceneNodeView.GetChild(gameObject, nextButtonPath, nextButton);
            tutor = SceneNodeView.GetChild(gameObject, tutorPath, tutor);
            controller.view = this;
            controller.Setup();
        }
    }
}
