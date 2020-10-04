using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class DeathEventManager : MonoBehaviour
{
    public int DeathID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Analytics.CustomEvent("PuzzleTimed", new Dictionary<string, object>
        {
            {"Puzzle",DeathID},
        });
    }



}
