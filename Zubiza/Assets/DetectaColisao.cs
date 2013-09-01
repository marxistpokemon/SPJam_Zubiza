using UnityEngine;
using System.Collections;

public class DetectaColisao : MonoBehaviour {
	
	public Material novoMaterial;
	
	void OnCollisionEnter(){
		renderer.material = novoMaterial;
	}
}
