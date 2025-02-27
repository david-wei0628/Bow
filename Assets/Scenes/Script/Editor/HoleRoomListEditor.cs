using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HoleRoomList))]
//[CustomEditor(typeof(Other))]
public class HoleRoomListEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Other other = (Other)target;
        HoleRoomList RoomList = (HoleRoomList)target;
        for (int i = 0; i < RoomList.RoomPrefab.Count; i++)
        {
            GUILayout.BeginHorizontal(/*GUILayout.MaxWidth(20.0f)*/);
            EditorGUILayout.LabelField(i.ToString(), GUILayout.MaxWidth(20.0f));
            EditorGUILayout.LabelField("Level", GUILayout.MaxWidth(60.0f));
            EditorGUILayout.LabelField(RoomList.RoomLevel[i].ToString(), GUILayout.MaxWidth(20.0f));
            EditorGUILayout.LabelField(RoomList.NextRoomInsa[i].level.ToString(), GUILayout.MaxWidth(100.0f));
            EditorGUILayout.LabelField(RoomList.NextRoomInsa[i].Bool.ToString(), GUILayout.MaxWidth(100.0f));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Room Name:", GUILayout.MaxWidth(150.0f));
            EditorGUILayout.Space();
            EditorGUILayout.ObjectField(obj: RoomList.RoomPrefab[i], objType: typeof(GameObject), true);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("RoomBranch Name:", GUILayout.MaxWidth(150.0f));
            EditorGUILayout.Space();
            //EditorGUILayout.LabelField(RoomList.RoomBranchName[i], GUILayout.MaxWidth(150.0f));
            EditorGUILayout.ObjectField(obj: RoomList.RoomBranch[i], objType: typeof(GameObject), true);
            GUILayout.EndHorizontal();

            if (RoomList.gameObject.name == "RoomScenesType1")
            {
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
            }

            GUILayout.BeginHorizontal();
            GUILayout.Label("--------------------------------------------------------------------");
            GUILayout.EndHorizontal();
        }

        //base.OnInspectorGUI();
    }

}