using UnityEngine;
using System.Collections;

public enum Perspectivas {
	FRENTE = 0,
	DIREITA = 1,
	TRAS = 2,
	ESQUERDA =3
}

public class TrocaPerspectiva : MonoBehaviour {
	
	public int perspAtual = 0;
	public float duracaoRotacao = 0.5f;
	public bool trocou = false;
	public bool trocando = false;
	
	// Use this for initialization
	void Start () {
		perspAtual = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("TrocaMais")){
				perspAtual++;
				trocou = true;
		}
		
		if(Input.GetButtonUp("TrocaMenos")){
				perspAtual--;
				trocou = true;
		}
		
		if(perspAtual < 0) perspAtual = 3;
		if(perspAtual > 3) perspAtual = 0;
		
		if(trocou){
			trocou = false;
			
			switch(perspAtual){
				case (int)Perspectivas.FRENTE :
					Go.to (this.transform, duracaoRotacao, new GoTweenConfig()
					.setEaseType(GoEaseType.BackInOut)
					.rotation(Quaternion.Euler(new Vector3(0,0,0)))
					.onStart(start => trocando = true)
					.onComplete(complete => trocando = false));
					break;
				case (int)Perspectivas.DIREITA :
					Go.to (this.transform, duracaoRotacao, new GoTweenConfig()
					.setEaseType(GoEaseType.BackInOut)
					.rotation(Quaternion.Euler(new Vector3(0,90,0)))
					.onStart(start => trocando = true)
					.onComplete(complete => trocando = false));
					break;
				case (int)Perspectivas.TRAS :
					Go.to (this.transform, duracaoRotacao, new GoTweenConfig()
					.setEaseType(GoEaseType.BackInOut)
					.rotation(Quaternion.Euler(new Vector3(0,180,0)))
					.onStart(start => trocando = true)
					.onComplete(complete => trocando = false));
					break;
				case (int)Perspectivas.ESQUERDA :
					Go.to (this.transform, duracaoRotacao, new GoTweenConfig()
					.setEaseType(GoEaseType.BackInOut)
					.rotation(Quaternion.Euler(new Vector3(0,270,0)))
					.onStart(start => trocando = true)
					.onComplete(complete => trocando = false));
					break;
			}
		}
	}
}
