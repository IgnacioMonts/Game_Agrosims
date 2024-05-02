using System.Collections;
using System.Collections.Generic;
using TMPro;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements


public class DecisionesAdm : MonoBehaviour
{
    [SerializeField] private GameObject[] decisiones; //Lista de decisiones a mostrar
    [SerializeField] private contadorMonedas puntaje; //puntaje hasta el momento

    [SerializeField] private TMP_Text[] retro;
    [SerializeField] private GameObject[] tarjetasRetro;

    [SerializeField] private GameObject[] cultivos; //Cultivos

    [SerializeField] private GameObject[] botonesCultivo; //Botones de cultivo

    [SerializeField] private GameObject[] botonesCosecha; //Botones de cosecha

    [SerializeField] private contadorCultivos[] contadorCultivos; 
    [SerializeField] private eventos scriptEventos;
    private GameObject decisionActiva;
    public bool DecisionActiva {get; private set;}
    private int decisionesBuenas = 0;
    private int decisionesIntermedias = 0;
    private int decisionesMalas = 0;
    
    //Función que regresa el número total de decisiones
    public int NumTDecisiones
    {
        get { return decisiones.Length; }
    }
    
    public int DecisionRandom(List<int> decisionesMostradas)
    {
        //Escoger una decision aleatoria
        int randomDecision;
        
        do{
            randomDecision = Random.Range(0, decisiones.Length);
        } while(decisionesMostradas.Contains(randomDecision));
        decisionesMostradas.Add(randomDecision);

        // = Random.Range(0, decisiones.Length);
        decisionActiva = decisiones[randomDecision];

        //Activa la decision (la muestra en el juego)
        decisionActiva.SetActive(true);
        DecisionActiva = true;

        // Pausa el juego
        Time.timeScale = 0;

        return randomDecision;
    }

    ///////////////////////
    ///Decision 1: Lesión //
    ////////////////////////
    public void DecisionBuena1(){
        //Verifica si tiene el suficiente dinero para tomar la decision
        if(puntaje.puntos >= 150){
            //Le resta las 150 monedas al jugador y le suma 1 al contador de decisiones buenas
            puntaje.RestarPuntos(150);
            decisionesBuenas++;

            //Modifica el texto de la tarjeta dandole retro
            retro[0].text = "¡Excelente decisión! El doctor te puso una férula y te recuperaste sin problemas.\nPuedes seguir cultivando lo que quieras.";
            
            Continuar();
            tarjetasRetro[0].SetActive(true);
            StartCoroutine(Retro());
            
        }else{
            //Si no tiene suficiente dinero pero quiere tomar la decisioó, le resta los 60 puntos y le suma 1 al contador de decisiones buenas
            puntaje.RestarPuntos(150);
            decisionesIntermedias++;
            retro[1].text = "No tenías suficiente dinero para la férula, pero decidiste ponertela de todas formas.\nAdministra tu dinero en el futuro.";
            Continuar();
            tarjetasRetro[1].SetActive(true);
            StartCoroutine(Retro());
        }
    }

    public void DecisionMala1(){
        //No le resta nada al jugador pero le suma 1 al contador de decisiones malas
        decisionesMalas++;
        decisionActiva.SetActive(false);
        DecisionActiva = false;
        Time.timeScale = 1;

        retro[2].text = "Decidiste no ponerte la férula y tu pierna empeoró.\nPor esto no podrás moverte por 20 segundos.";
        
        Continuar();
        tarjetasRetro[2].SetActive(true);
        
        StartCoroutine(Retro());
        //Activa una co-rutina que no permite al jugador moverse por 10 segundos
        StartCoroutine(Esperar());
    }

    //Co-rutina Esperar() el jugador no puede mover el jugador por 10 segundos pero el timer sigue corriendo
    IEnumerator Esperar(){
        //Desactiva el movimiento del jugador
        mainManager.Instance.puedeMoverse = false;
        //Espera 20 segundos
        yield return new WaitForSeconds(20);
        //Activa el movimiento del jugador
        mainManager.Instance.puedeMoverse = true;
    }

    ///////////////////////
    /// Decision 2: Plaga //
    ////////////////////////
    public void DecisionBuena2(){
        if(puntaje.puntos >= 100){
            puntaje.RestarPuntos(100);
            decisionesBuenas++;
            retro[0].text = "¡Tú contra la plaga! Después de un arduo trabajo, lograste salvar tus cultivos.\nSigue así.";        
            Debug.Log("Texto cambiado");
            Continuar();
            tarjetasRetro[0].SetActive(true);
            StartCoroutine(Retro());
        }else{
            puntaje.RestarPuntos(100);
            decisionesIntermedias++;
            retro[1].text = "Aunque no tenías suficiente dinero, decidiste usar un método más tradicuonal.\n ¡Y funcionó!";
            Continuar();

            tarjetasRetro[1].SetActive(true);
            StartCoroutine(Retro());
        }
    }

