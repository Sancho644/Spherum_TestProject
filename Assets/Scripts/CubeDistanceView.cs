using System.Globalization;
using TMPro;
using UnityEngine;

public class CubeDistanceView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _valueText;
    
    private float _roundDistance;

    public void SetValueText(float distance)
    {
        _valueText.text = distance.ToString(CultureInfo.InvariantCulture);
    }
}