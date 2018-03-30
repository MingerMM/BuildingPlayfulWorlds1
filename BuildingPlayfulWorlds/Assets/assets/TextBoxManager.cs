using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;

    public TextAsset dialoogwizard;
    public string[] textlines;

    public int currentLine;
    public int endAtLine;

    public bool isActive;

    public bool stopPlayerMovement;

    //PlayerController
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController FPSController;

    // Use this for initialization
    void Start()
    {
        FPSController = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        if (dialoogwizard != null)
        {       //regels splitten met enter
            textlines = (dialoogwizard.text.Split('\n'));
        }
        
        if (endAtLine == 0)
        {       //element gelijk zetten aan regel
            endAtLine = textlines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        theText.text = textlines[currentLine];

        if (Input.GetKeyDown(KeyCode.Mouse0))   //klik naar volgende regel
        {
            currentLine += 1;
        }

        if (currentLine > endAtLine)
        {
            DisableTextBox();
        }
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            FPSController.canMove = false;
            //hello there
            AudioSource textboxSound = GetComponent<AudioSource>();
            textboxSound.Play();
        }
    }
    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        FPSController.canMove = true;
    }

    public void ReloadScript(TextAsset TheText)
    {
     if (TheText != null)
            //nieuw dialoog invullen
        {
            textlines = new string[1];
            textlines = (TheText.text.Split('\n'));
        }
    }
}
