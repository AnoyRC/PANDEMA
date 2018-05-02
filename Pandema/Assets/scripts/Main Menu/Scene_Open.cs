using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Open : MonoBehaviour {
    public Animator anim;
    public string NameOfScene;
public void Scene()
    {
        anim.SetBool("1", true);
        StartCoroutine(WAIT());
    }
    public IEnumerator WAIT()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(NameOfScene);
    }
}
