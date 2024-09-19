using UnityEngine;
using UnityEngine.Playables; // Needed for PlayableDirector
using UnityEngine.SceneManagement;

public class introTransition : MonoBehaviour
{
    public PlayableDirector playableDirector; // Reference to the PlayableDirector
    public string sceneName;                  // The name of the scene to switch to

    private void Start()
    {
        // Register for the PlayableDirector's "stopped" event
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        // Check if the stopped director is the one we're interested in
        if (director == playableDirector)
        {
            // Switch to the specified scene
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnDestroy()
    {
        // Unregister the event when the object is destroyed to prevent memory leaks
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnPlayableDirectorStopped;
        }
    }
}
