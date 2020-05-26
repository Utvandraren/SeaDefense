﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resourceText;
    [SerializeField] TextMeshProUGUI resourceProductionText;

    [SerializeField] FloatDataValue resourceData;
    

    // Start is called before the first frame update
    void Start()
    {
        resourceData.ResetData();
        InvokeRepeating("UpdateText", 0f, 2f);
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateText()
    {
        resourceText.text = resourceData.value.ToString();
        resourceProductionText.text = resourceData.resourcePoduction.ToString();

    }
}
