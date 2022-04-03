using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject wasd;
    public GameObject ability;
    public GameObject attack;
    public GameObject interact;
    public GameObject Treant;
    public bool tutorialDone;

    // Start is called before the first frame update
    void Start()
    {
        wasd.SetActive(true);
        ability.SetActive(false);
        attack.SetActive(false);
        interact.SetActive(false);
        Treant.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Updater();
    }

    private void Updater()
    {
        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) && tutorialDone == false)
        {
            wasd.SetActive(false);
            attack.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && wasd.activeInHierarchy == false && tutorialDone == false)
        {
            attack.SetActive(false);
            ability.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Q) && attack.activeInHierarchy == false && tutorialDone == false)
        {
            ability.SetActive(false);
            interact.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Space) && tutorialDone == false)
        {
            interact.SetActive(false);
            Treant.SetActive(true);
            tutorialDone = true;
        }
    }
}
