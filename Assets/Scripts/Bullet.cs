using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

  public float destroyTime = 1;
  public Rigidbody bullet;

	// Use this for initialization
	void Start () {
    //Destroy(GameObject, destroyTime);
    bullet = GetComponent<Rigidbody>();
  }
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnCollisionEnter(Collision collision)
  {
    Debug.Log(collision.gameObject.tag);
    if (collision.gameObject.tag == "Field")
    {
      Destroy(bullet.gameObject);
    }
    if (collision.gameObject.tag == "clearwall")
    {
      Destroy(bullet.gameObject);
    }

  }
}
