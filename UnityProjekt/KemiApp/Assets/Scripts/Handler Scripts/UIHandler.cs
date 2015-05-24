using UnityEngine;
using System.Collections;

public class UIHandler : MonoBehaviour {
    // Contains all the functions used by the UI
    public GameObject publicMissionHandler;
    private MissionHandler missionHandler;

    void Start()
    {
        missionHandler = publicMissionHandler.GetComponent<MissionHandler>();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the game!");
    }

    public void NewMission()
    {
        if (missionHandler.MissionCompleted && missionHandler.BoolIndex != missionHandler.missions.Length)
        {
            missionHandler.GetComponent<MissionHandler>().Reset();
        }
    }
}
