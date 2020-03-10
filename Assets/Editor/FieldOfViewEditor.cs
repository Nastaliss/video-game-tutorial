using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (DetectDamaged))]


public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        DetectDamaged DetectDmg_script = (DetectDamaged)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(DetectDmg_script.transform.position, Vector3.up, Vector3.forward, 360, DetectDmg_script.viewRadius);
        Vector3 viewAngleA = DetectDmg_script.DirFromAngle(-DetectDmg_script.viewAngle / 2, false);
        Vector3 viewAngleB = DetectDmg_script.DirFromAngle(DetectDmg_script.viewAngle / 2, false);

        Handles.DrawLine(DetectDmg_script.transform.position, DetectDmg_script.transform.position + viewAngleA * DetectDmg_script.viewRadius);
        Handles.DrawLine(DetectDmg_script.transform.position, DetectDmg_script.transform.position + viewAngleB * DetectDmg_script.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleDmg in DetectDmg_script.visibleDmgs)
        {
            Handles.DrawLine(DetectDmg_script.transform.position, visibleDmg.position);
        }

    }
}
