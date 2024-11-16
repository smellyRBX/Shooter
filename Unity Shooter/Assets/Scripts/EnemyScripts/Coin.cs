using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyScripts {
    public class Coin : Enemy {
        public GameObject otherExp;
        public GameObject reversedExp;
        private bool _isShown = false;

        public GameObject sprite;
        
        public override GameObject Spawn() {
            GameObject newEnemy = Instantiate(gameObject, new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 0f), 0),Quaternion.identity);
            
            return newEnemy;
        }

        private void Start() {
            sprite.SetActive(false);
            StartCoroutine(DestroyCoin());
            StartCoroutine(ShowCoin());
        }

        private IEnumerator ShowCoin() {
            GameObject newExp = Instantiate(reversedExp, transform.position, Quaternion.identity);
            Destroy(newExp,0.2f);
            yield return new WaitForSeconds(0.2f);
            _isShown = true;
            sprite.SetActive(true);
        }
        
        private IEnumerator DestroyCoin() {
            yield return new WaitForSeconds(5f);
            explosionPrefab = otherExp;
            Kill();
        }


        public override void Update() {
            // do nothing
        }

        public override void OnTriggerEnter2D(Collider2D other) {
            if (!_isShown) return;
            if (!other.CompareTag("Player")) return;
            
            GameObject gameManager = GameObject.Find("GameManager");
            GameManager gm = gameManager.GetComponent<GameManager>();
            gm.AddScore(1);
            Kill();
        }
    }
}
