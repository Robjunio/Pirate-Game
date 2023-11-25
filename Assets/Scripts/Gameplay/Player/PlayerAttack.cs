using System.Collections.Generic;
using Unity.Mathematics;
using Gameplay.Bullets;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private PlayerController _player;
        private Transform[] rightParalelShootPosition; 
        private Transform[] leftParalelShootPosition;

        private Transform singleShootPosition;
        
        private List<Projectiles> objPoolingCannonBalls = new List<Projectiles>();
        private int _lastObjectPicked = 0;

        private void Start()
        {
            TryGetComponent(out _player);
            
            var singleShootObj = transform.GetChild(2);
            
            var rightPositionObj = transform.GetChild(3);
            var leftPositionObj = transform.GetChild(4);

            singleShootPosition = singleShootObj;
            rightParalelShootPosition = new Transform[3]; 
            leftParalelShootPosition = new Transform[3]; 
            
            for (int i = 0; i < rightPositionObj.childCount; i++)
            {
                rightParalelShootPosition[i] = rightPositionObj.GetChild(i);
                leftParalelShootPosition[i] = leftPositionObj.GetChild(i);
            }
        }

        private void SingleShoot()
        {
            var bullet = GetBullet();
            bullet.Direction = _player.GetShipDirection();
            
            bullet.gameObject.transform.position = singleShootPosition.position;

            bullet.gameObject.SetActive(true);
            
            bullet.ResetBullet();
        }

        private void ParallelShoot(Vector2 dir)
        {
            for (int cannon = 0; cannon < rightParalelShootPosition.Length; cannon++)
            {
                var bulletDir = (rightParalelShootPosition[cannon].position -
                                 leftParalelShootPosition[cannon].position).normalized * dir.x;
                
                var bullet = GetBullet();

                bullet.Direction = bulletDir;

                if (dir.x > 0)
                {
                    bullet.gameObject.transform.position = rightParalelShootPosition[cannon].position;

                    bullet.gameObject.SetActive(true);
            
                    bullet.ResetBullet();
                }
                else
                {
                    bullet.gameObject.transform.position = leftParalelShootPosition[cannon].position;

                    bullet.gameObject.SetActive(true);
            
                    bullet.ResetBullet();
                }
            }
        }
        
        private Projectiles GetBullet()
        {
            if (objPoolingCannonBalls.Count == _player.GetObjectPoolingSize())
            {
                Projectiles Bullet = objPoolingCannonBalls[_lastObjectPicked];
                _lastObjectPicked = _lastObjectPicked + 1 >= _player.GetObjectPoolingSize() ? 0 : _lastObjectPicked + 1;
                return Bullet;
            }
            
            return CreateBullet();
        }

        private Projectiles CreateBullet()
        {
            var bullet = Instantiate(_player.GetCannonBallPrefab(), Vector3.zero, quaternion.identity).GetComponent<Projectiles>();
            objPoolingCannonBalls.Add(bullet.GetComponent<Projectiles>());

            bullet.Damage = _player.GetBulletDamage();
            bullet.Speed = _player.GetBulletSpeed();
            bullet.TimeActive = _player.GetBulletDamage();
            
            return bullet;
        }
        
        private void OnEnable()
        {
            PlayerInput.OnSingleShoot += SingleShoot;
            PlayerInput.OnParallelShoot += ParallelShoot;
        }
    
        private void OnDisable()
        {
            PlayerInput.OnSingleShoot -= SingleShoot;
            PlayerInput.OnParallelShoot -= ParallelShoot;
        }
    }
}
