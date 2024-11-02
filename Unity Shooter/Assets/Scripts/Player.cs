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
		transform.Translate(new Vector3(_horizontalInput, _verticalInput, 0) * (Time.deltaTime * _speed));
		// if (condition) { //do this }
		// else if (other condition { //do that }
		// else { //do this final }
		if (transform.position.x > 11.5f || transform.position.x <= -11.5f) {
			transform.position = new Vector3(transform.position.x * -1,
				transform.position.y, 0);
		}

		if (transform.position.y > 8.5f || transform.position.y <= -8.5f) {
			transform.position = new Vector3(transform.position.x,
				transform.position.y * -1, 0);
		}
	}

	private void Shooting() {
		//if I press SPACE
		//Create a bullet
		if (Input.GetKeyDown(KeyCode.Space)) {
			//Create a bullet
			Instantiate(bullet, transform.position + new Vector3(0, 1, 0),
				Quaternion.identity);
		}
	}
}