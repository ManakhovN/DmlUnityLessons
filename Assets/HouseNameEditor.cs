using UnityEngine;
using UnityEditor;


[CanEditMultipleObjects]
public class HouseNameEditor : EditorWindow {

    private string nameHouse;

    [MenuItem("Change Name/Change")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(HouseNameEditor));
    }

    void OnGUI() {

        EditorGUILayout.LabelField("Write Name House");
        nameHouse = EditorGUILayout.TextField("Name", nameHouse);
        if (GUILayout.Button("Save House Name"))
        {
            ChangeName(Selection.gameObjects, nameHouse);
        }
    }

    private void ChangeName(GameObject[] objects, string name)
    {
        foreach (GameObject go in objects)
        {
            go.name = name;
        }
    }
}
