using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
