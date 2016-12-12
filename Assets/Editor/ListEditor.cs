using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[Flags]
public enum EditorListOption
{
    None = 0,
    ListSize = 1, //Removes "number of buttons"
    ListLabel = 2, //Removes "size"
    ElementLabels = 4, //Only shows element labels
    Default = ListSize | ListLabel | ElementLabels,
    NoElementLabels = ListSize | ListLabel
}

public static class ListEditor
{
    public static void Show (SerializedProperty list, EditorListOption options = EditorListOption.Default)
    {
        bool showListLabel = (options & EditorListOption.ListLabel) != 0,
             showListSize = (options & EditorListOption.ListSize) != 0;

        if (showListLabel)
        {
            EditorGUILayout.PropertyField(list);
            EditorGUI.indentLevel += 1;
        }

        if (!showListLabel || list.isExpanded)
        {
            if (showListSize)
            {
                EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
            }

            ShowElements(list, options);

            if (showListLabel)
            {
                EditorGUI.indentLevel -= 1;
            }
        }
    }

    private static void ShowElements (SerializedProperty list, EditorListOption options)
    {
        bool showElementLabels = (options & EditorListOption.ElementLabels) != 0;

        for (int index = 0; index < list.arraySize; index++)
        {
            if (showElementLabels)
            {
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(index));
            }
            else
            {
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(index), GUIContent.none);
            }
        }
    }


}
