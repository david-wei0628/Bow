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

        for (int i = 0; i < RoomList.StartAround.Count; i++)
        {
            EditorGUILayout.LabelField(i.ToString());
            EditorGUILayout.LabelField(RoomList.RoomPrefab[i].tag);
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Room Name:", GUILayout.MaxWidth(150.0f));
            EditorGUILayout.Space();
            //EditorGUILayout.LabelField(RoomList.RoomPrefab[i].gameObject.name, GUILayout.MaxWidth(100.0f));
            EditorGUILayout.ObjectField(obj: RoomList.RoomPrefab[i], objType: typeof(GameObject), true);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("RoomBranch Name:", GUILayout.MaxWidth(150.0f));
            EditorGUILayout.Space();
            //EditorGUILayout.LabelField(RoomList.RoomBranch[i].gameObject.name, GUILayout.MaxWidth(100.0f));
            EditorGUILayout.ObjectField(obj: RoomList.RoomBranch[i], objType: typeof(GameObject), true);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Entrance/Exit");
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("F", GUILayout.MaxWidth(10.0f));
            EditorGUILayout.Toggle(RoomList.StartAround[i].list[0], GUILayout.MaxWidth(20.0f));
            EditorGUILayout.LabelField("B", GUILayout.MaxWidth(10.0f));
            EditorGUILayout.Toggle(RoomList.StartAround[i].list[1], GUILayout.MaxWidth(20.0f));
            EditorGUILayout.LabelField("L", GUILayout.MaxWidth(10.0f));
            EditorGUILayout.Toggle(RoomList.StartAround[i].list[2], GUILayout.MaxWidth(20.0f));
            EditorGUILayout.LabelField("R", GUILayout.MaxWidth(10.0f));
            EditorGUILayout.Toggle(RoomList.StartAround[i].list[3], GUILayout.MaxWidth(20.0f));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("--------------------------------------------------------------------");
            GUILayout.EndHorizontal();
        }

        //base.OnInspectorGUI();
    }

}


