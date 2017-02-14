﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  public GameObject enemy1;
  public GameObject enemy2;
  public GameObject enemy3;
  Dictionary<int, GameObject> enemys = new Dictionary<int, GameObject>();

  // Use this for initialization
  void Start () {
    Level_one level_one = new Level_one();
    enemys.Add(0, enemy1);
    enemys.Add(1, enemy2);
    enemys.Add(2, enemy3);
    setEnemy(level_one.layer, level_one.enemy, enemys);
	}
	
	// Update is called once per frame
	void Update () {
    checkEnemy();
	}

  //z座標の値、個数、種類
  public void setEnemy(int layerNum, int enemyNum, Dictionary<int, GameObject> enemys)
  {
    GameObject _enemy;
    DefineEnemys defineEnemys = new DefineEnemys();
    defineEnemys.generate();
    float z = defineEnemys.z;
    float y = defineEnemys.y + Mathf.Abs(z / 2);
    float x = defineEnemys.x;
    for (int i = 0; i < layerNum; i++)
    {
      x = defineEnemys.x;
      z = defineEnemys.z + i * 2f;
      if (i != 0) {
        y = y + 2f;
      }
      for(int j = 0; j < enemyNum; j++)
      {
        x = x + 2f;
        transform.position = new Vector3(x, y, z);
        _enemy = enemys[(i + 1) % 3];
        Instantiate(_enemy, transform.position, transform.rotation);
      }
    }
  }

  private void checkEnemy()
  {
    Level_one level_one = new Level_one();
    GameObject[] tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
    if (tagObjects.Length == 0)
    {
      setEnemy(level_one.layer, level_one.enemy, enemys);
    }
  }
}

public class Level_one
{
  public int layer = 4;
  public int enemy = 8;
}

public class enemyMoveController
{
  public static int moveflg = 1;
  public static float changedTime;
  public static float distance = 0;
  public static int getMoveFlg()
  {
    return moveflg;
  }

  public static void changeMoveFlg()
  {
    moveflg = moveflg * (-1);
  }

  public static void timeCounter(float currentTime)
  {
    if(currentTime - distance >= 5)
    {
      setDistance(currentTime);
      changeMoveFlg();
    }
  }

  public static void setDistance(float currentTime)
  {
    distance = currentTime;
  }
}

public class DefineEnemys
{
  public float x = -10f;
  public float y = 10f;
  public float z = 20f;

  public void generate()
  {
    this.x = Random.Range(-90f, 80f);
    this.y = Random.Range(10f, 25f);
    this.z = Random.Range(-30f, 30f);
  }
}