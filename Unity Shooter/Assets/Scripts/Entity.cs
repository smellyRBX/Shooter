using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public int lives = 3;

    public GameObject explosionPrefab;

    public virtual void TakeDamage(int damage) {
        lives -= damage;
        if (lives <= 0) {
            Kill();
        }
    }

    protected virtual void Kill() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
