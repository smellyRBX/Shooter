using UnityEngine;

namespace EnemyScripts {
	public class Cloud : Enemy {
		
		public override GameObject Spawn() {
			GameObject newEnemy = Instantiate(gameObject, new Vector3(Random.Range(-9f, 9f), 9f, 5),Quaternion.identity);
			
			float tempValue = Random.Range(2f, 7f);
			transform.localScale = new Vector3(tempValue, tempValue, tempValue);

			spriteRenderer.color = new Color(1, 1, 1, Random.Range(0.1f, 0.6f));
			
			return newEnemy;
		}
		
		public override void Update() {
			transform.Translate(new Vector3(0, -1, 0) * (Time.deltaTime * 3f));
			if (transform.position.y < -8.5f) {
				Destroy(gameObject);
			}
		}

		public override void OnTriggerEnter2D(Collider2D other) {
			// do nothing
		}
	}
}