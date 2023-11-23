using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        TryGetComponent(out _rigidbody2D);
    }

    private void MoveForward()
    {
        _rigidbody2D.velocity = Vector2.up * speed;
    }

    private void Rotate(Vector2 dir)
    {
        print(dir);
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
