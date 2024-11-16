using UnityEngine;

namespace EnemyScripts {
	public class Side : Enemy {

		public bool dir;
		
		public override GameObject Spawn() {
			GameObject newEnemy = base.Spawn();
			bool sideDir = Random.Range(0, 2) == 0;

			newEnemy.GetComponent<Side>().dir = sideDir;
			newEnemy.transform.position = new Vector3(-11.5f * (sideDir ? 1 : -1), Random.Range(-4f, 5.5f), 0);
			
			return newEnemy;
		}

		public override void Update() {
			transform.Translate(new Vector3((dir ? 1 : -1), 0, 0) * (Time.deltaTime * 2.5f));
			
			if (transform.position.x > 11f * (dir ? 1 : -1)) {
				Destroy(gameObject);
			}
		}
	}
}