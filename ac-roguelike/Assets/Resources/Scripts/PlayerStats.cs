using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats masterScript;

    public static int playerLevel;
    public static int playerGold;
    public static int playerXP;
    public static List<GameObject> inventory;

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
        playerGold = 10;
        playerXP = 0;
    }

    void Start ()
    {
        inventory = null;
    }
	
	void Update ()
    {

    }
}
