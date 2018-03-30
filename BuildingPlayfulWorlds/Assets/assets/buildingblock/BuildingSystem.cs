using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour {

    [SerializeField]
    private Camera playerCamera;

    private bool buildModeOn = false;
    private bool canBuild = false;

    private BlockSystem bSys;

    [SerializeField]
    private LayerMask buildableSurfacesLayer;

    private Vector3 buildPos;

    private GameObject currentTemplateBlock;

    [SerializeField]
    private GameObject blockTemplatePrefab;
    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private Material templateMaterial;

    private void Start()
    {
        bSys = GetComponent<BlockSystem>();
    }

    private void Update()
    {
        //if you have the wand{ if wand is SetActive = true

        if (Input.GetKeyDown("r"))
        {
            buildModeOn = true;

            if (buildModeOn)
            {
                Cursor.lockState = CursorLockMode.Locked;   //hides cursor/mouse and locks to center screen
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (buildModeOn)
        {
            RaycastHit buildPosHit;

            if (Physics.Raycast(playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out buildPosHit, 10, buildableSurfacesLayer))
            //10 is distance how far away you place block from player, screenpointray will cast/point ray in middle screen
            {
                Vector3 point = buildPosHit.point;
                buildPos = new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z));   //create round position from where raycast hits
                canBuild = true;
            }
            else
            {
                canBuild = false;

                if (currentTemplateBlock != null)
                {
                    Destroy(currentTemplateBlock.gameObject);   //NullReferenceException: Object reference not set to an instance of an object BuildingSystem.Update()(at assets / buildingblock / BuildingSystem.cs:67)
                }
            }
        }

        if (!buildModeOn && currentTemplateBlock != null)
        {
            Destroy(currentTemplateBlock.gameObject);
            canBuild = false;       //makes sure you can't build
        }

        if (canBuild && currentTemplateBlock == null)
        {
            currentTemplateBlock = Instantiate(blockTemplatePrefab, buildPos, Quaternion.identity);   //create template
            currentTemplateBlock.GetComponent<MeshRenderer>().material = templateMaterial;      //get material raycastblock
        }

        if (canBuild && currentTemplateBlock != null)
        {
            currentTemplateBlock.transform.position = buildPos;

            if (Input.GetMouseButtonDown(0))    //clicks left mouse button
            {
                PlaceBlock();
            }
        }
    }

    private void PlaceBlock()
    {
        GameObject newBlock = Instantiate(blockPrefab, buildPos, Quaternion.identity);      //create block
        Block tempBlock = bSys.allBlocks[0];    //from dictionary
        newBlock.name = tempBlock.blockName + "-plant";
        newBlock.GetComponent<MeshRenderer>().material = tempBlock.blockMaterial;   //assign material
    }
}
