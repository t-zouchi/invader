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
  float attack_distance = 8f;
  float beforeAttack;
  public GameObject enemyMissile;
 
  // Use this for initialization
  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
    moveflg = enemyMoveController.moveflg;
    moveflg = enemyMoveController.getMoveFlg();
    attack_distance = attack_distance + Random.Range(5, 25f);
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
    if (player.transform.position.z > gameObject.transform.position.z)
    {
      //Debug.Log("後ろにいる!!");
      if (player.transform.position.z - gameObject.transform.position.z >= 20)
      {
        //前に攻撃準備OK
        //Debug.Log("後ろ範囲外");
        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 3f);
      }
    }
    else
    {
      //前にいる
      if(gameObject.transform.position.z - player.transform.position.z >= 20)
      {
        //攻撃準備OK
        //前に攻撃準備OK
        //Debug.Log("前範囲外");
        Vector3 enemyPosition = gameObject.transform.position;
        enemyPosition.z = enemyPosition.z - 3f;
        Debug.Log("Gameobject x :" + gameObject.transform.position.x + " y : " + gameObject.transform.position.y + "z : " + gameObject.transform.position.z);
        Debug.Log("missileTransform x :" + enemyPosition.x + " y : " + enemyPosition.y + "z : " + enemyPosition.z);
        Instantiate(enemyMissile, enemyPosition, transform.rotation);
      }
      else
      {
        //Debug.Log("前範囲内");
      }
    }
  }
}
