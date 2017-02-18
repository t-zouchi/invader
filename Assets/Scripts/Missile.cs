using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : MonoBehaviour {

  public float speed;
  Rigidbody missile;
  public GameObject particle;
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
    if(collision.gameObject.tag =="Field")
    {
      //Instantiate(particle, missile.transform.position, Quaternion.identity);
      //Destroy(particle, 1f);
      Destroy(missile.gameObject);
    }

    if (collision.gameObject.tag == "Bullet")
    {
      Destroy(missile.gameObject);
    }
    
    if (collision.gameObject.tag == "Player")
    {
      SceneManager.LoadScene("title");
    }
  }
}
