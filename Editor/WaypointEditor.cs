using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    Waypoint _waypointTarget => target as Waypoint;

    void OnSceneGUI()
    {
        if (_waypointTarget.Points.Length == 0)
            return;

        Handles.color = Color.red;
        for (int i = 0; i < _waypointTarget.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            Vector3 currentPoint = _waypointTarget.EntityPos + _waypointTarget.Points[i];
            Vector3 newPos = Handles.FreeMoveHandle(currentPoint, 0.5f, Vector3.one * 0.5f, Handles.SphereHandleCap);

            GUIStyle text = new GUIStyle();
            text.fontStyle = FontStyle.Bold;
            text.fontSize = 16;
            text.normal.textColor = Color.black;
            Vector3 textPos = new Vector3(.2f, -.2f);
            Handles.Label(_waypointTarget.EntityPos + _waypointTarget.Points[i], $"{i + 1}", text);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_waypointTarget, "Move Point");
                _waypointTarget.Points[i] = newPos - _waypointTarget.EntityPos;
            }
        }
    }
}
