using UnityEngine;
using System.Collections;

public class TeleportaJogador : MonoBehaviour {
	
	public float offsetZ = 0.5f;
	public Transform sensor;
	public bool noChao = false;
	public Ray ray;
	public RaycastHit colisao;
	
	// Use this for initialization
	void Start () {
		sensor = GameObject.Find("SensorTeleporte").transform;
	}
	
	// Update is called once per frame
	void Update () {
		// trava a rotacao do personagem
		transform.rotation = Quaternion.identity;
		//ray = Camera.main.ScreenPointToRay(sensor.position);
		
		Vector3 sensorPosRelCamera = new Vector3(
			sensor.position.x,
			sensor.position.y,
			Camera.main.transform.position.z
			);
		
		ray = new Ray(sensorPosRelCamera,  Camera.main.transform.TransformDirection(sensor.forward));
		
		if(Physics.Raycast(ray, out colisao, 1000f)){
			Vector3 novaPosicao = new Vector3(
				colisao.point.x,
				transform.position.y,
				colisao.point.z+offsetZ);
			transform.position = novaPosicao;
		}
	
	}
	
	void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		
		Matrix4x4 m = Camera.main.cameraToWorldMatrix;
		Vector3 p = m.MultiplyPoint(sensor.position);
	}
}
