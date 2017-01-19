﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

  Rigidbody m_Rigidbody;
  int moveflg = 1;
  float x = 0;
  Vector3 move;
 
  // Use this for initialization
  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
    moveflg = enemyMoveController.moveflg;
  }
	
	// Update is called once per frame
	void Update () {
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
    enemyMoveController.moveflg = moveflg * -1;
    moveflg = enemyMoveController.moveflg;
  }
}
