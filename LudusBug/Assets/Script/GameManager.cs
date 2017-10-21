using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static bool powerOk = true;
    public static bool canOverSave = true;
    public static int maxSaves = 3;
    [SerializeField]
    public static int maxSavesTmp = 3;






    //Game Design Decisions:
    [SerializeField]
    public static int surplusEnergyOnRespawn;
    [SerializeField]
    public static int WaitTimeAfterRespawnToSaveAgain = 1;

    private void Awake()
    {
        
    }


}
