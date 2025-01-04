using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerStatsSO))]
public class PlayerStatsEditor : Editor
{
    PlayerStatsSO _statsTarget => target as PlayerStatsSO;

    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        if (GUILayout.Button("Reset Player"))
        {
            _statsTarget.ResetPlayer();
        }
    }
}