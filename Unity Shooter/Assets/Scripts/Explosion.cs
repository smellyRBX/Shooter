using System;
using UnityEngine;

public class Explosion : MonoBehaviour {
	private void Start() {
		Destroy(gameObject,3f);
	}
}
