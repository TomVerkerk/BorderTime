using UnityEngine;
using System.Collections;

public class TestSpawner : MonoBehaviour {

	public UnitSpawner base1;
	public WaypointControllerMid M1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			base1.createUnits();
		}
		if (Input.GetKey (KeyCode.Alpha1)) {
			M1.Unitdirection = 1;
			M1.changeDirection();
		}
		if (Input.GetKey (KeyCode.Alpha2)) {
			M1.Unitdirection = 2;
			M1.changeDirection();
		}
		if (Input.GetKey (KeyCode.Alpha3)) {
			M1.Unitdirection = 3;
			M1.changeDirection();
		}
	}
}
