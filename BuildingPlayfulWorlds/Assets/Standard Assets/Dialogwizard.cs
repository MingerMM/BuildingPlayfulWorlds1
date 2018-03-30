using UnityEngine;
using System.Collections;


public class dialogwizard2 : MonoBehaviour
    {
        public TextAsset dialoogwizard;
        public string[] textlines;


        // Use this for initialization
        void Start()
        {
            (if dialoogwizard != null)
            {
                textlines = (dialoogwizard.text.Split('/n'));
            }
        }

    }
