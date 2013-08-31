using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public float damping = 1f;
	public Transform alvo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(
			transform.position, 
			new Vector3(
				alvo.position.x,
				alvo.position.y,
				transform.position.z
			),
			Time.deltaTime*damping);
	}
}
