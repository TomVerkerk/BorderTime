using UnityEngine;
using System.Collections;

public class missleBehaviour : MonoBehaviour {

	private float timer = 0;
	public float destroyTime;
	public float doingDamage;
	public float missleSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if(timer>destroyTime)
		{
			Destroy(this.gameObject);
		}
		transform.Translate (Vector3.forward * missleSpeed * Time.deltaTime);
	}
}
