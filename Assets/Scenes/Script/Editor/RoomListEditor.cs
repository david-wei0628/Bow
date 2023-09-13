using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(RoomList))]
[CustomEditor(typeof(Other))]
public class RoomListEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Other other = (Other)target;
        //RoomList RoomList = (RoomList)target;

        GUILayout.BeginHorizontal();
        //EditorGUILayout.LabelField("StartAround");
        //for (int i = 0; i < RoomList.StartAround.Count; i++)
        //{
        //    EditorGUILayout.Toggle(RoomList.StartAround[i]);
        //}
        //EditorGUILayout.Toggle(other.Exit);
        for (var i = 0; i < other.Exit.Count; i++)
        {
            EditorGUILayout.Toggle(other.Exit[i][0]);
            EditorGUILayout.Toggle(other.Exit[i][1]);
            EditorGUILayout.Toggle(other.Exit[i][2]);
            EditorGUILayout.Toggle(other.Exit[i][3]);
        }

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
      
}


