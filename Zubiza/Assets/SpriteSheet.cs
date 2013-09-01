// ------------------------------------------------------------------------------------------------------------
// 			SpriteSheet.cs
//  	Author: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------
 
using UnityEngine;
using System.Collections;
 
/*This script automatically builds an animation based on the sprite sheet texture.
 * To use it, configure it's public parameters, then right-click in the component and click Build 
*/
 
[RequireComponent (typeof(Animation))]
public class SpriteSheet : MonoBehaviour {
	public float fps = 12.0f;
	public int rows = 3;
	public int columns = 3;
	public int missingFrames = 0;
	public WrapMode wrapMode = WrapMode.Loop;
	
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	/// <summary>
	/// Builds the animation.
	/// </summary>
	[ContextMenu ("Build")]
	void Build(){
		this.renderer.sharedMaterial.mainTextureScale = new Vector2(1.0f / this.columns, 1.0f / this.rows);
		this.renderer.sharedMaterial.mainTextureOffset = new Vector2(0.0f, 1.0f - (1.0f / this.rows));
		
		this.animation.clip = null;
		
		AnimationClip clip = new AnimationClip();
		
		//Offset curves
		AnimationCurve xOffsetCurve = new AnimationCurve();
		AnimationCurve yOffsetCurve = new AnimationCurve();
		
		int keyCount = 0;
		for(int j = 0; j < rows; j++){			
			Keyframe yKey = new Keyframe(
				(1.0f / this.fps) * keyCount,		//time
				1.0f - ((1.0f / this.rows) * (j+1)),	//value
				Mathf.Infinity,						//inTangent
				0									//outTangent
				);
			
			yOffsetCurve.AddKey(yKey);
			
			for(int i = 1; i <= columns; i++){
				Keyframe xKey = new Keyframe(
					(1.0f / this.fps) * keyCount,		//time
					(1.0f / this.columns) * (i - 1),	//value
					Mathf.Infinity,						//inTangent
					0									//outTangent
					);
				
				xOffsetCurve.AddKey(xKey);
				
				keyCount++;
				
				//Exclude keyframes because we don't have frames in the texture.
				if((keyCount) > (rows * columns) - this.missingFrames){
					break;
				}
			}
			
			//Exclude keyframes because we don't have frames in the texture.
			if((keyCount) > (rows * columns) - this.missingFrames){
				break;
			}
		}
		
		clip.SetCurve("", typeof(Material), "_MainTex.offset.x", xOffsetCurve);
        clip.SetCurve("", typeof(Material), "_MainTex.offset.y", yOffsetCurve);		
        
		clip.name = "Animation";
		clip.wrapMode = this.wrapMode;
		
		if(animation[clip.name] != null)
			animation.RemoveClip("Animation");
		animation.AddClip(clip, clip.name);
		animation.clip = clip;
		animation.wrapMode = this.wrapMode;
	}
}