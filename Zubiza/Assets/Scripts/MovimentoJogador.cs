using UnityEngine;
using System.Collections;

public class MovimentoJogador : MonoBehaviour {
	
	public Vector3 input;
	public float velocidade;
	public float velocidadeMaxima;
	
	public float dragChao = 0.5f;
	
	public float poderDoPulo = 10f;
	public bool podePular = false;
	public bool pulando = true;
	public bool disparaPulo = false;
	
	private Rigidbody _rigidbody;
	private GoTweenConfig tweenJogador;
	
	// Use this for initialization
	void Start () {
		_rigidbody = transform.rigidbody;
		Go.defaultLoopType = GoLoopType.PingPong;
		
		tweenJogador = new GoTweenConfig().scale(
			new Vector3(-0.2f, 0, 0), true)
			.setIterations(-1);
		tweenJogador.loopType = GoLoopType.PingPong;
		Go.to (this.transform, 0.5f, tweenJogador);
	}
	
	// Update is called once per frame
	void Update () {
		
		input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		input = Camera.main.transform.TransformDirection(input);
		
		if(Input.GetButtonDown("Jump") && podePular){
			disparaPulo = true;
			pulando = true;
		}
	}
	
	void FixedUpdate(){
		
		if(disparaPulo){
			disparaPulo = false;
			podePular = false;
			rigidbody.AddForce(new Vector3(0, poderDoPulo, 0), ForceMode.VelocityChange);
		}
		
		_rigidbody.AddForce(input*Time.fixedDeltaTime*velocidade, 
			ForceMode.VelocityChange);
		
		if(_rigidbody.velocity.magnitude > velocidadeMaxima)
        {
               _rigidbody.velocity = _rigidbody.velocity.normalized * velocidadeMaxima;
        }
			
	}
	
	void OnCollisionEnter(Collision colisao){
		podePular = true;
		pulando = false;
	}
}
