using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject player;
	public Enemy[] enemyList;

	// Start is called before the first frame update
	private void Start() {
		Instantiate(player, transform.position, Quaternion.identity);
		InvokeRepeating(nameof(CreateEnemy), 1f, 3f);
	}
	
	private void Update() {
		CreateEnemy(Time.deltaTime);
	}

	private void CreateEnemy(float deltaTime) {
		foreach (Enemy enemyData in enemyList) {
			enemyData.spawnTimer -= deltaTime;
			
			if (enemyData.spawnTimer <= 0) {
				enemyData.spawnTimer = enemyData.spawnRate;
				enemyData.Spawn();
			}
		}
	}
}