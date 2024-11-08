using UnityEngine;

public class Cloud : MonoBehaviour {
	private void Start() {
        transform.position = new Vector3(Random.Range(-12f, 12f), Random.Range(-8f, 8f), 0);
        float tempValue = Random.Range(0.1f, 1f);
        transform.localScale = new Vector3(tempValue, tempValue, tempValue);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Random.Range(0.1f, 0.6f));
    }
}
