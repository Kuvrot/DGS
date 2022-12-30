using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public TMPro.TMP_Dropdown quality;
    public TMPro.TMP_Dropdown resolution;
    

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            PlayerPrefs.SetInt("FirstTime", 0);
        }

        if (PlayerPrefs.GetInt("FirstTime") == 1)
        {
            resolution.value = PlayerPrefs.GetInt("Resolution");
            quality.value = PlayerPrefs.GetInt("Quality");
            Apply();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Calling this function means that is not the first time of the user entering in the game
    //This function is called when one of the dropdowns has been altered
    public void Apply()
    {

        PlayerPrefs.SetInt("FirstTime", 1);
        PlayerPrefs.SetInt("Resolution", resolution.value);
        PlayerPrefs.SetInt("Quality", quality.value);

        switch (resolution.value)
        {
            case 0: Screen.SetResolution(1920 , 1080 , true); break;
            case 1: Screen.SetResolution(1600 , 900 , true); break;
            case 2: Screen.SetResolution(1366 , 768 , true); break;

        }

        switch (quality.value)
        {
            case 0: QualitySettings.SetQualityLevel(5) ; break;
            case 1: QualitySettings.SetQualityLevel(3) ; break;
            

        }


    }


}
