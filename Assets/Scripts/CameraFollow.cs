using UnityEngine;

namespace WarsOfShapes
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);
        [SerializeField] private float smoothSpeed = 0.125f;

        private Transform _target;

        public void Init(Transform transform)
        {   
            _target = transform;
        }

        private void LateUpdate()
        {
            Vector3 desiredPosition = _target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;
        }
    }
}
