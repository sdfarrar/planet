using UnityEngine;

public class Planet : MonoBehaviour {

	public float rotationSpeed = 1f;

#if UNITY_EDITOR
	public bool debugCollisions;
	public bool drawCollisionRays;
#endif

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnMouseDrag(){
		float rotX = Input.GetAxis("Mouse X") * rotationSpeed;// * Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y") * rotationSpeed;// * Mathf.Deg2Rad;
		transform.Rotate(Vector3.up, -rotX); // find new "up" based off of previous rotations
		transform.Rotate(Vector3.right, rotY); // likewise
	}

	public void MeteorCollided(Vector3 position, Vector3 normal, MeteorType type){
#if UNITY_EDITOR
		if(debugCollisions){
			Debug.Log("Meteor(" + type + ") collision at: " + position);
		}
		if(drawCollisionRays){
            Debug.DrawRay(position, normal, Color.red, 5f);
		}
#endif
	}
}
