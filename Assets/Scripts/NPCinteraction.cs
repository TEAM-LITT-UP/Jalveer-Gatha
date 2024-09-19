using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCInteraction : MonoBehaviour
{
    // Reference to the NPC conversation
    public NPCConversation npcconversation;

    // Method called when the mouse is over the GameObject
    private void OnMouseOver()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Start the conversation
            ConversationManager.Instance.StartConversation(npcconversation);
        }
    }
}
