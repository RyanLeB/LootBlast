using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    public Slider sensitivitySlider;
    public FPSController fpsController;

    void Start()
    {
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        
    }

    void OnSensitivityChanged(float value)
    {
        fpsController.lookSpeed = value * 2;        
    }




}

