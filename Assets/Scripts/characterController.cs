using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

  Rigidbody m_Rigidbody;
  public GameObject bullet;
  public float bulletSpeed = 1000f;
  public Transform muzzle;

  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
  }
	
	void Update () {
    Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
    float speed = 3f;
    float inputHorizontal = 0.0f; //横
    float inputVertical = 0.0f;  //前後

/*    if (Input.GetKey(KeyCode.D))
    {
      inputHorizontal = 1f;
    }
    else if (Input.GetKey(KeyCode.A))
    {
      inputHorizontal = -1f;
    }

    if (Input.GetKey(KeyCode.W))
    {
      inputVertical = 1f;
    }
    else if (Input.GetKey(KeyCode.S))
    {
      inputVertical = -1f;
    }*/

    if (Input.GetMouseButtonDown(0))
    {
      Debug.Log("ばぁん");
      shot();
    }

    //Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
    //m_Rigidbody.velocity = moveForward * speed;
  }

  void shot()
  {
    GameObject _bullet = Instantiate(bullet, muzzle.position, muzzle.rotation);
    Rigidbody _bullet_rb = _bullet.GetComponent<Rigidbody>();
    _bullet_rb.AddForce ( bulletSpeed *( muzzle.transform.forward).normalized);
  }
}
