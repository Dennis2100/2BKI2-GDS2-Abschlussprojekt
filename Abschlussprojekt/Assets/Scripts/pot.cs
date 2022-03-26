using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        anim.SetBool("smash", true);    //Animnation zum Zerstören wird aktiviert
        StartCoroutine(breakCo());      //Methoden aufruf von breakCo
    }

    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(.5f);
        this.gameObject.SetActive(false);   //Der Pot wird deaktiviert
    }
}
