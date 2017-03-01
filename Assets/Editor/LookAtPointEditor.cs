using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LookAtPoint))]
[CanEditMultipleObjects]
public class LookAtPointEditor : Editor
{
    SerializedProperty lookAtPoint;
    SerializedProperty password;
    SerializedProperty c;
    void OnEnable()
    {
        lookAtPoint = serializedObject.FindProperty("lookAtPoint");
        password = serializedObject.FindProperty("password");
        c = serializedObject.FindProperty("c");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(lookAtPoint);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(password);
        if(GUILayout.Button("Button"))
        {
            Debug.Log("Button pressed");
        }
        EditorGUILayout.PropertyField(c);
        serializedObject.ApplyModifiedProperties();
    }
}