using LLMUnity;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public struct Artifact
{
    public string name;
    public string description;
    public string prompt;
    // need some sort of storage for info on relationship to other artifacts

    public void GenerateDescription(LLMCharacter descriptionGenerator)
    {
        string prompt = $"Describe the ancient artifact called '{name}'";
        _ = descriptionGenerator.Chat(prompt, OnComplete);
    }

    void OnComplete(string answer)
    {
        description = answer;
        Debug.Log($"Artifact '{name}' has description of:\n'{description}'");
    }
}

public class ArtifactManager : MonoBehaviour
{
    public LLMCharacter descriptionGenerator;

    // you can change to scriptable objects if u want idk

    // map of all artifacts (name -> artifact map)
    public Dictionary<string, Artifact> AllArtifactsMap;

    // list of names of all active artifact
    private List<string> ActiveArtifactNames = new List<string>();

    // how many artifact's history do you want to generate
    public int numArtifacts;


    public void LoadArtifacts()
    {
        // Load artifact info from file here

        // Test Artifacts
        AllArtifactsMap = new Dictionary<string, Artifact>();

        for (int i = 1; i <= 20; i++)
        {
            Artifact artifact = new Artifact
            {
                name = $"test{i}",
                description = ""
            };

            AllArtifactsMap.Add(artifact.name, artifact);
        }

        Debug.Log($"Loaded {AllArtifactsMap.Count} artifacts into the map.");

    }

    // use this to get a specific artifact's data
    public Artifact? GetArtifact(string name)
    {
        if (AllArtifactsMap.TryGetValue(name, out var artifact))
            return artifact;
        Debug.LogWarning($"Artifact '{name}' not found.");
        return null;
    }

    public void UpdateNumArtifacts(int num)
    {
        numArtifacts = num;
    }

    public void SelectArtifacts()
    {
        ActiveArtifactNames.Clear();

        if (AllArtifactsMap.Count == 0)
        {
            Debug.LogWarning("No artifacts in AllArtifactsMap to select from.");
            return;
        }

        // Create a temporary list of all names
        List<string> allNames = new List<string>(AllArtifactsMap.Keys);

        // Shuffle the list using Fisher–Yates
        for (int i = allNames.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (allNames[i], allNames[j]) = (allNames[j], allNames[i]);
        }

        // Pick up to numArtifacts unique names
        int count = Mathf.Min(numArtifacts, allNames.Count);
        for (int i = 0; i < count; i++)
        {
            ActiveArtifactNames.Add(allNames[i]);
        }

        // Debug output
        Debug.Log($"Selected {ActiveArtifactNames.Count} unique artifacts:");

    }

    public void GenerateDescriptions()
    {
        if (descriptionGenerator == null)
        {
            Debug.LogWarning("Description generator (LLMCharacter) not assigned!");
            return;
        }

        foreach (var name in ActiveArtifactNames)
        {
            if (AllArtifactsMap.TryGetValue(name, out var artifact))
            {
                artifact.GenerateDescription(descriptionGenerator);
                AllArtifactsMap[name] = artifact; // store updated copy
            }
            else
            {
                Debug.LogWarning($"Artifact '{name}' not found in map.");
            }
        }
    }
}
