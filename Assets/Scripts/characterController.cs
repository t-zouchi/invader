using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

  Rigidbody m_Rigidbody;

  // Use this for initialization
  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
  }
	
	// Update is called once per frame
	void Update () {
    float speed = 3f;
    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;


    if (Input.GetKey(KeyCode.D))
    {
      x += speed;
    }
    if (Input.GetKey(KeyCode.A))
    {
      x -= speed;
    }
    if (Input.GetKey(KeyCode.W))
    {
      z += speed;
    }
    if (Input.GetKey(KeyCode.S))
    {
      z -= speed;
    }

    m_Rigidbody.velocity = z * transform.forward + y * transform.up + x * transform.right;
  }
}
