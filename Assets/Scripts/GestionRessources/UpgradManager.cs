using System.IO;
using UnityEngine;

namespace ResourcesManager
{
    // Définition d'une structure pour représenter les coûts d'amélioration
    [System.Serializable]
    public struct UpgradeCost
    {
        public string Ressource; // Nom de la ressource requise
        public int UpCost; // Coût initial de l'amélioration
        public float NextUpMultiplier; // Multiplicateur pour l'amélioration suivante
    }

    // Définition d'une structure pour représenter une ressource
    [System.Serializable]
    public struct Resource
    {
        public string Name; // Nom de la ressource
        public UpgradeCost SpeedUpCost; // Coût pour améliorer la vitesse
        public UpgradeCost StockUpCost; // Coût pour améliorer le stockage
    }

    // Classe contenant la liste des ressources
    [System.Serializable]
    public class ResourceDatabase
    {
        public Resource[] Resources; // Tableau des ressources
    }

    public class UpgradManager : MonoBehaviour
    {
        private ResourceDatabase resourceDatabase; // Base de données des ressources
        private readonly string filePath = Path.Combine(Application.dataPath, "Scripts/GestionRessources/resources.json");

        void Start()
        {
            LoadData(); // Charger les données au démarrage
        }

        // Chargement des données depuis le JSON
        private void LoadData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                resourceDatabase = JsonUtility.FromJson<ResourceDatabase>(json);
            }
        }

        // Récupérer une ressource spécifique par son nom
        public Resource? GetResource(string resourceName)
        {
            if (resourceDatabase?.Resources != null)
            {
                foreach (var resource in resourceDatabase.Resources)
                {
                    if (resource.Name == resourceName)
                    {
                        return resource;
                    }
                }
            }
            return null; // Retourne null si la ressource n'est pas trouvée
        }
    }
}
