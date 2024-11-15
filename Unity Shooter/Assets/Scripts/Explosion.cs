using System;
using UnityEngine;

public class Explosion : MonoBehaviour {
	public AudioClip explodeSound;

	private void Start() {
		if (explodeSound != null) {
			AudioSource.PlayClipAtPoint(explodeSound, transform.position);
		}
		
		Destroy(gameObject,3f);
	}
}
