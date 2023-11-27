using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerController _player;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            TryGetComponent(out _rigidbody2D);
            TryGetComponent(out _player);
        }

        private void MoveForward()
        {
            _rigidbody2D.velocity = _player.GetShipDirection() * _player.GetSpeed();
        }
        
        private void Rotate(Vector2 dir)
        {
            _rigidbody2D.AddTorque(_player.GetAngularSpeed() * -dir.x * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        private void OnEnable()
        {
            PlayerInput.OnMoved += MoveForward;
            PlayerInput.OnRotated += Rotate;
        }

        private void OnDisable()
        {
            PlayerInput.OnMoved -= MoveForward;
            PlayerInput.OnRotated -= Rotate;
        }
    }
}
