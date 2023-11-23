using System.Collections;
using UnityEngine;

namespace utils
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float animationVelocity;
        private Camera _camera;
    
        void Start()
        {
            TryGetComponent(out _camera);
        }

        public void StartZoomIn()
        {
            StartCoroutine(ZoomIn());
        }

        private IEnumerator ZoomIn()
        {
            while (_camera.orthographicSize > 5)
            {
                _camera.orthographicSize -= animationVelocity;
                yield return null;
            }

            _camera.orthographicSize = 5;
        }
    }
}
