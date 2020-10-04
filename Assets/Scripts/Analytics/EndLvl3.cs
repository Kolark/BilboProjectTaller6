using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class EndLvl3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Analytics.CustomEvent("Lvl3Winner");
    }
}
