using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyScripts {
	public class Enemy : Entity {
		public float spawnRate;
		[HideInInspector] public float spawnTimer;
	
		public SpriteRenderer spriteRenderer;
		public bool constantSpawn;
	
		public virtual GameObject Spawn() {
			GameObject newEnemy = Instantiate(gameObject, new Vector3(Random.Range(-9f, 9f), 9f, 0),Quaternion.identity);

			return newEnemy;
		}

		public virtual void Update() {
			transform.Translate(new Vector3(0, -1, 0) * (Time.deltaTime * 3f));
			if (transform.position.y < -8.5f) {
				Destroy(gameObject);
			}
		}

		public virtual void OnTriggerEnter2D(Collider2D other) {
			if (other.CompareTag("Player")) {
				Player playerObj = other.GetComponent<Player>();
				playerObj.TakeDamage(1);
				Kill();
			}else if (other.CompareTag("Bullet")) {
				Destroy(other.gameObject);

				if (!TakeDamage(1)) return;
				
				GameObject gameManager = GameObject.Find("GameManager");
				GameManager gm = gameManager.GetComponent<GameManager>();
				gm.AddScore(5);
			}
		}
	}
}