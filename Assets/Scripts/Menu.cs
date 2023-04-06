using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update


    public Slider slider;
  
    public float sliderValue;

    [SerializeField]
    GameObject PanelWelcome;

    [SerializeField]
    GameObject PanelOpciones;

    [SerializeField]
    GameObject PanelPause;


    public void Exit() {

        Application.Quit();
    
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Activa el objeto de panel
            PanelPause.SetActive(true);
        }
    }

    private void Start()
    {

        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;

    }

    public void ChangeSlider(float value) {

        sliderValue = value;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value; 
    }

    public void ActivatePanelWelcome() {

        PanelWelcome.SetActive(true);
        PanelOpciones.SetActive(false);

    }

    public void ActivatePanelPause()
    {
        PanelPause.SetActive(true);
        PanelOpciones.SetActive(false);

    }

    public void DesactivePaneles()
    {
        PanelPause.SetActive(false);
        PanelOpciones.SetActive(false);

    }

    public void ActivatePanelOpcionesGames()
    {

        PanelOpciones.SetActive(true);
        PanelPause.SetActive(false);


    }

    public void ActivatePanelOpcionesWelcome()
    {

        PanelOpciones.SetActive(true);
        PanelPause.SetActive(false);
        PanelWelcome.SetActive(false);

    }

 

    

}
