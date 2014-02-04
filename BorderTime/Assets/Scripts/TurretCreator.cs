using UnityEngine;
using System.Collections;

public class TurretCreator : MonoBehaviour
{
	public UI ui;
	public GameObject turrent;
	public float turrentCost;
	public GameObject currentTower;
	public GameObject selectedTower;
	private bool firstTower = true;
	public AI ai;
	public bool pos1 = true;
	public bool pos2 = true;
	public bool pos3 = true;
	public bool pos4 = true;
	public bool pos5 = true;
	public bool pos6 = true;

	void Start(){
		selectedTower = ui.collider;
		}

	public void CreateTurrent ()
	{
		if(ai.playerAmount >= turrentCost && firstTower == true)
		{
			currentTower = Instantiate(turrent, new Vector3(0,100,0), transform.rotation) as GameObject;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().towerIsPlaced = false;
			currentTower.gameObject.GetComponentInChildren<TurrentCollider>().friendly = true;
			firstTower = false;
			ai.playerAmount -= turrentCost;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open1 = pos1;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open2 = pos2;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open3 = pos3;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open4 = pos4;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open5 = pos5;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open6 = pos6;
		}
		if(ai.playerAmount >= turrentCost && firstTower == false && currentTower.gameObject.GetComponent<TurrentBehaviour>().towerIsPlaced == true)
		{
			currentTower = Instantiate(turrent, new Vector3(0,100,0), transform.rotation) as GameObject;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().towerIsPlaced = false;
			currentTower.gameObject.GetComponentInChildren<TurrentCollider>().friendly = true;
			firstTower = false;
			ai.playerAmount -= turrentCost;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open1 = pos1;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open2 = pos2;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open3 = pos3;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open4 = pos4;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open5 = pos5;
			currentTower.gameObject.GetComponent<TurrentBehaviour>().open6 = pos6;
		}
	}
}