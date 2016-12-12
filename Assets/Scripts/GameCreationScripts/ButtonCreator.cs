using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class ButtonCreator : MonoBehaviour
{
    [SerializeField]
    ButtonDefinition[] buttons;

    void OnGUI()
    {
        foreach (ButtonDefinition button in buttons)
        {
            button.Draw();
        }
    }



    //////OLD SCRIPT//

    //public string[] numberOfButtons;

    //[Range(0, 900)]
    //public float xPosition;

    //[Range(0, 500)]
    //public float yPosition;

    //[Range(0, 900)]
    //public float width;

    //[Range(0, 500)]
    //public float height;

    //[Range(0, 300)]
    //public float spaceBetween;

    //public GUIStyle style;

    //[SerializeField]
    //int sceneToLoad;

    //void OnGUI()
    //{
    //    if (style.normal.background == null)
    //    {
    //        style = "box";
    //    }
    //    for (int index = 0; index < numberOfButtons.Length; index++)
    //    {
    //        if (GUI.Button(new Rect(xPosition, yPosition + (spaceBetween * index), width, height), numberOfButtons[index], style))
    //        {
    //            Debug.Log("Do the thing");
    //        }
    //    }
    //}
}