using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Open : MonoBehaviour {
    public Animator anim;
    public string NameOfScene;
    private int System_Hour;
    public bool TurnOnMorning;
   public bool TurnOnAfternoon;
    public bool TurnOnNight;
    public Light Light;
    public Color MorningColor;
    public Vector3 MorningRotation;
    public Color AfternoonColor;
    public Vector3 AfternoonRotation;
    public Color NightColor;
    public Vector3 NightRotation;
    private void Start()
    {
        System_Hour = System.DateTime.Now.Hour;
        if (System_Hour >= 4 && System_Hour < 14)
        {

            Light.color = MorningColor;
            Light.gameObject.transform.eulerAngles = MorningRotation;
            TurnOnMorning = true;
        }
        else if (System_Hour >= 14 && System_Hour < 19)
        {
            Light.color = AfternoonColor;
            Light.gameObject.transform.eulerAngles = AfternoonRotation;
            TurnOnAfternoon = true;
        }
        else
        {
            Light.color = NightColor;
            Light.gameObject.transform.eulerAngles = NightRotation;
            TurnOnNight = true;
        }
        

    }
    private void Update()
    {
        if (TurnOnMorning)
        {
            Light.color = MorningColor;
            Light.gameObject.transform.eulerAngles = MorningRotation;
            TurnOnNight = false;
            TurnOnAfternoon = false;
        }
        else if (TurnOnAfternoon)
        {
            Light.color = AfternoonColor;
            Light.gameObject.transform.eulerAngles = AfternoonRotation;
            TurnOnMorning = false;
            TurnOnNight = false;
        }
        else if (TurnOnNight)
        {
            Light.color = NightColor;
            Light.gameObject.transform.eulerAngles = NightRotation;
            TurnOnAfternoon = false;
            TurnOnMorning = false;
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
