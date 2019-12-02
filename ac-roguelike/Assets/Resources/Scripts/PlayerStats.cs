using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats masterScript;
    //string filename = "PlayerStats.txt";
    //string path;


    public static int playerLevel;
    public static int playerGold;
    public static int playerXP;
    public static List<GameObject> chars;

    private void Awake()
    {
        if (masterScript == null)
        {
            masterScript = this.GetComponent<PlayerStats>();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        playerLevel = 1;
        playerGold = 2;
        playerXP = 0;
    }

    void Start ()
    {
        //path = Path.Combine(Application.dataPath, filename);
    }
	
	void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    SaveCharakter();
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    LoadCharakter();
        //}
    }

    //void SaveCharakter()
    //{
    //    string saveGameContent = JsonUtility.ToJson(charakters[0].GetComponent<Charakter>().GetData());
    //    File.WriteAllText(path, saveGameContent);
    //    Debug.Log("Saving As: " + Charakter.xPosition + " " + Charakter.zPosition + " " + Charakter.yRotation);
    //}

    //void LoadCharakter()
    //{
    //    Destroy(charakters[0]);
    //    SaveGame.isAlive = false;
    //    charakters[0] = Instantiate(charakterPrefab);

    //    string fileContent;
    //    fileContent = File.ReadAllText(path);
    //    charakters[0].GetComponent<Charakter>().SetData(JsonUtility.FromJson<CharakterData>(fileContent));
    //    Charakter.SetPosition();
    //    SaveGame.isAlive = true;
    //    Debug.Log("Loaded As: " + Charakter.xPosition + " " + Charakter.zPosition + " " + Charakter.yRotation);
    //}
}
