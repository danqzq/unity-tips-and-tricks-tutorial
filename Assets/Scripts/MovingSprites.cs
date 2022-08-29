using System.Collections;
using System.Linq;
using UnityEngine;

namespace Dan
{
    public class MovingSprites : MonoBehaviour
    {
        [SerializeField] private Transform[] _spriteTransforms;
        [SerializeField] private float _targetXPosition = 7f;
        [SerializeField] private float _duration = 2f;

        private void Start()
        {
            StartCoroutine(MoveAllSprites());
        }
        
        private IEnumerator MoveAllSprites()
        {
            return _spriteTransforms.Select(MoveSprite).GetEnumerator();
        }

        private IEnumerator MoveSprite(Transform sprite)
        {
            var time = 0f;
            var initialPosition = sprite.position;
            var targetPosition = new Vector3(_targetXPosition, initialPosition.y, initialPosition.z);

            while (time < _duration)
            {
                sprite.position = Vector3.Lerp(initialPosition, targetPosition, time / _duration);
                yield return new WaitForEndOfFrame();
                time += Time.deltaTime;
            }
        }
    }
}