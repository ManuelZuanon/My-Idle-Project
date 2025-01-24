using UnityEngine;
using UnityEngine.UI;

public class StockUpdater : MonoBehaviour
{
    public Slider slider;
    public float speed = 1f;
    private bool _on_production;
    private float _delay = 0f;

    // Update is called once per frame
    void Update()
    {
        if (slider.value < slider.maxValue)
        {
            _on_production = true;

            // Incrémenter le slider à intervalles réguliers
            _delay += Time.deltaTime;
            if (_delay >= 0.1f) // 0.1 seconde écoulée
            {
                float increment = speed / 10f;
                slider.value += increment;
                slider.value = Mathf.Min(slider.value, slider.maxValue); // Limite à maxValue
                _delay = 0f; // Réinitialiser le timer
            }
        }
        else
        {
            _on_production = false;
        }        
    }
}
