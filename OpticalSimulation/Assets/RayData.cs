using UnityEngine;

// Représente un rayon lumineux par son état [r, theta]
// conformément au formalisme ABCD du document
public class RayData
{
    public float r;     // position par rapport à l'axe optique
    public float theta; // angle par rapport à l'axe optique (en radians)

    public RayData(float r, float theta)
    {
        this.r     = r;
        this.theta = theta;
    }

    public override string ToString()
    {
        return $"RayData(r={r:F4}, theta={theta:F4} rad)";
    }
}