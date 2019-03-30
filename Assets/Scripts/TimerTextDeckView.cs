using UnityEngine;
using UnityEngine.UI;

namespace FineGameDesign.Utils
{
    [RequireComponent(typeof(Text))]
    public sealed class TimerTextDeckView : MonoBehaviour
    {
        public TimerTextDeck model;
        public Text text;

        public static TimerTextDeckView[] Binds(TimerTextDeck model, TimerTextDeckView[] views)
        {
            if (views == null || views.Length == 0)
            {
                views = FindObjectsOfType<TimerTextDeckView>();
            }
            for (int index = 0, end = views.Length; index < end; ++index)
            {
                views[index].model = model;
            }
            return views;
        }

        private void Start()
        {
            text = GetComponent<Text>();
        }

        private void Update()
        {
            text.text = model.Selected;
        }
    }
}
