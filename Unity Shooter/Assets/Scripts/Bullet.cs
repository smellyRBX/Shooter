using UnityEngine;

public class Bullet : MonoBehaviour {
	// Start is called before the first frame update

	// Update is called once per frame
	private void Update() {
		transform.Translate(new Vector3(0, 1, 0) * (Time.deltaTime * 8));
		if (transform.position.y > 8f) {
			Destroy(gameObject);
		}
	}
}