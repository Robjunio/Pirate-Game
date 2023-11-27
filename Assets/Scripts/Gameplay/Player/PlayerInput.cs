using System;
using Gameplay.Managers;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private bool _playerActive = true;
        
        public delegate void MoveAction();
        public static event MoveAction OnMoved;
    
        public delegate void RotateAction(Vector2 dir);
        public static event RotateAction OnRotated;

        public delegate void SingleFireAction();
        public static event SingleFireAction OnSingleShoot;
    
        public delegate void ParallelFireAction(Vector2 dir);
        public static event ParallelFireAction OnParallelShoot;

        // Update is called once per frame
        void FixedUpdate()
        {
            if(!_playerActive) return;
            
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

        private void Update()
        {
            if(!_playerActive) return;
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnSingleShoot?.Invoke();
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                OnParallelShoot?.Invoke(Vector2.right);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                OnParallelShoot?.Invoke(Vector2.left);
            }
        }
        
        private void Stop()
        {
            _playerActive = false;
        }
        
        private void OnEnable()
        {
            GameController.EndGame += Stop;
        }
    
        private void OnDisable()
        {
            GameController.EndGame -= Stop;
        }
        
    }
}
