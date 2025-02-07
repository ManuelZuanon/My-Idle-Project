using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DisplaySlidersInfo : MonoBehaviour
{
    [SerializeField] private string[] tagsToSearch = new string[] { "Food", "Stone", "Steel" }; // Liste des tags à chercher
    public TextMeshProUGUI displayText; 
    private List<string> sliderInfoList = new List<string>(); // Liste des infos récupérées

    void Start()
    {
        StartCoroutine(UpdateSlidersWithDelay());
    }

    IEnumerator UpdateSlidersWithDelay()
    {
        while (true) // Boucle infinie pour mise à jour continue
        {
            sliderInfoList.Clear();

            foreach (string tag in tagsToSearch)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

                foreach (GameObject obj in objects)
                {
                    Slider slider = obj.GetComponent<Slider>();
                    if (slider != null)
                    {
                        string realTag = obj.tag; 
                        string formattedValue = slider.value.ToString("F2"); 
                        string formattedMax = slider.maxValue.ToString("F2");

                        string info = $"{realTag} : {formattedValue}/{formattedMax}";
                        sliderInfoList.Add(info);
                    }
                }
            }

            // Mise à jour de l'affichage
            displayText.text = string.Join("\n", sliderInfoList);

            yield return new WaitForSeconds(1f); // Attente de 1 seconde
        }
    }
}
