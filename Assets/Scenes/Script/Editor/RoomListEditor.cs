using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomList))]
//[CustomEditor(typeof(Other))]
public class RoomListEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Other other = (Other)target;
        RoomList RoomList = (RoomList)target;


        EditorGUILayout.LabelField("StartAround");
        //EditorGUILayout.LabelField(RoomList.StartAround.Count.ToString());
        for (int i = 0; i < RoomList.StartAround.Count; i++)
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(RoomList.RoomPrefab[i].gameObject.name);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.Toggle(RoomList.StartAround[i].list[0]);
            EditorGUILayout.Toggle(RoomList.StartAround[i].list[1]);
            EditorGUILayout.Toggle(RoomList.StartAround[i].list[2]);
            EditorGUILayout.Toggle(RoomList.StartAround[i].list[3]);
            GUILayout.EndHorizontal();
        }

        //EditorGUILayout.Toggle(other.Exit);
        //for (var i = 0; i < other.Exit.Count; i++)
        //{
        //    EditorGUILayout.Toggle(other.Exit[i][0]);
        //}



        //base.OnInspectorGUI();
    }

}


