using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehaviour : MonoBehaviour {


	public float enemyHealth = 100;
	public float doingDamage;
	public float reward;
	public GameObject collider;
	public GameObject attack;
	public GameObject walking;
	private Vector3 unitPosition;
	public float movementSpeed;
	private float originalMovementSpeed;
	public Vector3 target;
	public TurrentBehaviour turrent;
	public Vector3 enemyPosition;
	public float attacktimer;
	private float timer;
	private float time;
	private bool attacking;
	public float route;
	private GameObject ai;
	public Vector3 delay;
	public AudioClip sword;

	// Use this for initialization
	void Start () {
		originalMovementSpeed = movementSpeed;
	}

	void ChangeHealth(float amount){
		enemyHealth -= amount;
	}
	
	// Update is called once per frame
	void Update () {
		attack.gameObject.transform.position = new Vector3 (0, 300, 0);
		walking.gameObject.transform.position = transform.position - new Vector3(0,5,0);
		ai = GameObject.FindGameObjectWithTag ("AI");
		collider.GetComponent<ColliderBehaviour> ().doingDamage = doingDamage;
		if(enemyHealth < 0)
		{
			transform.Translate(new Vector3(0,-30,0));
			time ++;
			if(time > 40)
			{
				if(route == 1)
				{
					ai.GetComponent<AI>().enemyTop -= 1;
				}
				if(route == 2)
				{
					ai.GetComponent<AI>().enemyMid -= 1;
				}
				if(route == 3)
				{
					ai.GetComponent<AI>().enemyBot -= 1;
				}
				ai.GetComponent<AI>().playerAmount += reward;
				Destroy(this.gameObject);
			}
		}
		enemyPosition = this.gameObject.transform.position;
		if(attacking == true)
		{
			timer++;
			attack.gameObject.transform.position = transform.position - new Vector3(0,5,0);
			walking.gameObject.transform.position = new Vector3 (0, 300, 0);
			delay = Vector3.zero;
			if(timer > attacktimer)
			{
				audio.PlayOneShot(sword);
				Instantiate(collider, unitPosition, transform.rotation);
				timer -= attacktimer;
			}
		}
		else
		{
			delay = new Vector3(4,0,0);
			timer = 0;
			transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
		}
		transform.LookAt(target);
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Unit") {
			attacking = true;
			unitPosition = col.transform.position;
			}
		if (col.tag == "Enemy") {
			attacking = true;
			unitPosition = new Vector3(0,100,0);
			}
		if (col.tag == "Collider") {
			ChangeHealth(col.GetComponent<ColliderBehaviour>().doingDamage);
				}
		if (col.tag == "missle") {
			ChangeHealth(col.GetComponent<missleBehaviour>().doingDamage);
		}
	}

	void OnTriggerStay (Collider col){
		if(col.tag == "Base1"){
			ai.gameObject.GetComponent<AI>().base1Health -= 1/20F;
		}
	}

	void OnTriggerExit (Collider col){
			if (col.tag == "Unit"||col.tag == "Enemy") {
			attacking = false;
			}
		}
	}