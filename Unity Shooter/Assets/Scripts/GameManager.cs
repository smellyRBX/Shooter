using EnemyScripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject[] enemyList;
	
	public bool gameOver;
	
	public TextMeshProUGUI scoreText;
	public GameObject gameOverText;
	public GameObject restartText;
	public TextMeshProUGUI livesText;

	public AudioClip music;

	private int _score;
	private Player _playerData;
	
	// Start is called before the first frame update
	private void Start() {
		AudioSource.PlayClipAtPoint(music, Vector3.zero);
		gameOverText.SetActive(false);
		restartText.SetActive(false);
		
		gameOver = false;
		
		GameObject playerObj = Instantiate(player, Vector3.zero, Quaternion.identity);
		_playerData = playerObj.GetComponent<Player>();
		_playerData.lives = 3;
		
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
		livesText.text = "Lives: " + _playerData.lives;
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