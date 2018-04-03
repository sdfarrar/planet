using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class MeteorSpawner : MonoBehaviour {

	public Meteor meteorPrefab;
	public Transform meteorTarget;
	public float spawnDelay = 0.75f;

	private SphereCollider sphereCollider;
	private float spawnRateCountdown;


	void Start () {
		sphereCollider = GetComponent<SphereCollider>();
	}
	
	void Update () {
		spawnRateCountdown -= Time.deltaTime;
		if(spawnRateCountdown<=0f){
			SpawnMeteor();
			spawnRateCountdown = spawnDelay;
		}
	}

	private Meteor SpawnMeteor(){
		if(meteorPrefab==null || meteorTarget==null){ return null; }
		Vector3 position = Random.onUnitSphere * sphereCollider.radius;
		Meteor m = Instantiate(meteorPrefab, position, Quaternion.identity, transform);
		m.target = meteorTarget;
		m.type = (MeteorType)Mathf.Floor(Random.Range(0, 4));
		return m;
	}
}
