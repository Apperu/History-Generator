using UnityEngine;

public class GameManager : MonoBehaviour
{
    ArtifactManager am;
    TourGuideManager tgm;

    private void Awake()
    {
        am = GetComponent<ArtifactManager>();
        tgm = GetComponent<TourGuideManager>();

        am.LoadArtifacts();
    }

    public void Begin()
    {
        am.SelectArtifacts();
        am.GenerateDescriptions();

        // do other things to start the tour guide
    }
}
