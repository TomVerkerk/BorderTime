using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitBehaviour : MonoBehaviour {

	public float unitHealth = 100;
	public float doingDamage;
	public float reward;
	public GameObject collider;
	public GameObject attack;
	public GameObject walking;
	private Vector3 enemyPosition = new Vector3 (10000, 0, 0);
	public float movementSpeed;
	private float originalMovementSpeed;
	public Vector3 target;
	public TurrentBehaviour turrent;
	public Vector3 unitPosition;
	public float attacktimer;
	private float timer;
	private float time = 0;
	private bool attacking = false;
	public float route;
	private bool unit;
	public GameObject ai;
	public Vector3 delay;
	public AudioClip hit;

	// Use this for initialization
	void Start () {
		originalMovementSpeed = movementSpeed;
	}

	void ChangeHealth(float amount){
		unitHealth -= amount;
		}
	
	// Update is called once per frame
	void Update () {
		attack.gameObject.transform.position = new Vector3 (0, 200, 0);
		walking.gameObject.transform.position = transform.position;
		ai = GameObject.FindGameObjectWithTag ("AI");
		collider.GetComponent<ColliderBehaviour> ().doingDamage = doingDamage;
		if(unitHealth < 0)
		{
			transform.Translate(new Vector3(0,-3,0));
			time ++;
			if(time > 40)
			{
				if(route == 1)
				{
					ai.GetComponent<AI>().UnitTop -= 1;
				}
				if(route == 2)
				{
					ai.GetComponent<AI>().UnitMid -= 1;
				}
				if(route == 3)
				{
					ai.GetComponent<AI>().UnitBot -= 1;
				}
				ai.GetComponent<AI>().enemyAmount += reward;
				Destroy(this.gameObject);
			}
		}
		unitPosition = this.gameObject.transform.position;
		if(attacking == true)
		{
			timer++;
			attack.gameObject.transform.position = transform.position - new Vector3(0,5,0);
			walking.gameObject.transform.position = new Vector3 (0, 200, 0);
			delay = Vector3.zero;
			if(timer > attacktimer)
			{
				audio.PlayOneShot(hit);
				Instantiate(collider, enemyPosition, transform.rotation);
				timer -= attacktimer;
			}
		}
		else
		{
			delay = new Vector3(-4,0,0);
			timer = 0;
			transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
		}
		transform.LookAt(target);
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Enemy") {
			attacking = true;
			enemyPosition = col.transform.position;
		}
		if(col.tag == "Unit" && col.gameObject.GetComponent<UnitBehaviour>().attacking == true)
		{
			attacking = true;
		}
		if (col.tag == "Collider") {
			ChangeHealth(col.GetComponent<ColliderBehaviour>().doingDamage);
		}
		if (col.tag == "missle") {
			ChangeHealth(col.GetComponent<missleBehaviour>().doingDamage);
		}
	}

	void OnTriggerStay (Collider col){
		if(col.tag == "Base2"){
			ai.gameObject.GetComponent<AI>().base2Health -= 1/20F;
		}
	}
	
	void OnTriggerExit (Collider col){
		if (col.tag == "Enemy"||col.tag == "Unit") {
			attacking = false;
		}
	}
}