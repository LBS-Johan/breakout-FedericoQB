using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public TMP_InputField AmountOfRows;
    public GameObject optionsCanvas;
    public GameObject mainMenuCanvas;
    public Toggle hardcoreMode;

    #region ColorRows
    public GameObject firstRowEmpty;
    public GameObject firstColor;

    public GameObject middleRowEmpty;
    public GameObject middleColor;

    public GameObject lastRowEmpty;
    public GameObject lastColor;

    Vector4 color1 = Color.red;
    Vector4 color2 = Color.blue;
    Vector4 color3 = Color.green;
    #endregion

    private void Update()
    {
        color1 = CheckColorSliders(firstRowEmpty, firstColor);
        color2 = CheckColorSliders(middleRowEmpty, middleColor);
        color3 = CheckColorSliders(lastRowEmpty, lastColor);
    }

    public void OptionsMenuToggle()
    {
        if (optionsCanvas.activeSelf == true)
        {
            optionsCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
        }
        else
        {
            optionsCanvas.SetActive(true);
            mainMenuCanvas.SetActive(false);
        }

    }

    // Applies all of the values in the options menu
    public void ApplyChanges()
    {
        CheckAmountOfRows(AmountOfRows);
        ApplyColorChanges(color1, color2, color3);
        HardCoreMode();
    }

    void CheckAmountOfRows(TMP_InputField number)
    {
        int conversionNumber = 1;

        if (int.TryParse(number.text, out int result))
        {
            conversionNumber = result;

            if (conversionNumber == 1)
            {
                BrickGeneratorScript.limit = 16;
            }
            else if (conversionNumber == 2)
            {
                BrickGeneratorScript.limit = 33;
            }
            else if (conversionNumber == 3)
            {
                BrickGeneratorScript.limit = 50;
            }
            else if (conversionNumber == 4)
            {
                BrickGeneratorScript.limit = 67;
            }
            else if (conversionNumber == 5)
            {
                BrickGeneratorScript.limit = 84;
            }
            else if (conversionNumber == 6)
            {
                BrickGeneratorScript.limit = 101;
            }
            else if (conversionNumber == 7)
            {
                BrickGeneratorScript.limit = 118;
            }
            else if (conversionNumber == 8)
            {
                BrickGeneratorScript.limit = 135;
            }
            else if (conversionNumber == 9)
            {
                BrickGeneratorScript.limit = 152;
            }
            else
            {
                Debug.Log($"Number {conversionNumber} is not available");
            }

            Debug.Log("Applied Rows Change");
        }
        else
        {
            Debug.Log($"Attempted Conversion of {AmountOfRows.text} failed");
        }
    }

    Vector4 CheckColorSliders(GameObject ColorRowEmpty, GameObject Color)
    {
        GameObject childRow1 = ColorRowEmpty.transform.GetChild(0).gameObject;
        GameObject childRow2 = ColorRowEmpty.transform.GetChild(1).gameObject;
        GameObject childRow3 = ColorRowEmpty.transform.GetChild(2).gameObject;

        float value1 = childRow1.GetComponent<Slider>().value;
        float value2 = childRow2.GetComponent<Slider>().value;
        float value3 = childRow3.GetComponent<Slider>().value;

        Vector4 colorVector = new Vector4(value1, value2, value3, 255);
        Color.GetComponent<RawImage>().color = colorVector;

        return colorVector;
    }

    void ApplyColorChanges(Vector4 color1, Vector4 color2, Vector4 color3)
    {
        BrickGeneratorScript.firstRows = color1;
        BrickGeneratorScript.middleRows = color2;
        BrickGeneratorScript.lastRows = color3;
    }

    void HardCoreMode()
    {
        if (hardcoreMode == true)
        {
            PlayerMovementScript.speed = 3f;
            BallScript.speed = 10f;
        }
        else
        {
            PlayerMovementScript.speed = 5f;
            BallScript.speed = 5f;
        }
    }
}
