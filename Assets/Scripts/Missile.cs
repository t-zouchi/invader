﻿using System.Collections;
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
      GameObject expl = Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
      Destroy(missile.gameObject);
      Destroy(expl, 1f);
    }

    if (collision.gameObject.tag == "Bullet")
    {
      GameObject expl = Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
      Destroy(missile.gameObject);
      Destroy(expl, 1f);
    }
    
    if (collision.gameObject.tag == "Player")
    {
      SceneManager.LoadScene("title");
    }

    if(collision.gameObject.tag == "Enemy")
    {
      GameObject expl = Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
      Destroy(missile.gameObject);
      Destroy(expl, 1f);
    }
  }
  void Damage()
  {
    GameObject expl = Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
    Destroy(gameObject);
    Destroy(expl, 1f);
  }
}
