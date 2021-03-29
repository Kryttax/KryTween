using UnityEngine;
using System.Collections;

namespace KryTween.Effects
{
    public class TweenMoveAndReturn : ITweenEffect
    {
        private RectTransform RectTransform { get; }
        private Vector2 InitialPosition { get; }
        private Vector2 FinalPosition { get; }
        private float MoveSpeed { get; }
        private YieldInstruction Wait { get; }

        public TweenMoveAndReturn(RectTransform rectTransform, Vector2 finalPosition, float moveSpeed, YieldInstruction wait)
        {
            InitialPosition = rectTransform.anchoredPosition;
            RectTransform = rectTransform;
            FinalPosition = finalPosition;
            MoveSpeed = moveSpeed;
            Wait = wait;
        }

        public IEnumerator Execute()
        {
            Debug.Log("Moving Object!");
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

            yield return Wait;

            Debug.Log("Moving Object Back!");
            //back to initial position
            currentPosition = RectTransform.anchoredPosition;
            time = 0f;

            while (RectTransform.anchoredPosition != InitialPosition)
            {
                time += Time.deltaTime;
                var move = Vector2.Lerp(currentPosition, InitialPosition, time / MoveSpeed);
                RectTransform.anchoredPosition = move;
                yield return null;
            }

            RectTransform.anchoredPosition = InitialPosition;
        }
    }
}
