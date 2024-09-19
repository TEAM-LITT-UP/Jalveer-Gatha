using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Name of the scene to transition to
    public string sceneName;

    private void OnMouseOver()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Call the method to switch scenes
            SwitchScene(sceneName);
        }
    }

    // Method to switch scenes by name
    private void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
