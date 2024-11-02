using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {
	public float spawnRate;
	[HideInInspector] public float spawnTimer;
	
	[SerializeField] private SpriteRenderer spriteRenderer;
	private Camera _myCamera;
	
	public virtual GameObject Spawn() {
		GameObject newEnemy = Instantiate(gameObject, new Vector3(Random.Range(-9f, 9f), 9f, 0),Quaternion.identity);

		return newEnemy;
	}

	private void Start() {
		_myCamera = Camera.main;
	}

	private void LateUpdate(){
		//spriteRenderer.transform.LookAt(_myCamera.transform.position);
	}
	
	// Update is called once per frame
	public virtual void Update() {
		transform.Translate(new Vector3(0, -1, 0) * (Time.deltaTime * 3f));
		if (transform.position.y < -8.5f) {
			Destroy(gameObject);
		}
	}
}