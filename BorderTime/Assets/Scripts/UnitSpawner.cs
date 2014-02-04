using UnityEngine;
using System.Collections;

public class UnitSpawner : MonoBehaviour {

	public float enemyCost;
	public float unitCost;
	public Object unit;
	public Object enemy;
	private float timer;
	public float waitTime;
	public AI ai;

	void Update () {
	}
	
	public void createUnits () {
			timer += 1;
			if(timer > waitTime)
			{
				if(ai.playerAmount>=unitCost)
				{
					Instantiate(unit, transform.position, transform.rotation);
					timer -= waitTime;
					ai.playerAmount -= unitCost;
				}
			}
		}

	public void createEnemies () {
			timer += 1;
			if(timer > waitTime)
			{
				if(ai.enemyAmount >= enemyCost)
				{
					Instantiate(enemy, transform.position, transform.rotation);
					timer -= waitTime;
					ai.enemyAmount -= enemyCost;
				}
			}
		}
	}
