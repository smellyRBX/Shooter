using UnityEngine;

namespace EnemyScripts {
	public class Side : Enemy {
		
		public override GameObject Spawn() {
			GameObject newEnemy = base.Spawn();

			newEnemy.transform.position = new Vector3(-11.5f, Random.Range(0f, 8.5f), 0);
			
			return newEnemy;
		}

		public override void Update() {
			transform.Translate(new Vector3(1, 0, 0) * (Time.deltaTime * 2.5f));
			
			if (transform.position.x > 11f) {
				Destroy(gameObject);
			}
		}
	}
}