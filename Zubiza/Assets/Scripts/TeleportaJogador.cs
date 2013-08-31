using UnityEngine;
using System.Collections;

public class TeleportaJogador : MonoBehaviour {
	
	public float offsetZ = 0.5f;
	public Transform sensor;
	public bool trocando = false;
	public Ray ray;
	public RaycastHit colisao;
	
	private Transform meuTransform;
	private Vector3 sensorPosRelCamera;
	
	// Use this for initialization
	void Start () {
		sensor = GameObject.Find("SensorTeleporte").transform;
		meuTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		//ray = Camera.main.ScreenPointToRay(sensor.position);
		
		sensorPosRelCamera = new Vector3(
			sensor.position.x,
			sensor.position.y,
			Camera.main.transform.position.z);
		
		ray = new Ray(sensorPosRelCamera,  Camera.main.transform.forward);
		
		
		
		if(Physics.Raycast(ray, out colisao, 1000f) &&
			!GetComponent<CharacterMotor>().IsGrounded()){
			Debug.Log ("colidiu");
			Vector3 novaPosicao = new Vector3(
				colisao.point.x,
				meuTransform.position.y+0.3f,
				colisao.point.z+offsetZ);
			meuTransform.position = novaPosicao;
			
//			// trava a rotacao do personagem
//			meuTransform.rotation = Quaternion.identity;
		}
	
	}
	
	void OnDrawGizmos () {
		Gizmos.DrawLine(sensorPosRelCamera, new Vector3(
			sensorPosRelCamera.x,
			sensorPosRelCamera.y,
			sensorPosRelCamera.z+1000f));
		Gizmos.DrawWireSphere(colisao.point, 2f);
	}

}
