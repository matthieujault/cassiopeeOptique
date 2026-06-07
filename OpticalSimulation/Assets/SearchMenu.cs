using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchMenu : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button searchButton;
    public TMP_Text buttonText;

    public void OnSearchClicked()
    {
        string text = inputField.text;
        buttonText.text = text;

        /*
         
         ICI, IL DEVRAIT Y AVOIR
         UNE REQUETE VERS UN SERVEUR POUR RECUPERER LES RESULTATS DE LA RECHERCHE
         LE CODE QUI RENVOIE LA REQUETE A THORLABS EST DEJA CODE EN PYTHON

         //type de reauete retour {'diameter_mm': 2.0,
        'focal_length_mm': 4.0,
        'name': 'N-SF11 Plano-Convex Lens,
        Ø2.0 mm, 
        f = 4.0 mm, 
        Uncoated', 
        'code': 'LA2024', 
        'blueprint_url': '', 
        'step': ''}

         */
        string data_json = @"
        {
            ""diameter_mm"": 2.0,
            ""focal_length_mm"": 4.0,
            ""name"": ""N-SF11 Plano-Convex Lens, Ø2.0 mm, f = 4.0 mm, Uncoated"",
            ""code"": ""LA2024"",
            ""blueprint_url"": ""https://thin01mstroc282prod.dxcloud.episerver.net/globalassets/items/l/la/la2/la2024/ttn162739-e0w.pdf?v=0116121051"",
            ""step"": ""https://thin01mstroc282prod.dxcloud.episerver.net/globalassets/items/l/la/la2/la2024/ttn162739-e0w.step?v=0116121053""
        }";
        LentilleObject lens = JsonUtility.FromJson<LentilleObject>(data_json);
    }


 }