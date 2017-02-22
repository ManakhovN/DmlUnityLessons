using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuTagChanger : EditorWindow {
	string newTag;


	[MenuItem ("TagsControl/Change All Tags")]
	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(MenuTagChanger));
	}

	void OnGUI () {
		GUILayout.Label ("New Tag", EditorStyles.boldLabel);
		newTag = EditorGUILayout.TextField ("Tag", newTag);
		if (GUILayout.Button ("Change")) {
			AddTag (newTag);
			ChangeTags (Selection.gameObjects);
		}
	}
	private void ChangeTags(GameObject[] objects)
	{
		foreach (GameObject go in objects) {
			go.tag = newTag;
		}
	}
	private void AddTag(string tag)
	{
		SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
		SerializedProperty tagsProp = tagManager.FindProperty("tags");

		SerializedProperty layersProp = tagManager.FindProperty("layers");


		// First check if it is not already present
		bool found = false;
		for (int i = 0; i < tagsProp.arraySize; i++)
		{
			SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
			if (t.stringValue.Equals(tag)) { found = true; break; }
		}

		// if not found, add it
		if (!found)
		{
			tagsProp.InsertArrayElementAtIndex(0);
			SerializedProperty n = tagsProp.GetArrayElementAtIndex(0);
			n.stringValue = tag;
		}
		tagManager.ApplyModifiedProperties();
	}
}
