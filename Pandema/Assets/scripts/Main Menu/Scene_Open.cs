using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Open : MonoBehaviour {
    public Animator anim;
    public string NameOfScene;
    public GameObject[] night;
    public GameObject[] morn;
    public GameObject[] sunset;
    private int i = 0;
    private int syshour;

    public void Start()
    {
        syshour = System.DateTime.Now.Hour;
        if(syshour>8 && syshour<14)
        {
            for(i=0;i<morn.Length;i++)
            {
                morn[i].gameObject.SetActive(true);
            }
        }
        if (syshour > 14 && syshour < 19)
        {
            for (i = 0; i < sunset.Length; i++)
            {
                sunset[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (i = 0; i < night.Length; i++)
            {
                night[i].gameObject.SetActive(true);
            }
        }
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
