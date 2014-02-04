using UnityEngine;
using System.Collections;

public class TurrentCollider : MonoBehaviour {
	
	public GameObject turrent;
	private Vector3 unitPosition;
	public bool friendly;

	void Start () {
	}

	void Update(){
		turrent.gameObject.GetComponent<TurrentBehaviour> ().closestUnit = unitPosition;
	}

	// Use this for initialization
	void OnTriggerStay (Collider col) {
		if(col.tag == "Unit" && friendly == false && col.gameObject.GetComponent<UnitBehaviour>().unitHealth >0)
		{
			unitPosition = col.gameObject.GetComponent<UnitBehaviour>().unitPosition;
			turrent.gameObject.GetComponent<TurrentBehaviour>().delay = col.gameObject.GetComponent<UnitBehaviour>().delay;
			turrent.gameObject.GetComponent<TurrentBehaviour> ().attacking = true;
		}
		if(col.tag == "Enemy" && friendly == true && col.gameObject.GetComponent<EnemyBehaviour>().enemyHealth >0)
		{
			unitPosition = col.gameObject.GetComponent<EnemyBehaviour>().enemyPosition;
			turrent.gameObject.GetComponent<TurrentBehaviour>().delay = col.gameObject.GetComponent<EnemyBehaviour>().delay;
			turrent.gameObject.GetComponent<TurrentBehaviour>().attacking = true;
		}
	}

	void OnTriggerExit(Collider col) {
				turrent.gameObject.GetComponent<TurrentBehaviour> ().attacking = false;
		}
}
