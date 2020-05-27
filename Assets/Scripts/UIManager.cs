using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resourceText;
    [SerializeField] TextMeshProUGUI resourceProductionText;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] FloatDataValue resourceData;
    [SerializeField] IntDataValue playerHealthData;

    [SerializeField] GameObject LosePrompt;

    public static UIManager _instance;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);        
    }


    // Start is called before the first frame update
    void Start()
    {
        resourceData.ResetData();
        InvokeRepeating("UpdateText", 0f, 2f);
        UpdateText();
    }

    //Update the values for the different texts on the UI
    void UpdateText()
    {
        resourceText.text = resourceData.value.ToString();
        resourceProductionText.text = resourceData.resourcePoduction.ToString();
        healthText.text = playerHealthData.value.ToString();
    }

    //Shows the prompt telling the player he/she lost
    public void ToogleLoseUI()
    {
        bool value = LosePrompt.activeSelf;
        LosePrompt.SetActive(!value);

        if (!value)
        {
            Time.timeScale = 0f;
            Debug.Log("Time Stopped");
        }
        else
        {
            Debug.Log("Time Started");

            Time.timeScale = 1.0f;
        }
    }
     
}
