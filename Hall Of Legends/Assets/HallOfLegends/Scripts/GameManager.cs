using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    [Header("PlayerPosition and Rotation")]
    public bool loadLastPos;

    public GameObject[] objectNotToRepeat;
    bool scenePlayed;
    bool checkScenePlayed;

    Vector3 savedPos;
    float PlayerPosX;
    float PlayerPosY;
    float PlayerPosZ;

    Quaternion savedRot;
    float PlayerRotX;
    float PlayerRotY;
    float PlayerRotZ;

    private void Awake() 
    {
        //ResetPos();
    }

    // Start is called before the first frame update
    void Start()
    {

        if (loadLastPos == true)
        {
            GetPosition();

            if (PlayerPosX == 0 && PlayerPosY == 0 && PlayerPosZ == 0)
            {
                return;
            }else
            {
                LoadPosition();
            }

            scenePlayed = true;
            GetScenePlayed();

            SaveScenePlayed();
        }

        if (checkScenePlayed == true)
        {
            foreach (var item in objectNotToRepeat)
            {
                item.SetActive(false);
            }
        }else
        {
            foreach (var item in objectNotToRepeat)
            {
                item.SetActive(true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScenePlayed()
    {
        PlayerPrefs.SetInt("ScenePlayed", scenePlayed ? 1: 0);
        PlayerPrefs.Save();
    }

    public void GetScenePlayed()
    {
       checkScenePlayed = PlayerPrefs.GetInt("ScenePlayed") == 1 ? true: false;
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerXpos", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerYpos", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZpos", player.transform.position.z);

        PlayerPrefs.SetFloat("PlayerXrot", player.transform.eulerAngles.x);
        PlayerPrefs.SetFloat("PlayerYrot", player.transform.eulerAngles.y);
        PlayerPrefs.SetFloat("PlayerZrot", player.transform.eulerAngles.z);

        PlayerPrefs.Save();
    }

    public void GetPosition()
    {
        PlayerPosX = PlayerPrefs.GetFloat("PlayerXpos");
        PlayerPosY = PlayerPrefs.GetFloat("PlayerYpos");
        PlayerPosZ = PlayerPrefs.GetFloat("PlayerZpos");

        savedPos = new Vector3 (PlayerPosX, PlayerPosY, PlayerPosZ);

        PlayerRotX = PlayerPrefs.GetFloat("PlayerXrot");
        PlayerRotY = PlayerPrefs.GetFloat("PlayerYrot");
        PlayerRotZ = PlayerPrefs.GetFloat("PlayerZrot");

        savedRot = Quaternion.Euler (PlayerRotX, PlayerRotY, PlayerRotZ);
    }

    public void LoadPosition()
    {
        player.transform.position = savedPos;
        player.transform.rotation = savedRot;
    }

    //Called on button press.
    public void SetDisplayIndex(int index)
    {
        int displayIndex = index;

        PlayerPrefs.SetInt("DisplayIndex", displayIndex);

        PlayerPrefs.Save();
    }

    public void ResetPos()
    {
        PlayerPrefs.SetFloat("PlayerXpos", 0);
        PlayerPrefs.SetFloat("PlayerYpos", 0);
        PlayerPrefs.SetFloat("PlayerZpos", 0);

        PlayerPrefs.SetFloat("PlayerXrot", 0);
        PlayerPrefs.SetFloat("PlayerYrot", 0);
        PlayerPrefs.SetFloat("PlayerZrot", 0);

        PlayerPrefs.Save();
    }
}
