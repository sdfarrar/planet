using UnityEngine;

public class Meteor : MonoBehaviour {

	public Transform target;
	public float speed = 5f;
	public GameObject explosionEffect;
	public MeteorType type;

	void Start () {

	}

	void Update () {
		if(target==null){return;}

		float maxDistanceDelta = speed * Time.deltaTime;
		Vector3 newPosition = Vector3.MoveTowards(this.transform.position, target.transform.position, maxDistanceDelta);
		this.transform.position = newPosition;
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag != "Planet"){ return; }

		Planet planet = collision.gameObject.GetComponent<Planet>();
		if(!planet){ return; } // sanity check


		Instantiate(explosionEffect, transform.position, transform.rotation);
		Destroy(this.gameObject);

		if(collision.contacts.Length==0){ return; } // sanity check
		ContactPoint contact = collision.contacts[0];
		planet.MeteorCollided(contact.point, contact.normal, type);
	}

}
