using System;
using UnityEngine;

namespace Gameplay.Managers
{
    public class GameController : MonoBehaviour
    {
        public delegate void End();
        public static event End EndGame;
        
        private float spawnTime = 4f;
        private float gameTime = 90f;

        private float _minumumGameTime = 60f;
        private float _maximumGameTime = 180f;
        
        public static GameController instance;
        private Transform _playerTransform;

        private void Awake()
        {
            if (FindObjectsOfType<GameController>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        public void SetGameRules(float spawnTime, float gameTime)
        {
            if (gameTime > _maximumGameTime)
            {
                this.gameTime = _maximumGameTime;
            } 
            else if (gameTime < _minumumGameTime)
            {
                this.gameTime= _maximumGameTime;
            }
            else
            {
                this.gameTime = gameTime;
            }

            this.spawnTime = spawnTime;
        }

        public void SetPlayerTransform(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public Transform GetPlayerTransform()
        {
            return _playerTransform;
        }

        public float GetSpawnTime()
        {
            return spawnTime;
        }

        public float GetGameTime()
        {
            return gameTime;
        }

        public void OnEndGame()
        {
            EndGame?.Invoke();
        }
    }
}