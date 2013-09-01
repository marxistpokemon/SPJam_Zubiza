using UnityEngine;
using System.Collections;

public class DistanciaInvisivel : MonoBehaviour {
	
	public float raioVisivel = 10f;
	
	// Update is called once per frame
	void Update () {
		
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, raioVisivel);
		
		for (var i = 0; i < hitColliders.Length; i++) {
			hitColliders[i].renderer.enabled = true;
		}
	}
}
