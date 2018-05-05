using UnityEngine;

public class Alien : MonoBehaviour {
    public float movementSpeed = 2f;
    public float health;
    private float minDistance = 1f;
    private float range;

    void Update() {
        range = Vector2.Distance(transform.position, new Vector2(0, 0));
 
        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), movementSpeed * Time.deltaTime);
        }
    }
}
