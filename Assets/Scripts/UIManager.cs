using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] TextMeshProUGUI resourceText;
    [SerializeField] TextMeshProUGUI resourceProductionText;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] FloatDataValue resourceData;
    [SerializeField] IntDataValue playerHealthData;

    [SerializeField] GameObject losePrompt;
    [SerializeField] GameObject winPrompt;
    [SerializeField] GameObject pausMenu;

    [SerializeField] MainMenu _mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        resourceData.ResetData();
        InvokeRepeating("UpdateText", 0f, 2f);
        UpdateText();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }
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
        bool value = losePrompt.activeSelf;
        losePrompt.SetActive(!value);

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

    //Shows the prompt telling the player he/she Won 
    public void ToogleWinUI()
    {
        bool value = winPrompt.activeSelf;
        winPrompt.SetActive(!value);

        if (!value)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void Pause()
    {
        pausMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
    }
     
}
