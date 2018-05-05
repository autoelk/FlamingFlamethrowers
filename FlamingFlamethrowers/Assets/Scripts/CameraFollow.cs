using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void LateUpdate()
	{
		if(GameManager.gameOver != true) {
			Vector3 desiredPosition = target.transform.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;
		}
		else {
			Vector3 desiredPosition = new Vector3(0, 0, 0) + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;
		}
	}
}
