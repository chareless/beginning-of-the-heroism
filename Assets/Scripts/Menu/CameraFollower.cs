using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject FRogue;
    public GameObject FWizard;
    public GameObject FArcher;
    public GameObject FKnight;
    public GameObject Cam;
    public static float x;
    public static float y;
    public static float z;
    void Update()
    {
        if(Status.playerClass=="Rogue")
        {
            Cam.transform.position = new Vector3(FRogue.transform.position.x, FRogue.transform.position.y, Cam.transform.position.z);
        }
        else if(Status.playerClass=="Knight")
        {
            Cam.transform.position = new Vector3(FKnight.transform.position.x, FKnight.transform.position.y, Cam.transform.position.z);
        }
        else if(Status.playerClass=="Wizard")
        {
            Cam.transform.position = new Vector3(FWizard.transform.position.x, FWizard.transform.position.y, Cam.transform.position.z);
        }
        else if(Status.playerClass=="Archer")
        {
            Cam.transform.position = new Vector3(FArcher.transform.position.x, FArcher.transform.position.y, Cam.transform.position.z);
        }
    }
}
