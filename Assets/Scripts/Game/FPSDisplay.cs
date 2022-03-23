using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public static int frame;
    public static float fpsTimer = 0f;
    public static float pollingTime = 1f;
    public Text fpsText;
    void Update()
    {
        fpsTimer += Time.deltaTime;
        frame++;
        if (fpsTimer >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frame / fpsTimer);
            fpsText.text = frameRate.ToString() + " FPS";
            fpsTimer -= pollingTime;
            frame = 0;
        }
    }
}
