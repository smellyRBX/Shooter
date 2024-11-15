using TMPro;
using UnityEngine;

public class Player : Entity {
	private float _speed;
	
	private float _horizontalInput;
	private float _verticalInput;

	private const float HorizontalScreenSize = 10f;
	private const float VerticalScreenSize = 3.5f;

	public GameObject bullet;

	public AudioClip powerUpSound;
	public AudioClip powerDownSound;
	public AudioClip shootSound;

	// Start is called before the first frame update
	private void Start() {
		_speed = 5f;
		lives = 3;
	}

	// Update is called once per frame
	private void Update() {
		Movement();
		Shooting();
	}

	private void Movement() {
		_horizontalInput = Input.GetAxis("Horizontal");
		_verticalInput = Input.GetAxis("Vertical");

		Vector3 translate = new Vector3(_horizontalInput, _verticalInput, 0) * (Time.deltaTime * _speed);
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

	private void Shooting() {
		//SPACE - Create a bullet
		if (Input.GetKeyDown(KeyCode.Space)) {
			AudioSource.PlayClipAtPoint(shootSound, transform.position);
			Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
		}
	}

	protected override void Kill() {
		base.Kill();
		
		GameObject gameManager = GameObject.Find("GameManager");
		GameManager gm = gameManager.GetComponent<GameManager>();
		gm.EndGame();
	}
}