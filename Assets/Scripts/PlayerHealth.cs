using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField]IntDataValue playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth.ResetData();
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown("c"))
        {
            TakeDamage(2);
        }
        #endif
    }

    //Have the player take damage
    public void TakeDamage(int damage)
    {
        playerHealth.value -= damage;
        Debug.Log("PlayerHealth: " + playerHealth.value.ToString());
        if(playerHealth.value <= 0)
        {
            Lose();
        }
    }

    //Show UI panel in UImanager
    void Lose()
    {
        Debug.Log("You LOSE!!!!");
        UIManager._instance.ToogleLoseUI();
    }
}
