using UnityEngine;

public class Player : MonoBehaviour {
	// its access level: public or private
	// its type: int (5, 8, 36, etc.), float (2.5f, 3.7f, etc.)
	// its name: speed, playerSpeed --- Speed, PlayerSpeed
	// optional: give it an initial value
	private float _speed;
	public int lives = 3;
	public int score;
	private float _horizontalInput;
	private float _verticalInput;

	public GameObject bullet;

	// Start is called before the first frame update
	private void Start() {
		_speed = 5f;
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
		setPosition.y = Mathf.Clamp(setPosition.y, -4.5f, 0);

		transform.position = setPosition;
		
		if (transform.position.x > 11.5f || transform.position.x <= -11.5f) {
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
			Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
		}
	}
}