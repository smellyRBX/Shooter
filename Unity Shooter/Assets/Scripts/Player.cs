using TMPro;
using UnityEngine;

public class Player : Entity {
	public float speed;
	
	private float _horizontalInput;
	private float _verticalInput;

	private const float HorizontalScreenSize = 10f;
	private const float VerticalScreenSize = 3.5f;

	public GameObject shieldObj;
	public GameObject bullet;
	public int bulletCount = 1;
	private const float BulletDegree = 45f;

	public AudioClip shootSound;
	
	public GameManager gameManager;
	public bool hasShield = false;

	// Start is called before the first frame update
	private void Start() {
		speed = 5f;
		lives = 3;
		bulletCount = 1;
	}

	// Update is called once per frame
	private void Update() {
		shieldObj.SetActive(hasShield);
		Movement();
		Shooting();
	}

	private void Movement() {
		_horizontalInput = Input.GetAxis("Horizontal");
		_verticalInput = Input.GetAxis("Vertical");

		Vector3 translate = new Vector3(_horizontalInput, _verticalInput, 0) * (Time.deltaTime * speed);
		Vector3 setPosition = transform.position + translate;
		
		// limit to bottom half of the screen
		setPosition.y = Mathf.Clamp(setPosition.y, -VerticalScreenSize, 0);

		transform.position = setPosition;
		
		if (transform.position.x > HorizontalScreenSize || transform.position.x <= -HorizontalScreenSize) {
			transform.position = new Vector3(transform.position.x * -1,
				transform.position.y, 0);
		}
		
		/*if (transform.position.y > 8.5f || transform.position.y <= -8.5f) {
			transform.position = new Vector3(transform.position.x,
				transform.position.y * -1, 0);
		}*/
	}

	public void IncreaseBulletCount(int count) {
		bulletCount += count;
	}
	
	private void Shooting() {
		//SPACE - Create a bullet
		if (!Input.GetKeyDown(KeyCode.Space)) return;
		
		AudioSource.PlayClipAtPoint(shootSound, transform.position);
		
		float startDeg = (-BulletDegree * 0.5f);
		float addDeg = BulletDegree / (bulletCount - 1f);
		
		if (bulletCount == 1) {
			startDeg = 0;
			addDeg = 0;
		}
		
		for (int i = 0; i < bulletCount; i++) {
			float setDeg = startDeg + (i * addDeg);
			Instantiate(bullet, transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0f,0f,setDeg));
		}
	}

	public override bool TakeDamage(int damage) {
		if (hasShield) {
			hasShield = false;
			damage = 0;
		}

		return base.TakeDamage(damage);
	}

	protected override void Kill(float delay = 0) {
		base.Kill(delay);
		
		gameManager.EndGame();
	}
}