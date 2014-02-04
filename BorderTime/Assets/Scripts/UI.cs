using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public TurretCreator creator;
	public AI ai;

	public GUIText scoreText;
	public GUIText base1health;
	public GUIText base2health;
	
	private Vector3 pos;

	public GUITexture fut1up1;
	public GUITexture fut1up2;
	public GUITexture fut1up3;
	public GUITexture fut2up1;
	public GUITexture fut2up1left;
	public GUITexture fut2up2;
	public GUITexture fut2up3;
	public GUITexture fut3up1;
	public GUITexture fut3up1left;
	public GUITexture fut3up2;
	public GUITexture fut3up3;
	public GUITexture fut1up1NFS;
	public GUITexture fut1up2NFS;
	public GUITexture fut1up3NFS;
	public GUITexture fut2up1NFS;
	public GUITexture fut2up1NFSleft;
	public GUITexture fut2up2NFS;
	public GUITexture fut2up3NFS;
	public GUITexture fut3up1NFS;
	public GUITexture fut3up1NFSleft;
	public GUITexture fut3up2NFS;
	public GUITexture fut3up3NFS;

	public GameObject turfut1up1;
	public GameObject turfut1up2;
	public GameObject turfut1up3;
	public GameObject turfut2up1;
	public GameObject turfut2up2;
	public GameObject turfut2up3;
	public GameObject turfut3up1;
	public GameObject turfut3up2;
	public GameObject turfut3up3;

	public GameObject spot1;
	public GameObject spot2;
	public GameObject spot3;
	public GameObject spot4;
	public GameObject spot5;
	public GameObject spot6;

	public Vector3 pos1;
	public Vector3 pos2;
	public Vector3 pos3;
	public Vector3 pos4;
	public Vector3 pos5;
	public Vector3 pos6;
	public float selectorRange;
	public GameObject collider;
	public GameObject selectedTurrent;
	private bool selected = false;
	public bool bought;

	void Start () {
		pos1 = turfut1up1.gameObject.GetComponent<TurrentBehaviour> ().pos1;
		pos2 = turfut1up1.gameObject.GetComponent<TurrentBehaviour> ().pos2;
		pos3 = turfut1up1.gameObject.GetComponent<TurrentBehaviour> ().pos3;
		pos4 = turfut1up1.gameObject.GetComponent<TurrentBehaviour> ().pos4;
		pos5 = turfut1up1.gameObject.GetComponent<TurrentBehaviour> ().pos5;
		pos6 = turfut1up1.gameObject.GetComponent<TurrentBehaviour> ().pos6;
		fut1up1.enabled = true;
		fut2up1.enabled = true;
		fut3up1.enabled = true;
		}

	void Update(){
			selectedTurrent = creator.selectedTower;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 Prepos = ray.GetPoint (270 - pos.z * 5 / 12 + pos.x * 3 / 12);
			pos = Prepos;
			pos.y = 10;
			float diffPos1 = (pos.x - pos1.x) * (pos.x - pos1.x) + (pos.z - pos1.z) * (pos.z - pos1.z);
			float diffPos2 = (pos.x - pos2.x) * (pos.x - pos2.x) + (pos.z - pos2.z) * (pos.z - pos2.z);
			float diffPos3 = (pos.x - pos3.x) * (pos.x - pos3.x) + (pos.z - pos3.z) * (pos.z - pos3.z);
			float diffPos4 = (pos.x - pos4.x) * (pos.x - pos4.x) + (pos.z - pos4.z) * (pos.z - pos4.z);
			float diffPos5 = (pos.x - pos5.x) * (pos.x - pos5.x) + (pos.z - pos5.z) * (pos.z - pos5.z);
			float diffPos6 = (pos.x - pos6.x) * (pos.x - pos6.x) + (pos.z - pos6.z) * (pos.z - pos6.z);
			if (diffPos1 < selectorRange && Input.GetMouseButton (0)) {
					Instantiate (collider, pos1, transform.rotation);
			}
			if (diffPos2 < selectorRange && Input.GetMouseButton (0)) {
					Instantiate (collider, pos2, transform.rotation);
			}
			if (diffPos3 < selectorRange && Input.GetMouseButton (0)) {
					Instantiate (collider, pos3, transform.rotation);
			}
			if (diffPos4 < selectorRange && Input.GetMouseButton (0)) {
					Instantiate (collider, pos4, transform.rotation);
			}
			if (diffPos5 < selectorRange && Input.GetMouseButton (0)) {
					Instantiate (collider, pos5, transform.rotation);
			}
			if (diffPos6 < selectorRange && Input.GetMouseButton (0)) {
					Instantiate (collider, pos6, transform.rotation);
			}
			if (Input.GetKeyDown (KeyCode.Escape)) {
					creator.selectedTower = collider;
					EmptyUI();
			}
		if(selectedTurrent.gameObject.name == "Tower fut 1 upgrade 1(Clone)" || selectedTurrent.gameObject.name == "Tower fut 1 upgrade 2(Clone)" || selectedTurrent.gameObject.name == "Tower fut 1 upgrade 3(Clone)")
		{
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos1)
			{
				disableSpots();
				spot1.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos2)
			{
				disableSpots();
				spot2.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos3)
			{
				disableSpots();
				spot3.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos4)
			{
				disableSpots();
				spot4.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos5)
			{
				disableSpots();
				spot5.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos6)
			{
				disableSpots();
				spot6.light.enabled = true;
			}
			selected = true;
			EmptyUI();
			fut1up1NFS.enabled = true;
			if(ai.playerAmount >= turfut1up2.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().level == 1)
				{
					fut1up2.enabled = true;
				}
				else
				{
					fut1up2NFS.enabled = true;
				}
			}
			if(ai.playerAmount < turfut1up2.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				fut1up2NFS.enabled = true;
			}
			if(ai.playerAmount >= turfut1up3.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().level == 2)
				{
					fut1up3.enabled = true;
				}
				else
				{
					fut1up3NFS.enabled = true;
				}
			}
			if(ai.playerAmount < turfut1up3.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				fut1up3NFS.enabled = true;
			}
		}
		if(selectedTurrent.gameObject.name == "Tower fut 2 upgrade 1(Clone)" || selectedTurrent.gameObject.name == "Tower fut 2 upgrade 2(Clone)" || selectedTurrent.gameObject.name == "Tower fut 2 upgrade 3(Clone)")
		{
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos1)
			{
				disableSpots();
				spot1.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos2)
			{
				disableSpots();
				spot2.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos3)
			{
				disableSpots();
				spot3.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos4)
			{
				disableSpots();
				spot4.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos5)
			{
				disableSpots();
				spot5.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos6)
			{
				disableSpots();
				spot6.light.enabled = true;
			}
			selected = true;
			EmptyUI();
			fut2up1NFSleft.enabled = true;
			if(ai.playerAmount >= turfut2up2.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().level == 1)
				{
					fut2up2.enabled = true;
				}
				else
				{
					fut2up2NFS.enabled = true;
				}
			}
			if(ai.playerAmount < turfut2up2.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				fut2up2NFS.enabled = true;
			}
			if(ai.playerAmount >= turfut2up3.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().level == 2)
				{
					fut2up3.enabled = true;
				}
				else
				{
					fut2up3NFS.enabled = true;
				}
			}
			if(ai.playerAmount < turfut2up3.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				fut2up3NFS.enabled = true;
			}
		}
		if(selectedTurrent.gameObject.name == "Tower fut 3 upgrade 1(Clone)" || selectedTurrent.gameObject.name == "Tower fut 3 upgrade 2(Clone)" || selectedTurrent.gameObject.name == "Tower fut 3 upgrade 3(Clone)")
		{
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos1)
			{
				disableSpots();
				spot1.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos2)
			{
				disableSpots();
				spot2.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos3)
			{
				disableSpots();
				spot3.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos4)
			{
				disableSpots();
				spot4.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos5)
			{
				disableSpots();
				spot5.light.enabled = true;
			}
			if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().transform.position == pos6)
			{
				disableSpots();
				spot6.light.enabled = true;
			}
			selected = true;
			EmptyUI();
			fut3up1NFSleft.enabled = true;
			if(ai.playerAmount >= turfut3up2.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().level == 1)
				{
					fut3up2.enabled = true;
				}
				else
				{
					fut3up2NFS.enabled = true;
				}
			}
			if(ai.playerAmount < turfut3up2.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				fut3up2NFS.enabled = true;
			}
			if(ai.playerAmount >= turfut3up3.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				if(selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().level == 2)
				{
					fut3up3.enabled = true;
				}
				else
				{
					fut3up3NFS.enabled = true;
				}
			}
			if(ai.playerAmount < turfut3up3.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				fut3up3NFS.enabled = true;
			}
		}
		if(selectedTurrent.gameObject.name == "Selector")
		{
			spot1.light.enabled = false;
			spot2.light.enabled = false;
			spot3.light.enabled = false;
			spot4.light.enabled = false;
			spot5.light.enabled = false;
			spot6.light.enabled = false;
			selected = false;
			EmptyUI();
			if (ai.playerAmount >= turfut1up1.gameObject.GetComponent<TurrentBehaviour> ().cost) {
				fut1up1NFS.enabled = false;
				fut1up1.enabled = true;
			}
			if (ai.playerAmount < turfut1up1.gameObject.GetComponent<TurrentBehaviour> ().cost) {
				fut1up1NFS.enabled = true;
				fut1up1.enabled = false;
			}
			if (ai.playerAmount >= turfut2up1.gameObject.GetComponent<TurrentBehaviour> ().cost) {
				fut2up1NFS.enabled = false;
				fut2up1.enabled = true;
			}
			if (ai.playerAmount < turfut2up1.gameObject.GetComponent<TurrentBehaviour> ().cost) {
				fut2up1NFS.enabled = true;
				fut2up1.enabled = false;
			}
			if (ai.playerAmount >= turfut3up1.gameObject.GetComponent<TurrentBehaviour> ().cost) {
				fut3up1NFS.enabled = false;
				fut3up1.enabled = true;
			}
			if (ai.playerAmount < turfut3up1.gameObject.GetComponent<TurrentBehaviour> ().cost) {
				fut3up1NFS.enabled = true;
				fut3up1.enabled = false;
			}
		}
	}

	// Use this for initialization
	void OnGUI(){
		GUI.color = Color.clear;
		scoreText.text = "" + ai.playerAmount;
		base1health.text = "Base 1: " + (int)ai.base1Health;
		base2health.text = "Base 2: " + (int)ai.base2Health;
		if(GUI.Button(new Rect(23,432,55,55), "" ))
		{
			if(selected == false && bought == false)
			{
				creator.turrentCost = turfut1up1.gameObject.GetComponent<TurrentBehaviour> ().cost;
				creator.turrent = turfut1up1;
				creator.CreateTurrent();
				bought = true;
			}
		}
		if(GUI.Button(new Rect(112,432,55,55), "" ))
		{
			if(selected == false && bought == false)
			{
				creator.turrentCost = turfut2up1.gameObject.GetComponent<TurrentBehaviour> ().cost;
				creator.turrent = turfut2up1;
				creator.CreateTurrent();
				bought = true;
			}
			if(selected == true && selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().level == 1 && ai.playerAmount >= selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().upgrade.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				if(selectedTurrent.gameObject.name == "Tower fut 1 upgrade 1(Clone)" || selectedTurrent.gameObject.name == "Tower fut 1 upgrade 2(Clone)" || selectedTurrent.gameObject.name == "Tower fut 1 upgrade 3(Clone)")
				{
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().enemy = false;
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().Upgrade();
				}
				if(selectedTurrent.gameObject.name == "Tower fut 2 upgrade 1(Clone)" || selectedTurrent.gameObject.name == "Tower fut 2 upgrade 2(Clone)" || selectedTurrent.gameObject.name == "Tower fut 3 upgrade 3(Clone)")
				{
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().enemy = false;
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().Upgrade();
				}
				if(selectedTurrent.gameObject.name == "Tower fut 3 upgrade 1(Clone)" || selectedTurrent.gameObject.name == "Tower fut 3 upgrade 2(Clone)" || selectedTurrent.gameObject.name == "Tower fut 3 upgrade 3(Clone)")
				{
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().enemy = false;
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().Upgrade();
				}
			}
		}
		if(GUI.Button(new Rect(203,432,55,55), "" ))
		{
			if(selected == false && bought == false)
			{
				creator.turrentCost = turfut3up1.gameObject.GetComponent<TurrentBehaviour> ().cost;
				creator.turrent = turfut3up1;
				creator.CreateTurrent();
				bought = true;
			}
			if(selected == true && selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().level == 2 && ai.playerAmount >= selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().upgrade.gameObject.GetComponent<TurrentBehaviour>().cost)
			{
				if(selectedTurrent.gameObject.name == "Tower fut 1 upgrade 1(Clone)" || selectedTurrent.gameObject.name == "Tower fut 1 upgrade 2(Clone)" || selectedTurrent.gameObject.name == "Tower fut 1 upgrade 3(Clone)")
				{
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().enemy = false;
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().Upgrade();
				}
				if(selectedTurrent.gameObject.name == "Tower fut 2 upgrade 1(Clone)" || selectedTurrent.gameObject.name == "Tower fut 2 upgrade 2(Clone)" || selectedTurrent.gameObject.name == "Tower fut 3 upgrade 3(Clone)")
				{
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().enemy = false;
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().Upgrade();
				}
				if(selectedTurrent.gameObject.name == "Tower fut 3 upgrade 1(Clone)" || selectedTurrent.gameObject.name == "Tower fut 3 upgrade 2(Clone)" || selectedTurrent.gameObject.name == "Tower fut 3 upgrade 3(Clone)")
				{
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().enemy = false;
					selectedTurrent.gameObject.GetComponent<TurrentBehaviour>().Upgrade();
				}
			}
		}
	}

	void EmptyUI(){
		fut1up1.enabled = false;
		fut1up2.enabled = false;
		fut1up3.enabled = false;
		fut2up1.enabled = false;
		fut2up1left.enabled = false;
		fut2up2.enabled = false;
		fut2up3.enabled = false;
		fut3up1.enabled = false;
		fut3up1left.enabled = false;
		fut3up2.enabled = false;
		fut3up3.enabled = false;
		fut1up1NFS.enabled = false;
		fut1up2NFS.enabled = false;
		fut1up3NFS.enabled = false;
		fut2up1NFS.enabled = false;
		fut2up1NFSleft.enabled = false;
		fut2up2NFS.enabled = false;
		fut2up3NFS.enabled = false;
		fut3up1NFS.enabled = false;
		fut3up1NFSleft.enabled = false;
		fut3up2NFS.enabled = false;
		fut3up3NFS.enabled = false;
	}

	void disableSpots(){
		spot1.light.enabled = false;
		spot2.light.enabled = false;
		spot3.light.enabled = false;
		spot4.light.enabled = false;
		spot5.light.enabled = false;
		spot6.light.enabled = false;
	}
}
