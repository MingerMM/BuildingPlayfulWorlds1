using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset TheText;

    public int startLine;
    public int endLine;

    public bool destroyWhenActivated;

    public bool requireButtonPress;
    private bool waitForPress;

    public TextBoxManager theTextBox;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();

	}
	
	// Update is called once per frame
	void Update () {
        if (waitForPress && Input.GetKeyDown(KeyCode.Mouse0))
        {
            theTextBox.ReloadScript(TheText);
            //theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            if(requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            theTextBox.ReloadScript(TheText);
            //theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if(destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.name == "FPSController")
        {
            waitForPress = false;
        }
    }
}
