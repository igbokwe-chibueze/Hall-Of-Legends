using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject lever;
    public GameObject[] items;
    public GameObject sound;
    public string tagName;

    bool triggered;
    bool checkTriggerValue;

    Vector3 savedPos;
    float LeverPosX;
    float LeverPosY;
    float LeverPosZ;

    Quaternion savedRot;
    float LeverRotX;
    float LeverRotY;
    float LeverRotZ;

    private void Awake() 
    {
        //ResetPos();
    }


    // Start is called before the first frame update
    void Start()
    {
        GetTriggerValue();
        GetPosition();

        if (LeverPosX == 0 && LeverPosY == 0 && LeverPosZ == 0)
        {
            return;
        }else
            {
                LoadPosition();
            }

        if (checkTriggerValue == true)
        {
            sound.SetActive(true);
        }else
        {
            sound.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == tagName)
        {
            foreach (var item in items)
            {
                item.SetActive(true);
            }

            triggered = true;
            SaveTriggerValue();
            SavePosition();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == tagName)
        {
            foreach (var item in items)
            {
                item.SetActive(false);
            }

            triggered = false;
            SaveTriggerValue();
            SavePosition();
        }
    }

    public void SaveTriggerValue()
    {
        PlayerPrefs.SetInt("Trigger", triggered ? 1: 0);
        PlayerPrefs.Save();
    }

    public void GetTriggerValue()
    {
        checkTriggerValue = PlayerPrefs.GetInt("Trigger") == 1 ? true: false;
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("LeverXpos", lever.transform.position.x);
        PlayerPrefs.SetFloat("LeverYpos", lever.transform.position.y);
        PlayerPrefs.SetFloat("LeverZpos", lever.transform.position.z);

        PlayerPrefs.SetFloat("LeverXrot", lever.transform.eulerAngles.x);
        PlayerPrefs.SetFloat("LeverYrot", lever.transform.eulerAngles.y);
        PlayerPrefs.SetFloat("LeverZrot", lever.transform.eulerAngles.z);

        PlayerPrefs.Save();
    }

    public void GetPosition()
    {
        LeverPosX = PlayerPrefs.GetFloat("LeverXpos");
        LeverPosY = PlayerPrefs.GetFloat("LeverYpos");
        LeverPosZ = PlayerPrefs.GetFloat("LeverZpos");

        savedPos = new Vector3 (LeverPosX, LeverPosY, LeverPosZ);

        LeverRotX = PlayerPrefs.GetFloat("LeverXrot");
        LeverRotY = PlayerPrefs.GetFloat("LeverYrot");
        LeverRotZ = PlayerPrefs.GetFloat("LeverZrot");

        savedRot = Quaternion.Euler (LeverRotX, LeverRotY, LeverRotZ);
    }

    public void LoadPosition()
    {
        lever.transform.position = savedPos;
        lever.transform.rotation = savedRot;
    }

    public void ResetPos()
    {
        PlayerPrefs.SetFloat("LeverXpos", 0);
        PlayerPrefs.SetFloat("LeverYpos", 0);
        PlayerPrefs.SetFloat("LeverZpos", 0);

        PlayerPrefs.SetFloat("LeverXrot", 0);
        PlayerPrefs.SetFloat("LeverYrot", 0);
        PlayerPrefs.SetFloat("LeverZrot", 0);

        PlayerPrefs.SetInt("Trigger", 0);

        PlayerPrefs.Save();
    }
}
