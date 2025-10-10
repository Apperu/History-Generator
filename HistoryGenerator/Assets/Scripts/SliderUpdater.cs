using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void UpdateText(float num)
    {
        text.text = num.ToString();
    }
}
