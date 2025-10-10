using LLMUnity;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Artifacts : MonoBehaviour
{
    public LLMCharacter descriptionGenerator;

    public int[] numArtifactOptions;

    // you can change to scriptable objects if u want idk
    public struct Artifact
    {
        string description;
        
        // some sort of storage for info on relationship to other artifacts
        //HashSet<string> relatedArtifacts = new HashSet<string>();

        void GenerateDescription()
        {

        }
    }

    // list of all artifacts
    public List<Artifact> artifacts;

    // name -> artifact map
    private Dictionary<string, Artifact> artifactMap;

    // use this to get a specific artifact's data
    public Artifact? GetArtifact(string name)
    {
        if (artifactMap.TryGetValue(name, out var artifact))
            return artifact;
        Debug.LogWarning($"Artifact '{name}' not found.");
        return null;
    }

    // how many artifact's history do you want to generate
    public int numArtifacts;
    public void UpdateNumArtifacts(int num)
    {
        numArtifacts = numArtifactOptions[num];
    }

    public void SelectArtifacts()
    {

    }
}
