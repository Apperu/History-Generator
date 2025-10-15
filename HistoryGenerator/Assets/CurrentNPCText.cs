using TMPro;
using UnityEngine;

public class CurrentNPCText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TourGuideManager tgm;
    TextMeshProUGUI text;

    void Awake()
    {
        tgm = FindFirstObjectByType<TourGuideManager>();
        if (tgm == null) Debug.LogError("TourGuideManager not found!");

        text = GetComponent<TextMeshProUGUI>();
        if (text == null) Debug.LogError("TextMeshProUGUI not found!");

    }

    // Update is called once per frame
    public void OnEnable()
    {
        text.text = tgm.activeTourGuideIndex.ToString();
    }
}
