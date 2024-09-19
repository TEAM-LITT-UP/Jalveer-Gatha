using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class QuestionBoard : MonoBehaviour
{
    // Reference to the GameObject that has the Canvas component
    public GameObject canvasGameObject;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Toggle the active state of the canvas GameObject
            canvasGameObject.SetActive(!canvasGameObject.activeSelf);
        }
    }
}
