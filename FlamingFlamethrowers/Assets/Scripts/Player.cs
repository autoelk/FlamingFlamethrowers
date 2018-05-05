using UnityEngine;

public class Player : MonoBehaviour {

	public float movementSpeed = 1f;
	public float speedMultiplier = 2f;
	public GameObject explosion;

	void Update () {
		//Rotate to face mouse
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward); 
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * movementSpeed);

		if(Input.GetMouseButtonDown(0)) {
			movementSpeed *= speedMultiplier;
		}
		if(Input.GetMouseButtonUp(0)) {
			movementSpeed /= speedMultiplier;
		}
		//Constantly Move Forward
		transform.position += transform.right * Time.deltaTime * movementSpeed;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy") {
			GameManager.currentEnemyCount--;
			Destroy(other.gameObject);
			GameObject expl = Instantiate(explosion, other.transform.position, Quaternion.identity) as GameObject;
			GameObject explos = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			Destroy(expl, 1);
			Destroy(explos, 1);
			GameManager.gameOver = true;
			gameObject.SetActive(false);
		}
	}
}
