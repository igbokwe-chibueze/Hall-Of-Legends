using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public List<GameObject> displays = new List<GameObject>();
    int playerSelection;


    // Start is called before the first frame update
    void Start()
    {
        GetPlayerSelection();
        LoadPlayerSelection();
    }

    public void GetPlayerSelection()
    {
        playerSelection = PlayerPrefs.GetInt("DisplayIndex");
    }

    public void LoadPlayerSelection()
    {
       displays[playerSelection].SetActive(true);
    }
}
