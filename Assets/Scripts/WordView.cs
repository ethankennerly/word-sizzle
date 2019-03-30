using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FineGameDesign.Utils
{
    [System.Serializable]
    public sealed class WordView
    {
        public List<Collider2D> buttons;
        public List<Animator> states;
        public List<TextMeshPro> texts;
    }
}
