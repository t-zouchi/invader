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
    if (Input.GetMouseButtonDown(0))
    {
      Debug.Log("ばぁん");
      shot();
    }

  }

  void shot()
  {
    GameObject _bullet = Instantiate(bullet, muzzle.position, muzzle.rotation);
    Rigidbody _bullet_rb = _bullet.GetComponent<Rigidbody>();
    _bullet_rb.AddForce ( bulletSpeed *( muzzle.transform.forward).normalized);
  }
}
