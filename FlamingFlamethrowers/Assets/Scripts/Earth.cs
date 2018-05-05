using UnityEngine;
using UnityEngine.UI;

public class Earth : MonoBehaviour {

	public float health = 100f;
	public float alienDamage;
	public GameObject explosion;
	public Slider earthHealthBar;
	void Awake()
	{
		health = 100f;
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy") {
			health -= alienDamage;
			earthHealthBar.value = health;
			GameManager.currentEnemyCount--;
			Destroy(other.gameObject);
			GameObject expl = Instantiate(explosion, other.transform.position, Quaternion.identity) as GameObject;
			Destroy(expl, 1);
			
			if(health <= 0) {
				GameManager.gameOver = true;
				this.gameObject.SetActive(false);
				GameObject explos = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
				Destroy(explos, 1);
			}
		}
	}
}
