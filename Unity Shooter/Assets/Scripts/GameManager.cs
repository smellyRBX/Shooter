using EnemyScripts;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject[] enemyList;

	private int _score;
	
	// Start is called before the first frame update
	private void Start() {
		Instantiate(player, transform.position, Quaternion.identity);
	}
	
	private void Update() {
		CreateEnemy(Time.deltaTime);
	}

	private void CreateEnemy(float deltaTime) {
		foreach (GameObject enemyObj in enemyList) {
			Enemy enemyData = enemyObj.GetComponent<Enemy>();
			enemyData.spawnTimer -= deltaTime;
			
			if (enemyData.spawnTimer <= 0) {
				enemyData.spawnTimer = enemyData.spawnRate;
				enemyData.Spawn();
			}
		}
	}

	public void AddScore(int add) {
		_score += add;
	}
}