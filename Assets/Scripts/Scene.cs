using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

  public void Update()
  {
    if (Input.GetKey(KeyCode.Space)){
      SceneManager.LoadScene("Main");
    }
  }

  public void start()
  {
    SceneManager.LoadScene("Main");
  }

  public void Title()
  {
    SceneManager.LoadScene("Title");
  }
}
