using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour{

    [SerializeField] private TMP_Text timertext;
    [SerializeField, Tooltip("Tiempo en segundos") ] private float timerTime;

    [SerializeField] private eventos scriptEventos;

    private bool panelMostrado = false;

    private int minutes, seconds;

    private void Update()
    {

        timerTime -= Time.deltaTime;

        if(timerTime == 0){
            //cargar escena de estadisticas
            SceneManager.LoadScene("Estadisticas");
        }

        if(timerTime <= 590 && !scriptEventos.PanelActivo && !panelMostrado){
            scriptEventos.PanelRandom();
            panelMostrado = true;
        }

        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime - minutes * 60f);

        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}