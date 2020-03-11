using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    static PanelManager _instance;
    public static PanelManager Instance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PanelManager>();
            }
            return _instance;
        }
    }

    public GameObject WelcomePanel;
    public GameObject LevelsPanel;
    public GameObject ParametersPanel;


    //parameters menu
    private Text SliderSoundPercentText;
    private Slider SliderSound;

    private void GoToLevels(){
        WelcomePanel.SetActive(false); // false to hide, true to show
        LevelsPanel.SetActive(true);
        ParametersPanel.SetActive(false);
    }
    private void GoToWelcome(){
        LevelsPanel.SetActive(false); // false to hide, true to show
        ParametersPanel.SetActive(false);
        WelcomePanel.SetActive(true);
    }
    private void GoToParameters(){
        LevelsPanel.SetActive(false); // false to hide, true to show
        ParametersPanel.SetActive(true);
        WelcomePanel.SetActive(false);


        // Animator a;
        // a.SetTrigger("sitDown");
    }   

    public void OnReturnLevels(){
        GoToWelcome();
    }
    public void OnPlayWelcome(){
        GoToLevels();
    }
    public void OnReturnParameters(){
        GoToWelcome();
    }
    public void OnParametersWelcome(){
        GoToParameters();
        SliderSoundPercentText = GameObject.Find("TextPercentSound").GetComponent<Text>();
        SliderSound = GameObject.Find("SliderSound").GetComponent<Slider>();

    }
    public void UpdateNumberTextPercentSound(){
        SliderSoundPercentText.text=SliderSound.value.ToString()+"%";
        UpdateVolume();
    }

    private void UpdateVolume(){
        GameObject.Find("BackMusic").GetComponent<AudioSource>().volume=SliderSound.value/100;
    }
    
    public void ButtonQuit(){
        #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
    }

    public void StartLvl1(){
        //start lvl1 -> scene
         SceneManager.LoadScene("MainScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelsPanel.SetActive(false); // false to hide, true to show
        WelcomePanel.SetActive(true);
        ParametersPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
