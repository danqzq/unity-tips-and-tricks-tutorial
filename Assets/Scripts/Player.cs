using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Dan
{
    [SuppressMessage("ReSharper", "Unity.ExplicitTagComparison")]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 1000f;
        
        private Rigidbody2D _rb;
        private Transform _spriteTransform;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteTransform = transform.GetChild(0);
        }

        private void Update()
        {
            var horizontalAxis = Input.GetAxis("Horizontal");
            
            if (horizontalAxis > 0)
                _spriteTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            else if (horizontalAxis < 0)
                _spriteTransform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            
            _rb.velocity = new Vector2(horizontalAxis * _speed * Time.deltaTime, _rb.velocity.y);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<ITriggerable>(out var triggerable))
                triggerable.OnTriggered();
        }
    }
}
