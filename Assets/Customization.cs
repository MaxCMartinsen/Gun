using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{
    public GameObject glock18;

    public GameObject optionMenu;
    public GameObject startMenu;
    public GameObject background;

    // Suppresors
    public GameObject AliminumSup;
    public GameObject WhiteSup;
    public GameObject RedTreeSup;
    public GameObject Sup;

    // Flashlights

    public GameObject OGFlahslight;

    // Scopes

    public GameObject OGScope;

    // Lasers

    //public GameObject OGLaser;


    public bool suppresor = false;
    public bool laser = false;
    public bool scope = false;
    public bool flashlight = false;

    public Button suppresorButton;
    public Button laserButton;
    public Button scopeButton;
    public Button flashlightButton;

    void Start()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        flashlightButton.image.color = Color.red;
        scopeButton.image.color = Color.red;
        laserButton.image.color = Color.red;
        suppresorButton.image.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        if (suppresor)
        {
            suppresorButton.image.color = Color.green;
            Sup.SetActive(true);
        }
        else
        {
            suppresorButton.image.color = Color.red;
            Sup.SetActive(false);
        }

        if (scope)
        {
            scopeButton.image.color = Color.green;
            OGScope.SetActive(true);
        }
        else
        {
            scopeButton.image.color = Color.red;
            OGScope.SetActive(false);
        }

        if (laser)
        {
            laserButton.image.color = Color.green;
            glock18.GetComponent<laserScript>().enabled = true;
        }
        else
        {
            laserButton.image.color = Color.red;
            glock18.GetComponent<laserScript>().enabled = false;
        }

        if (flashlight)
        {
            flashlightButton.image.color = Color.green;
            OGFlahslight.SetActive(true);
        }
        else
        {
            flashlightButton.image.color = Color.red;
            OGFlahslight.SetActive(false);
        }
    }

    public void Suppresor()
    {
        suppresor = !suppresor;
        
    }
    public void Scope()
    {
        scope = !scope;
        
    }
    public void Laser()
    {
        laser = !laser;
        
    }
    public void Flashlight()
    {
        flashlight = !flashlight;
        
    }

    public void PressStart()
    {
        Time.timeScale = 1;
        startMenu.active = false;
        optionMenu.active = false;
        background.active = false;
    }

    public void backPressed()
    {
        startMenu.active = true;
        optionMenu.active = false;
    }

    public void optionPressed()
    {
        startMenu.active = false;
        optionMenu.active = true;
    }
}
