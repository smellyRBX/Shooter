using UnityEngine;

public class Enemy : MonoBehaviour {
	public float spawnRate;
	public float spawnTimer;
	
	public GameObject Spawn() {
		GameObject newEnemy = Instantiate(gameObject, new Vector3(Random.Range(-9f, 9f), 9f, 0),Quaternion.identity);

		return newEnemy;
	}
	
	// Update is called once per frame
	private void Update() {
		transform.Translate(new Vector3(0, -1, 0) * (Time.deltaTime * 3f));
		if (transform.position.y < -8.5f) {
			Destroy(gameObject);
		}
	}
}