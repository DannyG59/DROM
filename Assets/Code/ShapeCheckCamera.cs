﻿///
// ShapeCheckCamera - By Daniel Gallagher
// Copyright Funny Looking Games 2016
///
using UnityEngine;
using System.Collections;

public class ShapeCheckCamera : MonoBehaviour {

	#region private variables
	private Camera _camera;
	#endregion

	#region public interface
	public Texture2D texture;

	public int blue = 0;
	public int red = 0;
	public int white = 0;
	#endregion

	#region monobehaviour inherited
	void Start() {
		_camera = GetComponent<Camera> ();

		InvokeRepeating ("Check", 0f, 1f);
	}

	public Vector3 Check() {
		Destroy (texture);
		RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
		_camera.targetTexture = rt;

		texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		_camera.Render();
		RenderTexture.active = rt;
		texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		_camera.targetTexture = null;
		RenderTexture.active = null; // JC: added to avoid errors
		Destroy(rt);

		Color32[] pixels = texture.GetPixels32 ();

		blue = 0;
		red = 0;

		foreach (var p in pixels) {
			if (p.b > 0.8f && ((p.r < 0.5f) && (p.g < 0.5f)))
				blue++;

			if (p.r > 0.8f && ((p.b < 0.5f) && (p.g < 0.5f)))
				red++;
		}

        return new Vector2(blue, red);
	}
	#endregion

	#region public methods
	#endregion

	#region private methods
	#endregion

	#region event handlers
	#endregion
}
