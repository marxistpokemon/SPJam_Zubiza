using UnityEngine;
using System.Collections;

public class CortinaSegueJogador : MonoBehaviour {
	
	public Transform jogador;
	
	// Use this for initialization
	void Start () {
		jogador = GameObject.Find("Jogador").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(
			jogador.position.x,
			jogador.position.y,
			jogador.position.z + GameManager.instance.raio);
	}
}
