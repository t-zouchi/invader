using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

  public float speed;
  Rigidbody missile;
  // Use this for initialization
  void Start () {
		missile = GetComponent<Rigidbody>();
    transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
    missile.AddForce(speed * (transform.forward).normalized);
  }
	
	// Update is called once per frame
	void Update () {
    missile.AddForce(speed * (transform.forward).normalized);
  }

  void OnCollisionEnter(Collision collision)
  {
    Debug.Log(collision.gameObject.tag);
  }
}
