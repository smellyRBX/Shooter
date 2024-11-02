using UnityEngine;

public class Enemy : MonoBehaviour {

	// Update is called once per frame
	private void Update() {
		transform.Translate(new Vector3(0, -1, 0) * (Time.deltaTime * 3f));
		if (transform.position.y < -8.5f) {
			Destroy(gameObject);
		}
	}
}