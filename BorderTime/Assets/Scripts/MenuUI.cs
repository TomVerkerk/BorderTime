using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour {

	public Texture2D start;

	// Use this for initialization
	void OnGUI(){
		GUI.color = Color.clear;
		if(GUI.Button(new Rect(323,235,160,60), "" ))
		{
			Application.LoadLevel(1);
		}
	}
}
