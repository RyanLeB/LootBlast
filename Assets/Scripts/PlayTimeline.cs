using UnityEngine;
using UnityEngine.Playables;

public class PlayTimeline : MonoBehaviour
{
    public PlayableDirector playableDirector;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playableDirector.Play();
        }
    }


}
