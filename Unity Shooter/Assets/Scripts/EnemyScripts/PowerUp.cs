using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyScripts {
    public class PowerUp : Enemy {
        
        public int powerUpID;
        public GameObject[] spriteList;
        
        public AudioClip powerUpSound;
        public AudioClip powerDownSound;

        private bool _didCollide;
        
        public override GameObject Spawn() {
            GameObject newEnemy = Instantiate(gameObject, new Vector3(Random.Range(-9f, 9f), 9f, 0),Quaternion.identity);
            
            return newEnemy;
        }

        private void Start() {
            _didCollide = false;
            powerUpID = Random.Range(0, spriteList.Length);
            
            Debug.Log("POWER UP:"+powerUpID);
            
            for (int i = 0; i < spriteList.Length; i++) {
                GameObject sprite = spriteList[i];
                sprite.SetActive(i == powerUpID);
            }
        }

        public override void Update() {
            if (!gameObject.activeSelf || _didCollide) {
                return;
            }
            
            transform.Translate(new Vector3(0, -1, 0) * (Time.deltaTime * 3f));
            if (transform.position.y < -8.5f) {
                Destroy(gameObject);
            }
        }

        private IEnumerator BulletPowerUp(Player player,int num) {
            player.IncreaseBulletCount(num);
            
            yield return new WaitForSeconds(5f);
            
            AudioSource.PlayClipAtPoint(powerDownSound, Vector3.zero);
            player.IncreaseBulletCount(-num);
        }
        
        private IEnumerator SpeedPowerUp(Player player,int num) {
            player.speed += num;
            
            yield return new WaitForSeconds(5f);
            
            AudioSource.PlayClipAtPoint(powerDownSound, Vector3.zero);
            player.speed -= num;
        }

        public override void OnTriggerEnter2D(Collider2D other) {
            if (!other.CompareTag("Player")) return;
            if (_didCollide) return;
            
            _didCollide = true;
            foreach (var sprite in spriteList) {
                sprite.SetActive(false);
            }

            AudioSource.PlayClipAtPoint(powerUpSound, Vector3.zero);

            Player player = other.GetComponent<Player>();
            switch (powerUpID) {
                case 0:
                    player.hasShield = true;
                    break;
                case 1:
                    StartCoroutine(BulletPowerUp(player,1));
                    break;
                case 2:
                    StartCoroutine(BulletPowerUp(player,2));
                    break;
                case 3:
                    StartCoroutine(SpeedPowerUp(player,5));
                    break;
            }
            
            Kill(8f);
        }
    }
}
