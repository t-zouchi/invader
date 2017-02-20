using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  public GameObject enemy1;
  public GameObject enemy2;
  public GameObject enemy3;
  public GameObject missile;
  Dictionary<int, GameObject> enemys = new Dictionary<int, GameObject>();

  Level level = new Level();
  float attacktime = 0;

  // Use this for initialization
  void Start () {
    attacktime = Time.time;
    enemys.Add(0, enemy1);
    enemys.Add(1, enemy2);
    enemys.Add(2, enemy3);
    setEnemy(level.getLayer(), level.getEnemy(), enemys);
	}
	
	// Update is called once per frame
	void Update () {
    checkEnemy();
    if(Time.time - attacktime > 3)
    {
      missileGenerator(attacktime);
      attacktime = Time.time;
    }
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

  public void checkEnemy()
  {
    GameObject[] tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
    if (tagObjects.Length == 0)
    {
      level.levelup();
      setEnemy(level.getLayer(), level.getEnemy(), enemys);

      if(level.getStage() == 20)
      {
        Debug.Log("すごーい");
      }
    }
  }

  public void missileGenerator(float attackTime)
  {
    float missile_x = Random.Range(-70, 70);
    float missile_y = Random.Range(20, 40);
    float missile_z = Random.Range(-70, 70);
 
    transform.position = new Vector3(missile_x, missile_y, missile_z);
    Instantiate(missile, transform.position, transform.rotation);  
  }
}

public class Level
{
  public int layer = 4;
  public int enemy = 8;
  public int stage = 1;

  public void levelup()
  {
    if (this.stage % 4 == 0)
    {
      this.layer++;
    }
    if(this.stage % 3 == 0)
    {
      this.enemy++;
      if(this.enemy >= 12 ){
        this.enemy = 12;
      }
    }
    this.stage++;
  }
  public int getLayer()
  {
    return this.layer;
  }

  public int getEnemy()
  {
    return this.enemy;
  }

  public void nextStage()
  {
    this.stage++;
  }

  public int getStage()
  {
    return this.stage;
  }
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
    if(currentTime - distance >= 3.5)
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
    this.y = Random.Range(8f, 18f);
    this.z = Random.Range(-30f, 30f);
  }
}