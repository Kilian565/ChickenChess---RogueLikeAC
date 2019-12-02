using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    GameObject platzhalter_1Pref;
    GameObject platzhalter_2Pref;
    GameObject platzhalter_3Pref;
    GameObject platzhalter_4Pref;
    GameObject platzhalter_5Pref;

    private void Awake()
    {
        platzhalter_1Pref = Resources.Load<GameObject>("PlatzhalterPrefabs/Platzhalter1");
        platzhalter_2Pref = Resources.Load<GameObject>("PlatzhalterPrefabs/Platzhalter2");
        platzhalter_3Pref = Resources.Load<GameObject>("PlatzhalterPrefabs/Platzhalter3");
        platzhalter_4Pref = Resources.Load<GameObject>("PlatzhalterPrefabs/Platzhalter4");
        platzhalter_5Pref = Resources.Load<GameObject>("PlatzhalterPrefabs/Platzhalter5");
    }

    void Start ()
    {

	}
	
	void Update ()
    {
		
	}
}
