using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

  Rigidbody m_Rigidbody;
  public GameObject bullet;
  public float bulletSpeed = 3000f;
  public Transform muzzle;
  public float beforeShoot = 0;
  public float range = 100;
  RaycastHit raycastHit;

  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
  }
	
	void Update () {
    Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
    DebugDrawRay();
    if (Input.GetMouseButtonDown(0))
    {
      if(Time.time - beforeShoot  > 0.1)
      {
        RayShot();
        beforeShoot = Time.time;
      }
      if(beforeShoot == 0)
      {
        RayShot();
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

  void DebugDrawRay()
  {
    Vector3 cameraCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

    Ray ray = Camera.main.ScreenPointToRay(cameraCenter);

    Debug.DrawRay(ray.origin, ray.direction * range);
  }

  void RayShot()
  {
    Vector3 cameraCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

    Ray ray = Camera.main.ScreenPointToRay(cameraCenter);

    if (Physics.Raycast(ray, out raycastHit, range))
    {
      if (raycastHit.transform.tag == "Enemy")
      {
        raycastHit.transform.SendMessage("Damage");
      }
      if(raycastHit.transform.tag == "missile")
      {
        raycastHit.transform.SendMessage("Damage");
      }
    }
  }
}
