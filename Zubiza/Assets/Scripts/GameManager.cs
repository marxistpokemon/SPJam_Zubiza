using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;
	
	public float raio;
	
	void Awake(){
		instance = this;
	}
}
