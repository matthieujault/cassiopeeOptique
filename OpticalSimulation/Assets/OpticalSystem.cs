using System.Collections.Generic;
using UnityEngine;

// Système optique complet = liste ordonnée d'éléments
// La propagation applique successivement chaque matrice au rayon courant
// (composition de matrices = multiplication dans l'ordre)
public class OpticalSystem
{
    private List<ABCDMatrix> elements = new List<ABCDMatrix>();
    private List<string>     labels   = new List<string>();

    // Ajoute un élément optique au système
    public void AddElement(ABCDMatrix matrix, string label = "")
    {
        elements.Add(matrix);
        labels.Add(label);
    }

    // Propage le rayon à travers tous les éléments dans l'ordre
    public RayData Propagate(RayData rayIn)
    {
        RayData current = rayIn;
        for (int i = 0; i < elements.Count; i++)
        {
            current = elements[i].Apply(current);
            Debug.Log($"Après [{labels[i]}] : {current}");
        }
        return current;
    }

    // Matrice totale du système (produit de toutes les matrices)
    public ABCDMatrix GetSystemMatrix()
    {
        if (elements.Count == 0)
            return new ABCDMatrix(1, 0, 0, 1); // identité

        ABCDMatrix result = elements[0];
        for (int i = 1; i < elements.Count; i++)
            result = result.Multiply(elements[i]);

        return result;
    }
}