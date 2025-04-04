using UnityEngine;

namespace WarsOfShapes
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        public GameObject bulletprefab;
        
        [SerializeField] private float speed;
        [SerializeField] private float stoppingDistance;
        [SerializeField] private float retreatDistance;
        [SerializeField] private  float timeBtwShoot;
        
        private Transform _target;
        private float _timeBtwShootCount;
        private Rigidbody2D _rb;
        
        void Awake()
        {
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            _rb = GetComponent<Rigidbody2D>();
            _timeBtwShootCount = 0;
        }

        void Update()
        {
            if (_timeBtwShootCount > timeBtwShoot) {
                _timeBtwShootCount = 0;
                Shoot();
            } else {
                _timeBtwShootCount += Time.deltaTime;
            }
        }

        void FixedUpdate()
        {
            Vector2 direction = Vector2.zero;
            float distance = Vector2.Distance(transform.position, _target.position);

            if (distance < retreatDistance) {
                direction = (transform.position - _target.position).normalized;
            }
            else if (distance > stoppingDistance) {
                direction = (_target.position - transform.position).normalized;
            }

            _rb.MovePosition(_rb.position + direction * speed * Time.fixedDeltaTime);
        }

        void Shoot() {
            Instantiate(bulletprefab, transform.position, Quaternion.identity);
        }
    }
}
