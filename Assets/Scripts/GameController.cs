using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  public GameObject enemy1;
  public GameObject enemy2;
  public GameObject enemy3;

  // Use this for initialization
  void Start () {
    Level_one level_one = new Level_one();
    Dictionary<int, GameObject> enemys = new Dictionary<int, GameObject>();
    enemys.Add(0, enemy1);
    enemys.Add(1, enemy2);
    enemys.Add(2, enemy3);
    setEnemy(level_one.layer, level_one.enemy, enemys);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  //z座標の値、個数、種類
  void setEnemy(int layerNum, int enemyNum, Dictionary<int, GameObject> enemys)
  {
    GameObject _enemy;
    float z = 12f;
    float y = (z - 8f) / 2f;
    float x = -10f;
    for (int i = 0; i < layerNum; i++)
    {
      x = -10f;
      z = 12f + i * 1.1f;
      if (i != 0) {
        y = (z + i * 1.1f - 8f) / 2f;
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
}

public class Level_one
{
  public int layer = 3;
  public int enemy = 6;
}

public class enemyMoveController
{
  public static int moveflg = 1;

  public int getMoveFlg()
  {
    return moveflg;
  }

  public void setMoveFlg()
  {
    moveflg = moveflg * (-1);
  }
}