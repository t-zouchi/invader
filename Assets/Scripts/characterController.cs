using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

  Rigidbody m_Rigidbody;
  public GameObject bullet;
  public float bulletSpeed = 3000f;
  public Transform muzzle;
  public float beforeShoot = 0;
  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
  }
	
	void Update () {
    Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
    if (Input.GetMouseButton(0))
    {
      if(Time.time - beforeShoot  > 0.1)
      {
        shot();
        beforeShoot = Time.time;
      }
      if(beforeShoot == 0)
      {
        shot();
        beforeShoot = Time.time;
      }
    }
  }

  void shot()
  {
    GameObject _bullet = Instantiate(bullet, muzzle.position, muzzle.rotation);
    Rigidbody _bullet_rb = _bullet.GetComponent<Rigidbody>();
    _bullet_rb.AddForce ( bulletSpeed *( muzzle.transform.forward).normalized);
    Destroy(_bullet, 3f);
  }
}
