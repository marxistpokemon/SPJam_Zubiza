using UnityEngine;
using System.Collections;

public class AutoTileTextures : MonoBehaviour {
	
	public int tileSizeX = 2;
	public int tileSizeY = 2;
	
	// Use this for initialization
	void Start () {
		renderer.material.mainTextureScale = new Vector2(
				transform.lossyScale.x/tileSizeX, 
				transform.lossyScale.y/tileSizeY);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
