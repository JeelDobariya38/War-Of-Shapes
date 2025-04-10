using UnityEngine;

namespace WarsOfShapes.Scriptables
{    
    [CreateAssetMenu(fileName = "Game", menuName = "Game", order = 0)]
    public class Game : ScriptableObject
    {
        public Player PlayerPrefab;
        public GameObject EnemyPrefab;

        public Vector2 MinArea;
        public Vector2 MaxArea;

        public int PlayerHealth;
        public int PlayerSpeed;
        
        public int NoOfEnemy;
        public int EnemySpeed;
        public int EnemyStoppingDistance;
        public int EnemyRetreatDistance;
        public int EnemyShootingRange;
        public int EnemyTimeBtwShoot;
    }
}
