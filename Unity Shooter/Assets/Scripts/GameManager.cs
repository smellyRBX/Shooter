using EnemyScripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject[] enemyList;
	
	public bool gameOver;
	
	public TextMeshProUGUI scoreText;

	public AudioClip music;

	private int _score;
	
	// Start is called before the first frame update
	private void Start() {
		//AudioSource.PlayClipAtPoint(music, player.transform.position);
		
		gameOver = false;
		
		Instantiate(player, transform.position, Quaternion.identity);
		_score = 0;
		AddScore(0);
	}

	private void Restart() {
		if (Input.GetKeyDown(KeyCode.R) && gameOver) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	
	private void Update() {
		CreateEnemy(Time.deltaTime);
		Restart();
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
		scoreText.text = "Score: " + _score;
	}
}