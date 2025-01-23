using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockUpdater : MonoBehaviour
{
    // Référence au Slider
    public Slider stock_Slider;


    private void Update()
    {
        Text_Updater ();
     
    }

    // Mise a jour du texte pour le Stock
    public TMP_Text stock_Text; 
    private void Text_Updater (){
        // Récupère le script StockTextUpdater et met à jour le texte   
        stock_Text.text = stock_Slider.value.ToString("F2")+ " / " + stock_Slider.maxValue.ToString();
    }
}