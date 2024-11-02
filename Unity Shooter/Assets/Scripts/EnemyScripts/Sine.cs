using UnityEngine;

namespace EnemyScripts {
	public class Sine : Enemy {

		private float _sineTimer;
		
		public override GameObject Spawn() {
			GameObject newEnemy = base.Spawn();

			newEnemy.transform.position = new Vector3(11.5f, Random.Range(-2f, 2f), 0);
			
			return newEnemy;
		}

		public override void Update() {
			_sineTimer += Time.deltaTime;
			
			transform.Translate(new Vector3(-1, Mathf.Sin(_sineTimer * 2f) * 1.5f, 0) * (Time.deltaTime * 2.5f));
			
			if (transform.position.x < -11f) {
				Destroy(gameObject);
			}
		}
	}
}