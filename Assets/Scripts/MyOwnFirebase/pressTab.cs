using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pressTab : MonoBehaviour
{
    public TMP_InputField[] inputFields;
    int selectedInputField = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (selectedInputField + 1 == inputFields.Length)
            {
                selectedInputField = 0;
            }
            else
            {
                selectedInputField++;
            }
            inputFields[selectedInputField].Select();
        }
    }
}