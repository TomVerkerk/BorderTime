using UnityEngine;
using System.Collections;

public class WaypointControllerMid : MonoBehaviour {
	
	public GameObject EnemyWaypointUp;
	public GameObject EnemyWaypointMid;
	public GameObject EnemyWaypointDown;
	private GameObject nextEnemyWaypoint;
	public GameObject UnitWaypointUp;
	public GameObject UnitWaypointMid;
	public GameObject UnitWaypointDown;
	private GameObject nextUnitWaypoint;
	public WaypointControllerMid M1;
	public WaypointControllerMid M2;
	public int Unitdirection;
	public int Enemydirection;
	public AI ai;
	
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
			if(nextUnitWaypoint == UnitWaypointUp && this.gameObject.CompareTag("M1"))
			{
				ai.UnitTop += 1;
				col.gameObject.GetComponent<UnitBehaviour>().route = 1;
			}
			if(nextUnitWaypoint == UnitWaypointMid && this.gameObject.CompareTag("M1"))
			{
				ai.UnitMid +=  1;
				col.gameObject.GetComponent<UnitBehaviour>().route = 2;
			}
			if(nextUnitWaypoint == UnitWaypointDown && this.gameObject.CompareTag("M1"))
			{
				ai.UnitBot +=  1;
				col.gameObject.GetComponent<UnitBehaviour>().route = 3;
			}
		}
		if(col.gameObject.CompareTag("Enemy"))
		{
			col.gameObject.GetComponent<EnemyBehaviour>().target = nextEnemyWaypoint.transform.position;
			if(nextEnemyWaypoint == EnemyWaypointUp && this.gameObject.CompareTag("M2"))
			{
				ai.enemyTop += 1;
				col.gameObject.GetComponent<EnemyBehaviour>().route = 1;
			}
			if(nextEnemyWaypoint == EnemyWaypointMid && this.gameObject.CompareTag("M2"))
			{
				ai.enemyMid += 1;
				col.gameObject.GetComponent<EnemyBehaviour>().route = 2;
			}
			if(nextEnemyWaypoint == EnemyWaypointDown && this.gameObject.CompareTag("M2"))
			{
				ai.enemyBot += 1;
				col.gameObject.GetComponent<EnemyBehaviour>().route = 3;
			}
		}
	}
}
