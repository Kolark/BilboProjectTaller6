using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PuzzleTimingManager : MonoBehaviour
{
    public int PuzzleID;
    private int currentTime = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Analytics.CustomEvent("PuzzleTimed", new Dictionary<string, object>
        {
            {"Puzzle",PuzzleID},
            {"Timed",currentTime}
        });
    }

    private void Update()
    {
        currentTime += (int)Time.deltaTime;
    }

}
