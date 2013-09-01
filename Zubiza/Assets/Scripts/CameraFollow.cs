using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public float offsetZ;
	public float damping = 1f;
	public Transform alvo;
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(
			transform.position, 
			new Vector3(
				alvo.position.x,
				alvo.position.y,
				alvo.position.z + offsetZ),
			Time.deltaTime*damping);
	}
}
