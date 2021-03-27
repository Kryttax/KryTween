using UnityEngine;
using System.Collections;

namespace KryTween.Scripts.Effects
{
    public class MoveRectEffect : IUIEffect
    {
        private RectTransform RectTransform { get; }
        private Vector2 FinalPosition { get; }
        private float MoveSpeed { get; }

        public MoveRectEffect(RectTransform rectTransform, Vector2 finalPosition, float moveSpeed)
        {
            RectTransform = rectTransform;
            FinalPosition = finalPosition;
            MoveSpeed = moveSpeed;
        }

        public IEnumerator Execute()
        {
            //move
            var time = 0f;
            var currentPosition = RectTransform.anchoredPosition;

            while (RectTransform.anchoredPosition != FinalPosition)
            {
                time += Time.deltaTime * MoveSpeed;
                var move = Vector2.Lerp(currentPosition, FinalPosition, time);
                RectTransform.anchoredPosition = move;
                yield return null;
            }

            RectTransform.anchoredPosition = FinalPosition;
        }
    }
}
