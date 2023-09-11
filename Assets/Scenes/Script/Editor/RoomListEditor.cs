using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomList))]
public class RoomListEditor : Editor
{
	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		Show(serializedObject.FindProperty("RoomPrefab"));

		serializedObject.ApplyModifiedProperties();
	}

	public static void Show(SerializedProperty list)
	{
		EditorGUILayout.PropertyField(list);
		if (list.isExpanded)
		{
			for (int i = 0; i < list.arraySize; i++)
			{
				EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
			}
		}
		EditorGUI.indentLevel -= 1;
	}
}
