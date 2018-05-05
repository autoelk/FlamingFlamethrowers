using UnityEngine;

public class Fire : MonoBehaviour {

	public CircleCollider2D fireCollider;
	public GameObject explosion;
	public Vector2 offset;
	public Vector2 offset2;
	public Animator animator;

	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)) {
			fireCollider.offset = offset2;
			fireCollider.radius = 2.5f;
			animator.SetBool("MousePressed", true);
		}
		if(Input.GetMouseButtonUp(0)) {
			fireCollider.offset = offset;
			fireCollider.radius = 5f;
			animator.SetBool("MousePressed", false);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Enemy") {
			GameManager.currentEnemyCount = GameManager.currentEnemyCount - 1;
			Destroy(other.gameObject);
			GameObject expl = Instantiate(explosion, other.transform.position, Quaternion.identity) as GameObject;
			Destroy(expl, 1);
		}
	}
}
