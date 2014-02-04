using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public float base1Health = 100F;
	public float base2Health = 100F;
	private GameObject createdTurrent;
	public float enemyAmount;
	public float playerAmount;
	public float turrentCost;
	public GameObject turrent1;
	public GameObject turrent2;
	public GameObject turrent3;
	public GameObject waypointLeft;
	public GameObject waypointRight;
	public WaypointControllerMid M2;
	public TurretCreator creator;
	public float UnitTop;
	public float UnitMid;
	public float UnitBot;
	public float enemyTop;
	public float enemyMid;
	public float enemyBot;
	private float diffTop;
	private float diffMid;
	private float diffBot;
	public UnitSpawner enemyBase;
	public float diffTillAttack;
	private float timer;
	private float time;
	public float actionTimer;
	public float cheapestEnemy;
	public float cheapestTurrent;
	public Vector3 Pos1;
	public Vector3 Pos2;
	public Vector3 Pos3;
	public Vector3 Pos4;
	public Vector3 Pos5;
	public Vector3 Pos6;
	private bool platform1 = true;
	private bool platform2 = true;
	private bool platform3 = true;
	private bool platform4 = true;
	private bool platform5 = true;
	private bool platform6 = true;
	public AudioClip bg;

	// Use this for initialization
	void Start () {
		audio.PlayOneShot (bg);
		enemyAmount += 50;
		playerAmount += 30;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (playerAmount);
		if(base1Health <= 0)
		{
			base1Health = 0;
			Application.LoadLevel(0);
		}
		if(base2Health <= 0)
		{
			base1Health = 0;
			Application.LoadLevel(0);
		}
		diffTop = UnitTop - enemyTop;
		diffMid = UnitMid - enemyMid;
		diffBot = UnitBot - enemyBot;
		if(diffTop > diffTillAttack || diffMid > diffTillAttack || diffBot > diffTillAttack)
		{
			Attack();
		}
		if(UnitTop == 0 && UnitMid == 0 && UnitBot == 0 && enemyAmount >= (cheapestEnemy*2))
		{
			time++;
			if(time > 400)
			{
				if(Random.value < 0.333)
				{
					M2.Enemydirection = 1;
					M2.changeDirection();
				}
				if(Random.value > 0.6666)
				{
					M2.Enemydirection = 2;
					M2.changeDirection();
				}
				if(Random.value >= 0.333 && Random.value <= 0.666)
				{
					M2.Enemydirection = 3;
					M2.changeDirection();
				}
				Attack();
			}
		}
		else
		{
			time = 0;
			timer++;
			if(timer > actionTimer && enemyAmount >= cheapestTurrent + (cheapestEnemy*2))
			{
				if(Random.value<=0.6 && enemyAmount >= creator.turrentCost)
				{
					if(Random.value < 0.2)
					{
						createdTurrent = Instantiate(turrent1, new Vector3(0,100,0), transform.rotation) as GameObject;
					}
					if(Random.value > 0.4)
					{
						createdTurrent = Instantiate(turrent2, new Vector3(0,100,0), transform.rotation) as GameObject;
					}
					else
					{
						createdTurrent = Instantiate(turrent3, new Vector3(0,100,0), transform.rotation) as GameObject;
					}
						enemyAmount -= creator.turrentCost;
						if(Random.value <=0.5)
						{
							if(platform3 == true)
							{
								createdTurrent.transform.position = Pos3;
								createdTurrent.GetComponentInChildren<TurrentCollider>().friendly = false;
								createdTurrent.GetComponent<TurrentBehaviour>().towerIsPlaced = true;
								platform3 = false;
							}
							else
							{
								if(platform5 == true)
								{
									createdTurrent.transform.position = Pos5;
									createdTurrent.GetComponentInChildren<TurrentCollider>().friendly = false;
									createdTurrent.GetComponent<TurrentBehaviour>().towerIsPlaced = true;
									platform5 = false;
								}
								else if(platform6 == true)
								{
									createdTurrent.transform.position = Pos6;
									createdTurrent.GetComponentInChildren<TurrentCollider>().friendly = false;
									createdTurrent.GetComponent<TurrentBehaviour>().towerIsPlaced = true;
									platform6 = false;
								}
							}
						}
						else
						{
							if(platform4 == true)
							{
								createdTurrent.transform.position = Pos4;
								createdTurrent.GetComponentInChildren<TurrentCollider>().friendly = false;
								createdTurrent.GetComponent<TurrentBehaviour>().towerIsPlaced = true;
								platform4 = false;
							}
							else
							{
								if(platform1 == true)
								{
									createdTurrent.transform.position = Pos1;
									createdTurrent.GetComponentInChildren<TurrentCollider>().friendly = false;
									createdTurrent.GetComponent<TurrentBehaviour>().towerIsPlaced = true;
									platform1 = false;
								}
								else if(platform2 == true)
								{
									createdTurrent.transform.position = Pos2;
									createdTurrent.GetComponentInChildren<TurrentCollider>().friendly = false;
									createdTurrent.GetComponent<TurrentBehaviour>().towerIsPlaced = true;
									platform2 = false;
								}
							}
						}
					}
				else
				{
					if(Random.value < 0.5)
					{
						if(Random.value < 0.25)
						{
							createdTurrent = GameObject.FindWithTag("T1");
						}
						if(Random.value >= 0.25 && Random.value < 0.5)
						{
							createdTurrent = GameObject.FindWithTag("T2");
						}
						if(Random.value >= 0.5 && Random.value < 0.75)
						{
							createdTurrent = GameObject.FindWithTag("T3");
						}
						if(Random.value >= 0.7)
						{createdTurrent = GameObject.FindWithTag("T4");
							
						}
					}
					if(Random.value >= 0.5)
					{
						if(Random.value < 0.5)
						{
							createdTurrent = GameObject.FindWithTag("T5");
						}
						if(Random.value >= 0.5)
						{
							createdTurrent = GameObject.FindWithTag("T6");
						}
					}
					createdTurrent.gameObject.GetComponent<TurrentBehaviour>().enemy = true;
					createdTurrent.gameObject.GetComponent<TurrentBehaviour>().Upgrade();
				}
				timer -= actionTimer;
			}
		}
		if(diffTop > diffTillAttack)
		{
			waypointRight.GetComponent<WaypointControllerMid>().Enemydirection = 1;
			waypointRight.GetComponent<WaypointControllerMid>().changeDirection();
		}
		if(diffMid > diffTillAttack)
		{
			waypointRight.GetComponent<WaypointControllerMid>().Enemydirection = 2;
			waypointRight.GetComponent<WaypointControllerMid>().changeDirection();
		}
		if(diffBot > diffTillAttack)
		{
			waypointRight.GetComponent<WaypointControllerMid>().Enemydirection = 3;
			waypointRight.GetComponent<WaypointControllerMid>().changeDirection();
		}
	}

	void Attack () {
		if(enemyAmount >= cheapestEnemy)
		{
			enemyBase.createEnemies ();
		}
	}
}
