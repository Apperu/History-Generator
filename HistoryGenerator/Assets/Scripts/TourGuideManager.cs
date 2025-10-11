using LLMUnity;
using UnityEngine;

public class TourGuideManager : MonoBehaviour
{
    ArtifactManager am;
    LLMCharacter activeTourGuideLLMCharacter;


    public GameObject[] tourGuides;
    public GameObject activeTourGuide;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        am = GetComponent<ArtifactManager>();
    }

    private void Start()
    {
        activeTourGuideLLMCharacter = activeTourGuide.GetComponent<LLMCharacter>();
    }

    public void UpdateActiveTourGuide(int index)
    {
        activeTourGuide = tourGuides[index];
        activeTourGuideLLMCharacter = activeTourGuide.GetComponent<LLMCharacter>();
    }

    public void DescribeArtifact(string name)
    {
        Artifact? a = am.GetArtifact(name);
        if (a != null)
        {
            string prompt = $"Describe the ancient artifact called '{name}'";
            _ = activeTourGuideLLMCharacter.Chat(prompt, OnReply, OnComplete);
        }
    }

    // For every token/word the LLM is saying, do this
    private void OnReply(string reply)
    {
        //tour guide update dialogue box and other stuff u want
    }

    // After done saying stuff, do this
    private void OnComplete()
    {
        //stuff u want done after LLM is done talking
    }  
}
