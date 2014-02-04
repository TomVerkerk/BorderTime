using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurrentBehaviour : MonoBehaviour
{
	public float cost;
	public GameObject ai;
	public GameObject ui;
	public GameObject missle;
	public GameObject upgrade;
	public float level;
	public bool enemy;
	private GameObject nextTurrent;
	public float doingDamage;
	public bool towerIsPlaced = false;
	public bool attacking;
	public float shootTimer;
	public float range;
	public AudioClip shot;
	public AudioClip placed;
	public AudioClip turn;
	public Vector3 closestUnit;
	private float timer;
	public bool open1;
	public bool open2;
	public bool open3;
	public bool open4;
	public bool open5;
	public bool open6;
	public Vector3 pos1;
	public Vector3 pos2;
	public Vector3 pos3;
	public Vector3 pos4;
	public Vector3 pos5;
	public Vector3 pos6;
	public Vector3 delay;
	public Vector3 pos;


	void Update()
	{
		ai = GameObject.FindWithTag ("AI");
		ui = GameObject.FindWithTag ("UI");
		missle.GetComponent<missleBehaviour> ().doingDamage = doingDamage;
		if(!towerIsPlaced)
		{
			//-------------follow mouse------------\\
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 Prepos = ray.GetPoint(270 - pos.z*5/12 + pos.x*3/12);
			pos = Prepos;
			pos.y = 10;
			float diffPos1 = (pos.x - pos1.x)*(pos.x - pos1.x)+(pos.z - pos1.z)*(pos.z - pos1.z);
			float diffPos2 = (pos.x - pos2.x)*(pos.x - pos2.x)+(pos.z - pos2.z)*(pos.z - pos2.z);
			float diffPos3 = (pos.x - pos3.x)*(pos.x - pos3.x)+(pos.z - pos3.z)*(pos.z - pos3.z);
			float diffPos4 = (pos.x - pos4.x)*(pos.x - pos4.x)+(pos.z - pos4.z)*(pos.z - pos4.z);
			float diffPos5 = (pos.x - pos5.x)*(pos.x - pos5.x)+(pos.z - pos5.z)*(pos.z - pos5.z);
			float diffPos6 = (pos.x - pos6.x)*(pos.x - pos6.x)+(pos.z - pos6.z)*(pos.z - pos6.z);
			if(Input.GetMouseButton(0) && transform.position != new Vector3(0,100,0))
			{
				audio.PlayOneShot(placed);
				towerIsPlaced = true;
				ui.gameObject.GetComponent<UI>().bought = false;
			}
			if(diffPos1 < range && open1 == true)
			{
				transform.position = pos1;
				if(towerIsPlaced == true)
				{
					ai.gameObject.GetComponent<TurretCreator>().pos1 = false;
				}
			}
			if(diffPos2 < range && open2 == true)
			{
				transform.position = pos2;
				if(towerIsPlaced == true)
				{
					ai.gameObject.GetComponent<TurretCreator>().pos2 = false;
				}
			}
			if(diffPos3 < range && open3 == true)
			{
				transform.position = pos3;
				if(towerIsPlaced == true)
				{
					ai.gameObject.GetComponent<TurretCreator>().pos3 = false;
				}
			}
			if(diffPos4 < range && open4 == true)
			{
				transform.position = pos4;
				if(towerIsPlaced == true)
				{
					ai.gameObject.GetComponent<TurretCreator>().pos4 = false;
				}
			}
			if(diffPos5 < range && open5 == true)
			{
				transform.position = pos5;
				if(towerIsPlaced == true)
				{
					ai.gameObject.GetComponent<TurretCreator>().pos5 = false;
				}
			}
			if(diffPos6 < range && open6 == true)
			{
				transform.position = pos6;
				if(towerIsPlaced == true)
				{
					ai.gameObject.GetComponent<TurretCreator>().pos6 = false;
				}
			}


			if(Input.GetKeyDown(KeyCode.Escape))
			{
				towerIsPlaced = true;
				transform.position = new Vector3(0,1000,0);
				ui.gameObject.GetComponent<UI>().selectedTurrent = ui.gameObject.GetComponent<UI>().collider;
				ui.gameObject.GetComponent<UI>().bought = false;
				ai.gameObject.GetComponent<AI>().playerAmount += ai.GetComponent<TurretCreator>().turrentCost;
			}
		}
		else
		{
			if(attacking == true)
			{
				transform.LookAt(closestUnit + delay);
				//audio.PlayOneShot(turn);
				timer++;
				if(timer>shootTimer)
				{
					audio.PlayOneShot(shot);
					timer -= shootTimer;
					Instantiate(missle, transform.position, transform.rotation);
				}
			}
		}
	}

	void OnTriggerStay(Collider col){
		if(col.CompareTag("Selector"))
		{
			ai.gameObject.GetComponent<TurretCreator>().selectedTower = this.gameObject;
		}
	}

	public void Upgrade(){
		if(enemy == false && ai.GetComponent<AI>().enemyAmount >= upgrade.GetComponent<TurrentBehaviour>().cost)
		{
			nextTurrent = Instantiate (upgrade, transform.position, transform.rotation) as GameObject;
			ai.gameObject.GetComponent<TurretCreator> ().selectedTower = nextTurrent;
			ai.gameObject.GetComponent<TurretCreator> ().currentTower = nextTurrent;
			nextTurrent.gameObject.GetComponent<TurrentBehaviour>().towerIsPlaced = true;
			ai.GetComponent<AI>().playerAmount -= nextTurrent.gameObject.GetComponent<TurrentBehaviour>().cost;
			nextTurrent.gameObject.GetComponentInChildren<TurrentCollider>().friendly = true;
			nextTurrent.gameObject.GetComponent<TurrentBehaviour> ().level = level += 1;
			Destroy (this.gameObject);
		}
		if (enemy == true && ai.GetComponent<AI>().enemyAmount >= upgrade.GetComponent<TurrentBehaviour>().cost)
		{
			nextTurrent = Instantiate (upgrade, transform.position, transform.rotation) as GameObject;
			ai.gameObject.GetComponent<TurretCreator> ().selectedTower = nextTurrent;
			ai.gameObject.GetComponent<TurretCreator> ().currentTower = nextTurrent;
			nextTurrent.gameObject.GetComponent<TurrentBehaviour>().towerIsPlaced = true;
			ai.GetComponent<AI>().enemyAmount -= nextTurrent.gameObject.GetComponent<TurrentBehaviour>().cost;
			nextTurrent.gameObject.GetComponentInChildren<TurrentCollider>().friendly = false;
			nextTurrent.gameObject.GetComponent<TurrentBehaviour> ().level = level += 1;
			Destroy (this.gameObject);
		}
	}
}