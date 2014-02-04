using UnityEngine;
using System.Collections;

public class ColliderBehaviour : MonoBehaviour {

	public float doingDamage;
	public float destroytime;
	private float timer;

	void Update () {
		timer++;
		if (timer > destroytime) {
			Destroy(this.gameObject);
				}
	}
}
