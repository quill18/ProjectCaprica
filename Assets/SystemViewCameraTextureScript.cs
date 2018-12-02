using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemViewCameraTextureScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // This script should be on the same gameobject as the image/sprite

        RectTransform rt = GetComponent<RectTransform>();

        SystemViewTexture = new RenderTexture( (int)rt.rect.width, (int)rt.rect.height, 24 );
        SystemCamera.targetTexture = SystemViewTexture;

        //Sprite sprite = Sprite.Create(  );

        RawImage ri = GetComponent<RawImage>();

        ri.texture = SystemViewTexture;

    }

    RenderTexture SystemViewTexture;

    public Camera SystemCamera;
	
	// Update is called once per frame
	void Update () {
		
	}
}
