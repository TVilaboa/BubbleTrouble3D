using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour {
    public Vector3 direction;

	// Use this for initialization
	void Start () {
        direction = Vector3.left;
        Rigidbody sphere = GetComponent<Rigidbody>();
        sphere.AddForce(direction * 10 , ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") {
            GameObject aux = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            aux.GetComponent<BubbleScript>().direction = Vector3.right;
            Destroy(gameObject);
        }
        
        
    }

    //Spawn two children of less size
    private void spawnChildren() {

    }
}
