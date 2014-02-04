using UnityEngine;
using System.Collections;

public class WaypointController : MonoBehaviour {

	public GameObject EnemyWaypointUp;
	public GameObject EnemyWaypointMid;
	public GameObject EnemyWaypointDown;
	private GameObject nextEnemyWaypoint;
	public GameObject UnitWaypointUp;
	public GameObject UnitWaypointMid;
	public GameObject UnitWaypointDown;
	private GameObject nextUnitWaypoint;
	public int Unitdirection;
	public int Enemydirection;

	void Start () {
		changeDirection();
	}

	public void changeDirection () {
		switch(Unitdirection)
		{
		case 1:
			//up
			nextUnitWaypoint = UnitWaypointUp;
			break;
		case 2:
			//right
			nextUnitWaypoint = UnitWaypointMid;
			break;
		case 3:
			//down
			nextUnitWaypoint = UnitWaypointDown;
			break;
		default:
			//right
			nextUnitWaypoint = UnitWaypointMid;
			break;
		}
		switch(Enemydirection)
		{
		case 1:
			//up
			nextEnemyWaypoint = EnemyWaypointUp;
			break;
		case 2:
			//right
			nextEnemyWaypoint = EnemyWaypointMid;
			break;
		case 3:
			//down
			nextEnemyWaypoint = EnemyWaypointDown;
			break;
		default:
			//right
			nextEnemyWaypoint = EnemyWaypointMid;
			break;
		}

	}
	
	// Use this for initialization
	void OnTriggerEnter (Collider col) {
		if(col.gameObject.CompareTag("Unit"))
		{
			col.gameObject.GetComponent<UnitBehaviour>().target = nextUnitWaypoint.transform.position;

		}
		if(col.gameObject.CompareTag("Enemy"))
		{
			col.gameObject.GetComponent<EnemyBehaviour>().target = nextEnemyWaypoint.transform.position;
		}
	}
}
