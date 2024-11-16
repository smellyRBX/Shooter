using System;
using EnemyScripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject[] enemyList;
	
	public bool gameOver;
	
	public TextMeshProUGUI scoreText;
	public GameObject gameOverText;
	public GameObject restartText;
	public TextMeshProUGUI livesText;

	private int _score;
	private Player _playerData;
	
	private float _timer;
	
	// Start is called before the first frame update
	private void Start() {
		gameOverText.SetActive(false);
		restartText.SetActive(false);
		
		gameOver = false;
		
		GameObject playerObj = Instantiate(player, Vector3.zero, Quaternion.identity);
		_playerData = playerObj.GetComponent<Player>();
		_playerData.lives = 3;
		_playerData.gameManager = this;
		
		_score = 0;
		AddScore(0);
	}

	public void EndGame() {
		gameOver = true;
		gameOverText.SetActive(true);
		restartText.SetActive(true);
	}

	private void Restart() {
		if (Input.GetKeyDown(KeyCode.R) && gameOver) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	
	private void Update() {
		_timer += Time.deltaTime;
		
		livesText.text = "Lives: " + _playerData.lives;
		CreateEnemy(Time.deltaTime);
		Restart();
	}

	private void CreateEnemy(float deltaTime) {
		foreach (GameObject enemyObj in enemyList) {
			if (gameOver && enemyObj.name != "Cloud") {
				continue;
			}
			
			Enemy enemyData = enemyObj.GetComponent<Enemy>();
			enemyData.spawnTimer -= deltaTime;
			
			if (enemyData.spawnTimer <= 0) {
				print(_timer/100f);

				float addTimer = (enemyData.spawnRate + Random.Range(-2f, 2f)) - (_timer / 100f);
				if (enemyData.constantSpawn) {
					addTimer = enemyData.spawnRate;
				}

				addTimer = Math.Max(addTimer, 0.1f);
				
				enemyData.spawnTimer = addTimer;
				enemyData.Spawn();
			}
		}
	}

	public void AddScore(int add) {
		_score += add;
		scoreText.text = "Score: " + _score;
	}
}