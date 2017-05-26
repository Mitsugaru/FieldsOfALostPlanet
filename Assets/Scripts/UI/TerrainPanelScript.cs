using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainPanelScript : MonoBehaviour
{

    [Inject]
    public IRootContext RootContext { get; set; }

    [Inject]
    public IEventManager EventManager { get; set; }

    [Inject]
    public ITerrainSpriteManager TerrainSpriteManager { get; set; }

    public GameObject controlButton;

    public GameObject cropInfoButton;

    public GameObject farmInfoView;

    public GameObject terraformView;

    public Transform terraformContent;

    public GameObject tileButtonPrefab;

    public string[] tileIds;

    private enum ViewMode
    {
        MAIN, TERRAFORM, CROP_INFO
    }

    private ViewMode currentMode = ViewMode.MAIN;

    private Text controlText;

    // Use this for initialization
    void Start()
    {
        farmInfoView.SetActive(false);

        Button control = controlButton.GetComponent<Button>();
        control.onClick.AddListener(ControlClick);

        Button cropInfo = cropInfoButton.GetComponent<Button>();
        cropInfo.onClick.AddListener(CropInfoClick);

        controlText = controlButton.GetComponentInChildren<Text>();

        EventManager.AddListener<ManagerStartedEvent>(HandleManagerStarted);
        EventManager.AddListener<SelectionChangeEvent>(HandleSelectionChange);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ControlClick()
    {
        if(currentMode == ViewMode.MAIN)
        {
            //Change to terraform
            controlText.text = "Back";
            terraformView.SetActive(true);
            farmInfoView.SetActive(false);
            cropInfoButton.SetActive(false);
            currentMode = ViewMode.TERRAFORM;
        }
        else
        {
            //Change back to main
            controlText.text = "Terraform";
            farmInfoView.SetActive(false);
            terraformView.SetActive(false);
            cropInfoButton.SetActive(true);
            currentMode = ViewMode.MAIN;
        }
    }

    private void CropInfoClick()
    {
        if(currentMode == ViewMode.MAIN)
        {
            controlText.text = "Back";
            farmInfoView.SetActive(true);
            terraformView.SetActive(false);
            cropInfoButton.SetActive(false);
            currentMode = ViewMode.CROP_INFO;
        }
    }

    private void HandleManagerStarted(ManagerStartedEvent e)
    {
        if (e.Manager.Equals(TerrainSpriteManager))
        {
            foreach (string tileId in tileIds)
            {
                GameObject tileButton = GameObject.Instantiate(tileButtonPrefab);
                TerrainTilePanelScript tileScript = tileButton.GetComponent<TerrainTilePanelScript>();
                tileScript.Sprite = TerrainSpriteManager.retrieveSprite(tileId);
                tileScript.setTerrainName(tileId);
                RootContext.Inject(tileScript);
                tileButton.transform.SetParent(terraformContent);
            }
            terraformView.SetActive(false);
        }
    }

    private void HandleSelectionChange(SelectionChangeEvent e)
    {
        //Change back to main
        controlText.text = "Terraform";
        farmInfoView.SetActive(false);
        terraformView.SetActive(false);
        cropInfoButton.SetActive(true);
        currentMode = ViewMode.MAIN;
    }
}