    public void DecisionMala2(){
        decisionesMalas++;
        decisionActiva.SetActive(false);
        DecisionActiva = false;
        Time.timeScale = 1;

        retro[2].text = "Pues la plaga no se fue 'sola' como tú creías y perdiste tus cultivos.\nNo ignores este tipo de situaciones.";
        
        Continuar();
        tarjetasRetro[2].SetActive(true);
        scriptEventos.ActivarElementos(cultivos, false);
        scriptEventos.ActivarTimers(false);
        scriptEventos.ActivarElementos(botonesCosecha, false);
        scriptEventos.ActivarElementos(botonesCultivo, true);

        StartCoroutine(Retro());
    }

    /////////////////
    /// Decisión 3: Se rompió el tractor
    //////////////////
    public void DecisionBuena3(){
        if(puntaje.puntos >= 250){
            puntaje.RestarPuntos(250);
            decisionesBuenas++;
            retro[0].text = "Llamaste a un mecánico y arregló tu tractor muy rápido. Ya no te debes preocupar por que se rompa de nuevo. \nSigue cultivando.";
            Continuar();
            tarjetasRetro[0].SetActive(true);
            StartCoroutine(Retro());
        }else{
            puntaje.RestarPuntos(250);
            decisionesIntermedias++;
            retro[1].text = "No tenías suficiente dinero para pagarle al mecánico, pero tu vecino te ayudó a pagarlo.\nAgradecele a tu vecino buena onda y recuerda administrar tu dinero.";
            Continuar();
            tarjetasRetro[1].SetActive(true);
            StartCoroutine(Retro());
        }
    }

    public void DecisionMala3(){
        decisionesMalas++;
        decisionActiva.SetActive(false);
        DecisionActiva = false;
        Time.timeScale = 1;

        retro[2].text = "Decidiste arreglar el tractor tú mismo y lo rompiste más. Ahora la reparación fue más cara y pagaste $400. \nPara la otra primero hablale al mecánico.";
        puntaje.RestarPuntos(400);

        Continuar();
        tarjetasRetro[2].SetActive(true);
        StartCoroutine(Retro());
    }

    /////////////////
    /// Decisión 4: Electricidad
    //////////////////
    public void DecisionBuena4(){
        decisionesBuenas++;
        retro[0].text = "¡Lo encontraste! El generador que compraste unos años atrás te sirvió y no te quedaste sin luz.";
        
        Continuar();
        tarjetasRetro[0].SetActive(true);
        StartCoroutine(Retro());
    }

    public void DecisionMala4(){
        decisionesMalas++;
        decisionActiva.SetActive(false);
        DecisionActiva = false;
        Time.timeScale = 1;

        retro[2].text = "Te dio flojera buscar el generador que ya tenías. \nAsí que, tuviste que comprar uno nuevo y pagaste $175 por el.";
        puntaje.RestarPuntos(175);

        Continuar();
        tarjetasRetro[2].SetActive(true);
        StartCoroutine(Retro());
    }

    /////////////////
    /// Decisión 5: Inundación
    //////////////////
    
    public void DecisionBuena5(){
        if(puntaje.puntos >= 510){
            puntaje.RestarPuntos(510);
            decisionesBuenas++;
            retro[0].text = "¡Funcionó! El sistema de drenaje que instalaste evitó que tus cultivos se inundaran. \nFue la mejor inversión que hiciste.";
            Continuar();
            tarjetasRetro[0].SetActive(true);
            StartCoroutine(Retro());
        }else{
            puntaje.RestarPuntos(510);
            decisionesIntermedias++;
            retro[1].text = "No tenías suficiente dinero para instalar el sistema de drenaje, pero pediste prestado.\nAhora estás endeudado, pero tus cultivos están a salvo.";
            Continuar();
            tarjetasRetro[1].SetActive(true);
            StartCoroutine(Retro());
        }
    }
    
    public void DecisionMala5(){
        decisionesMalas++;
        decisionActiva.SetActive(false);
        DecisionActiva = false;
        Time.timeScale = 1;

        retro[2].text = "Lamentablemente la tierra no absorbió toda el agua y la parcela de papa está inundada. \nTus cultivos se dañaron y no podrás cultivar papa por 40 segundos.";

        Continuar();
        tarjetasRetro[2].SetActive(true);
        StartCoroutine(Inundacion());
        StartCoroutine(Retro());
    }
    
    //Co-rutina para las consecuencias de la inundacion
    IEnumerator Inundacion(){
        cultivos[3].SetActive(false);
        botonesCultivo[3].SetActive(false);
        botonesCosecha[3].SetActive(false);
        scriptEventos.ActivarTimers(false);
        yield return new WaitForSeconds(40);
        botonesCultivo[3].SetActive(true);
    }

    /////////////////
    /// Decisión 6: Animal
    //////////////////
    
