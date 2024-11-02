using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject enemy;

// Start is called before the first frame update
	private void Start() {
		Instantiate(player, transform.position, Quaternion.identity);
		InvokeRepeating(nameof(CreateEnemy), 1f, 3f);
	}


	private void CreateEnemy() {
		Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 9f, 0),
			Quaternion.identity);
	}
}