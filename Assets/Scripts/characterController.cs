using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterController : MonoBehaviour {

  Rigidbody m_Rigidbody;
  public GameObject bullet;
  public float bulletSpeed = 3000f;
  public Transform muzzle;
  public float beforeShoot = 0;
  public float range = 100;
  RaycastHit raycastHit;
  int bulletLimit = 30;
  int currentBullet = 30;
  int allBullet = 60;
  public Canvas canvas;
  Text bulletText;
  float suicideLimit = 3000;
  float suicidetime = 0;

  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
    foreach (Transform child in canvas.transform)
    {
      if (child.name == "Bullet")
      {
        bulletText = child.gameObject.GetComponent<Text>();
        bulletText.transform.SetParent(canvas.transform, false);
        bulletText.text = bulletLimit + " / " + allBullet;
      } 
    }
  }

  void Update()
  {
    Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
    DebugDrawRay();

    if (Input.GetMouseButtonDown(0))
    {
      if (currentBullet > 0)
      {
        if (Time.time - beforeShoot > 0.3)
        {
          RayShot();
          beforeShoot = Time.time;
        }
        if (beforeShoot == 0)
        {
          RayShot();
          beforeShoot = Time.time;
        }
        currentBullet--;
        bulletText.text = currentBullet + " / " + allBullet;
      }
    }

    if (Input.GetKeyDown(KeyCode.R))
    {
      if (currentBullet == bulletLimit)
        return;
      if (allBullet == 0)
        return;
      if (currentBullet < bulletLimit)
      {
        if (allBullet > bulletLimit)
        {
          int tmp = currentBullet;
          currentBullet = bulletLimit;
          allBullet = allBullet - (bulletLimit - tmp);
        }
        else
        {
          currentBullet = allBullet;
          allBullet = 0;
        }
        bulletText.text = currentBullet + " / " + allBullet;
      }
    }
    if (Input.GetKeyDown(KeyCode.P))
    {
      SceneManager.LoadScene("title");
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
  void addBullt()
  {
    allBullet += 60;
    bulletText.text = currentBullet + " / " + allBullet;
  }
}
