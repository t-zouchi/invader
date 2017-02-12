using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

  Rigidbody m_Rigidbody;
  int moveflg = 1;
  float x = 0;
  float y = 0;
  float z = 0;
  Vector3 move;
 
  // Use this for initialization
  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
    moveflg = enemyMoveController.moveflg;
  }
	
	// Update is called once per frame
	void Update () {
    if (moveflg != enemyMoveController.moveflg){
      moveForward();
    }

      moveflg = enemyMoveController.moveflg;
		if(moveflg == 1)
    {
      x = 1;
    }else if(moveflg == -1)
    {
      x = -1;
    }

    move = new Vector3(x, 0, 0);
    m_Rigidbody.velocity = transform.right * x;
	}

  
  void OnCollisionEnter(Collision collision)
  { 
    //Debug.Log(collision.gameObject.tag == "Bullet");
    if(collision.gameObject.tag == "Bullet")
    {
      Destroy(m_Rigidbody.gameObject);
    }
    enemyMoveController.moveflg = moveflg * -1;
    moveflg = enemyMoveController.moveflg;
    moveForward();
  }

  void moveForward()
  {
    z = -1.1f;
    y = -1.1f / 2;
    m_Rigidbody.position = (transform.right * m_Rigidbody.position.x) + (transform.up * m_Rigidbody.position.y + new Vector3(0, y, 0)) + (transform.forward * m_Rigidbody.position.z + new Vector3(0, 0, z));
  }
}
