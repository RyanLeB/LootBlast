using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolumeIcon : MonoBehaviour
{

    [SerializeField] Image volumeOnIcon;
    [SerializeField] Image volumeOffIcon;
    [SerializeField] Slider volumeSlider;
    
    
    void Start()
    {
        volumeOnIcon.enabled = true;
        volumeOffIcon.enabled = false;
    }

    
    void Update()
    {
        if (volumeSlider.value == 0)
        {
            volumeOnIcon.enabled = false;
            volumeOffIcon.enabled = true;
        }
        else
        {
            volumeOnIcon.enabled = true;
            volumeOffIcon.enabled = false;
        }
    }
}
