using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private Transform startOfShip;
    private Transform endOfShip;
    
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        TryGetComponent(out _rigidbody2D);
        
        endOfShip = transform.GetChild(0);
        startOfShip = transform.GetChild(1);
    }

    private void MoveForward()
    {
        _rigidbody2D.velocity = GetShipDirection() * speed;
    }

    private Vector2 GetShipDirection()
    {
        Vector2 dir = (startOfShip.position - endOfShip.position).normalized;
        return dir;
    }

    private void Rotate(Vector2 dir)
    {
        _rigidbody2D.AddTorque(rotationSpeed * -dir.x * Time.fixedDeltaTime);
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
