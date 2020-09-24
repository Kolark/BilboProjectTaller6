using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
[CustomEditor(typeof(TimeOBJ))]
public class TimeObjEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TimeOBJ obj = (TimeOBJ)target;
        if (GUILayout.Button("Pasado"))
        {
            obj.CambiarTiempo(0, RigidbodyType2D.Static, true, false);
        }
        if (GUILayout.Button("Presente"))
        {
            obj.CambiarTiempo(1, RigidbodyType2D.Dynamic, false, true);
        }
        if (GUILayout.Button("Futuro"))
        {
            obj.CambiarTiempo(2, RigidbodyType2D.Static, true, false);
        }
    }
}
#endif