    public void DecisionBuena6(){
        decisionesBuenas++;
        retro[0].text = "¡Que lindo! Cuando fuiste a ahuyentar al conejo te diste cuenta de lo bonito que era y te lo quedaste. \nAhora tienes un conejo mascota.";
        
        Continuar();
        tarjetasRetro[0].SetActive(true);
        StartCoroutine(Retro());
    }

    public void DecisionMala6(){
        decisionesMalas++;
        decisionActiva.SetActive(false);
        DecisionActiva = false;
        Time.timeScale = 1;

        retro[2].text = "Decidiste ignorar al conejo y tiempo después te diste cuenta de que daño tu cultivo de tomate. \nPara la próxima, no ignores a los animales.";

        Continuar();
        tarjetasRetro[2].SetActive(true);
        StartCoroutine(Conejo());
        StartCoroutine(Retro());
    }

    //Co-rutina para las consecuencias de ignorar al conejo
    IEnumerator Conejo(){
        cultivos[2].SetActive(false);
        botonesCultivo[2].SetActive(false);
        botonesCosecha[2].SetActive(false);
        scriptEventos.ActivarTimers(false);
        yield return new WaitForSeconds(30);
        botonesCultivo[2].SetActive(true);
    }

    /////////////////
    /// Decisión 7: Enfermedad
    //////////////////
    public void DecisionBuena7(){
        if(puntaje.puntos >= 50){
            puntaje.RestarPuntos(50);
            decisionesBuenas++;
            retro[0].text = "Fuiste a la farmacia por un antigripal e ibuprofeno. \nDespués de que te los tomaste te sentiste mejor.";
            Continuar();
            tarjetasRetro[0].SetActive(true);
            StartCoroutine(Retro());
        }else{
            puntaje.RestarPuntos(50);
            decisionesIntermedias++;
            retro[1].text = "No tenías suficiente dinero para comprar ambos medicamentos, pero como te conocían en la farmacia, te fiaron. \nRecuerda estar preparado económicamente para situaciones como esta.";
            Continuar();
            tarjetasRetro[1].SetActive(true);
            StartCoroutine(Retro());
        }
    }

    public void DecisionMala7(){
        decisionesIntermedias++;
        decisionActiva.SetActive(false);
        DecisionActiva = false;
        Time.timeScale = 1;

        retro[1].text = "Decidiste tomarte solamente un té de manzanilla. Afortunadamente, con el paso de los días los malestares se fueron. \nAunque no fue la mejor decisión, tu salud es primero.";

        Continuar();
        tarjetasRetro[1].SetActive(true);
        StartCoroutine(Retro());
    }

    /////////////////
    /// Decisión 8: Robo
    //////////////////
    
    public void DecisionBuena8(){
        decisionesBuenas++;
        retro[0].text = "¡La policía llegó! El ladrón fue atrapado y tu salvaste todo lo que estaba en tu almacén.";
        
        Continuar();
        tarjetasRetro[0].SetActive(true);
        StartCoroutine(Retro());
    }

    public void DecisionMala8(){
        decisionesMalas++;
        decisionActiva.SetActive(false);
        DecisionActiva = false;
        Time.timeScale = 1;

        retro[2].text = "¿Eres Batman? No. Por eso no debiste enfrentarte al ladrón, era mucho más fuerte que tú. \nLogró llevarse la mitad de cada uno de tus cultivos almacenados.";
        Continuar();
        tarjetasRetro[2].SetActive(true);
        StartCoroutine(Robo());
        StartCoroutine(Retro());
    }

    //Co-rutina para las consecuencias del robo
    IEnumerator Robo(){
        //Recuperar el valor del contador de cultivos
        foreach(var contador in contadorCultivos){
            int cantidad = contador.puntos;
            contador.RestarPuntos(cantidad / 2);
        }
        yield return new WaitForSeconds(3);
    }

    
    //Co-rutina para la retroalimentación
    IEnumerator Retro(){
        //Espera 10 segundos
        yield return new WaitForSeconds(10);

        //Desactiva la tarjeta de retroalimentacion
        tarjetasRetro[0].SetActive(false);
        tarjetasRetro[1].SetActive(false);
        tarjetasRetro[2].SetActive(false);
    }

    public void Continuar()
    {
        // Desactivar el panel
        if (decisionActiva != null)
        {
            decisionActiva.SetActive(false);
        }
        DecisionActiva = false;

        Time.timeScale = 1;

        //Imprimir en consola el resultado de las decisiones
        Debug.Log("Decisiones buenas: " + decisionesBuenas);
        mainManagerDinero.Instance.decisionesBuenas = decisionesBuenas;
        Debug.Log("Decisiones intermedias: " + decisionesIntermedias);
        mainManagerDinero.Instance.decisionesNeutras = decisionesIntermedias;
        Debug.Log("Decisiones malas: " + decisionesMalas);
        mainManagerDinero.Instance.decisionesMalas = decisionesMalas;
    }
    
}
