using UnityEngine;

namespace WarsOfShapes
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 4;
        [SerializeField] private int _damage = 2;

        private Vector3 _target;

        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        }

        private void Update()
        {
            if (_target == this.transform.position) {
                DestroyGameObject();
            } else {
                this.transform.position = Vector3.MoveTowards(this.transform.position, _target, _speed * Time.deltaTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }

        private void DestroyGameObject() {
            Destroy(this.gameObject);
        }
    }
}
