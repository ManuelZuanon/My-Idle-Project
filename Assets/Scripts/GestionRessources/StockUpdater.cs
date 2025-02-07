using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockUpdater : MonoBehaviour
{
    public Slider slider;
    public TMP_Text idea_text;
    
    private float _idea;
    [SerializeField] private float _speed = 1f;
    private float _delay = 0f;

    public float Idea
    {
        get { return _idea; }
        set { _idea = Mathf.Max(0, value); } // Empêcher une valeur négative
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = Mathf.Max(0, value); } // Empêcher les valeurs négatives
    }

    // Update est appelé une fois par frame
    void Update()
    {
        if (slider.value < slider.maxValue)
        {
            // Gestion de la production du slider
            _delay += Time.deltaTime;
            if (_delay >= 0.1f) // 0.1 seconde écoulée pour incrémentation fluide
            {
                slider.value += Speed / 10f;
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
                Idea += Speed * 0.01f; // Ajouter 1 % de la vitesse à "idea"
                int idea_to_text = Mathf.FloorToInt(Idea); // Conversion en entier
                idea_text.text = "Idées \n" + idea_to_text.ToString(); // Mettre à jour le texte
                _delay = 0f; // Réinitialiser le délai
            }
        }
    }
}
