using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Open : MonoBehaviour {
    public Animator anim;
    public string NameOfScene;
    private int System_Hour;
    private int i;
    public GameObject morn_objs;
    public GameObject noon_objs;
    public GameObject night_objs;
    public GameObject _Camera;
    public Vector3[] CamPositions;

    private void Start()
    {
        System_Hour = System.DateTime.Now.Hour;
        if (System_Hour >= 4 && System_Hour < 14)
        {
            morn_objs.gameObject.SetActive(true);
            _Camera.transform.position = CamPositions[0];
        }
        else if (System_Hour >= 14 && System_Hour < 19)
        {
            noon_objs.gameObject.SetActive(true);
            _Camera.transform.position = CamPositions[1];
        }
        else
        {
            night_objs.gameObject.SetActive(true);
            _Camera.transform.position = CamPositions[2];
        }

    }
    private void Update()
    {
           
    }

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
