using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyScripts {
    public class Coin : Enemy {
        
        public override GameObject Spawn() {
            GameObject newEnemy = Instantiate(gameObject, new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 0f), 0),Quaternion.identity);
            
            return newEnemy;
        }

        private void Start() {
            Destroy(gameObject,5f);
        }

        public override void Update() {
            // do nothing
        }

        public override void OnTriggerEnter2D(Collider2D other) {
            if (!other.CompareTag("Player")) return;
            
            GameObject gameManager = GameObject.Find("GameManager");
            GameManager gm = gameManager.GetComponent<GameManager>();
            gm.AddScore(1);
            Kill();
        }
    }
}
