using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class mcqScript : MonoBehaviour
{
    // Start is called before the first frame update
    public NPCConversation mcqconversation;

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(mcqconversation);
        }
    }
}
