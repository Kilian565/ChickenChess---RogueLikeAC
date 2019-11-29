using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int playerLevel;
    public static int playerGold;
    public static int playerXP;
    public static List<GameObject> chars;

    private void Awake()
    {
        playerLevel = 1;
        playerGold = 2;
        playerXP = 0;
    }

    void Start ()
    {

	}
	
	void Update ()
    {
		
	}
}
