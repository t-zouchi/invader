using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour {

  Rigidbody m_Rigidbody;
  int moveflg = 1;
  float x = 0;
  float y = 0;
  float z = 0;
  Vector3 move;
  float attack_distance = 3f;
  float beforeAttack;
 
  // Use this for initialization
  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
    moveflg = enemyMoveController.moveflg;
    moveflg = enemyMoveController.getMoveFlg();
    attack_distance = attack_distance + Random.Range(0f, 99f)/100;
    enemyMoveController.changedTime = Time.time;
    beforeAttack = Time.time;
  }
	
	// Update is called once per frame
	void Update () {
    enemyMoveController.timeCounter(Time.time);
    if (moveflg != enemyMoveController.getMoveFlg()){
      moveForward();
    }

      moveflg = enemyMoveController.getMoveFlg();
		if(moveflg == 1)
    {
      x = 10;
    }else if(moveflg == -1)
    {
      x = -10;
    }

    move = new Vector3(x, 0, 0);
    m_Rigidbody.velocity = transform.right * x;
    if(attack_distance < (Time.time - beforeAttack))
    {
      EnemyAttack();
      beforeAttack = Time.time;
    }
  }

  
  void OnCollisionEnter(Collision collision)
  { 
    //Debug.Log(collision.gameObject.tag == "Bullet");
    if(collision.gameObject.tag == "Bullet")
    {
      Destroy(m_Rigidbody.gameObject);
    }
    if(collision.gameObject.tag == "clearwall")
    {
      if(Time.time != enemyMoveController.changedTime)
      {
        enemyMoveController.changedTime = Time.time;
        enemyMoveController.changeMoveFlg();
        moveflg = enemyMoveController.moveflg;
        moveForward();
        enemyMoveController.setDistance(Time.time);
      }
    }
    if(collision.gameObject.tag == "Field")
    {
      Debug.Log("げーむおーばー");
      SceneManager.LoadScene("title");
    }
  }

  void moveForward()
  {
    z = -1.1f;
    y = -1.1f / 2;
    m_Rigidbody.position = (transform.right * m_Rigidbody.position.x) + (transform.up * m_Rigidbody.position.y + new Vector3(0, y, 0)) + (transform.forward * m_Rigidbody.position.z + new Vector3(0, 0, z));
  }

  void Damage()
  {
    Destroy(gameObject);
  }

  void EnemyAttack()
  {
    GameObject player = GameObject.FindWithTag("Player");
    Debug.Log("こうげきー");
    if (player.transform.position.z > gameObject.transform.position.z)
    {
      if(player.transform.position.z - gameObject.transform.position.z >= 3)
      {
        //攻撃準備OK
      } 
    }
    else
    {
      if(gameObject.transform.position.z - player.transform.position.z >= 3)
      {
        //攻撃準備OK
      }
    }
  }
}
