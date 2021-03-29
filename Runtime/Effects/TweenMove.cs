using UnityEngine;
using System.Collections;

namespace KryTween.Effects
{
    public class TweenMove : ITweenEffect
    {
        private RectTransform RectTransform { get; }
        private Vector2 FinalPosition { get; }
        private float MoveSpeed { get; }

        public TweenMove(RectTransform rectTransform, Vector2 finalPosition, float moveSpeed)
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
                time += Time.deltaTime;
                var move = Vector2.Lerp(currentPosition, FinalPosition, time / MoveSpeed);
                RectTransform.anchoredPosition = move;
                yield return null;
            }

            RectTransform.anchoredPosition = FinalPosition;
        }
    }
}
