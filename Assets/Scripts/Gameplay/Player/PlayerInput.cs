using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void MoveAction();
    public static event MoveAction OnMoved;
    
    public delegate void RotateAction(Vector2 dir);
    public static event RotateAction OnRotated;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            OnMoved?.Invoke();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            OnRotated?.Invoke(Vector2.left);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            OnRotated?.Invoke(Vector2.right);
        }
    }
}
