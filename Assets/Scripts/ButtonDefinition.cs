using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ButtonDefinition
{
    [Range(0, 1000)]
    public float xPosition;

    [Range(0, 500)]
    public float yPosition;

    [Range(0, 900)]
    public float width;

    [Range(0, 500)]
    public float height;

    [SerializeField]
    private int sceneToLoad;

    [SerializeField]
    private string title;

    public GUIStyle style;

    public void Draw()
    {
        if (style.normal.background == null)
        {
            style = "box";
        }

        if (GUI.Button(new Rect(xPosition, yPosition, width, height), title, style))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
