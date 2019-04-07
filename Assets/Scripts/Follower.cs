using System;
using UnityEngine;

namespace FineGameDesign.Utils
{
    public sealed class Follower : MonoBehaviour
    {
        public Transform followerRoot;
        public TrailRenderer trail;
        public Action<int, Vector3> onNextPosition;

        private void OnEnable()
        {
            Setup();
        }

        public void Setup()
        {
            onNextPosition = NextPosition;
        }

        private void NextPosition(int positionIndex, Vector3 position)
        {
            followerRoot.position = position;

            if (positionIndex <= 0)
                if (trail != null)
                    trail.Clear();
        }
    }
}
