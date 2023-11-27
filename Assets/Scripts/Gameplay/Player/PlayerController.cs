using Gameplay.Managers;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Players Attributes")] 
        [SerializeField] private float maxHealth;
        [SerializeField] private float speed;
        [SerializeField] private float angularSpeed;

        [Header("Cannon Bullets Attributes")] 
        [SerializeField] private GameObject cannonBallPrefab;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float bulletDamage;
        [SerializeField] private float bulletTimeToBeDestroyed;
        [SerializeField] private int objectPoolingSize;
        
        private Transform startOfShip;
        private Transform endOfShip;
        
        private void Start()
        {
            endOfShip = transform.GetChild(0);
            startOfShip = transform.GetChild(1);

            GameController.instance.SetPlayerTransform(transform);
        }

        public float GetMaxHealth()
        {
            return maxHealth;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public float GetAngularSpeed()
        {
            return angularSpeed;
        }

        public float GetBulletSpeed()
        {
            return bulletSpeed;
        }

        public float GetBulletDamage()
        {
            return bulletDamage;
        }
        public float GetBulletTimeToBeDestroyed()
        {
            return bulletTimeToBeDestroyed;
        }

        public int GetObjectPoolingSize()
        {
            return objectPoolingSize;
        }

        public GameObject GetCannonBallPrefab()
        {
            return cannonBallPrefab;
        }
        
        public Vector2 GetShipDirection()
        {
            Vector2 dir = (startOfShip.position - endOfShip.position).normalized;
            return dir;
        }
    }
}