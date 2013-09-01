using UnityEngine;
using System.Collections;

public class TeleportaJogador : MonoBehaviour {
	
	public float offsetZ = 0.5f;
	public Transform sensor;
	public bool trocando = false;
	public Ray ray;
	public RaycastHit colisao;
	
	public float raioTeleporte = 10f;
	private Transform meuTransform;
	private Vector3 sensorPosRelCamera;
	private TrocaPerspectiva controleTroca;
	public Material novoMaterial;
	
	// Use this for initialization
	void Start () {
		sensor = GameObject.Find("SensorTeleporte").transform;
		meuTransform = transform;
		controleTroca = GameObject.Find("Mundo").GetComponent<TrocaPerspectiva>();
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.rotation = Quaternion.identity;
		
		//ray = Camera.main.ScreenPointToRay(sensor.position);
		
		sensorPosRelCamera = new Vector3(
			sensor.position.x,
			sensor.position.y,
			Camera.main.transform.position.z);
		
		ray = new Ray(sensorPosRelCamera, Camera.main.transform.forward);
		
		if(Physics.Raycast(ray, out colisao, Vector3.Distance(Camera.main.transform.position, 
			transform.position)+GameManager.instance.raio) &&
			!GetComponent<CharacterMotor>().IsGrounded() &&
			!controleTroca.trocando){
			Debug.Log ("colidiu");
			colisao.transform.renderer.material = novoMaterial;
			Vector3 novaPosicao = new Vector3(
				colisao.point.x,
				meuTransform.position.y,
				colisao.transform.position.z);
			meuTransform.position = novaPosicao;
		}
	
	}
	
	void OnDrawGizmos () {
		Gizmos.DrawLine(sensorPosRelCamera, new Vector3(
			sensorPosRelCamera.x,
			sensorPosRelCamera.y,
			sensorPosRelCamera.z));
		Gizmos.DrawWireSphere(sensor.position, raioTeleporte);
	}

}
