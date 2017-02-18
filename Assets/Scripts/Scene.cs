using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

  public void start()
  {
    SceneManager.LoadScene("Main");
  }

  public void Title()
  {
    SceneManager.LoadScene("Title");
  }
}
