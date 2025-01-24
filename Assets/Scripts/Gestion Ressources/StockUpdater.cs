using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockUpdater : MonoBehaviour
{
    public Slider slider;
    public TMP_Text idea_text;
    public float idea;
    public float speed = 1f;

    private float _delay = 0f;

    // Update is called once per frame
    void Update()
    {
 if (slider.value < slider.maxValue)
        {
            // Gestion de la production du slider
            _delay += Time.deltaTime;
            if (_delay >= 0.1f) // 0.1 seconde écoulée pour incrémentation fluide
            {
                slider.value += speed / 10f;
                slider.value = Mathf.Min(slider.value, slider.maxValue); // Ne pas dépasser la limite
                _delay = 0f;
            }
        }
        else
        {
            // Ajouter 1 % de la vitesse aux idées toutes les secondes
            _delay += Time.deltaTime;
            if (_delay >= 1f) // 1 seconde écoulée
            {
                idea += speed * 0.01f; // Ajouter 1 % de la vitesse à "idea"
                int idea_to_text = Mathf.FloorToInt(idea); // Conversion en entier
                idea_text.text = idea_to_text.ToString(); // Mettre à jour le texte
                _delay = 0f; // Réinitialiser le délai
            }
        }       
    }
}
