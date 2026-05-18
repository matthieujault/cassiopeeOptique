using UnityEngine;

// Lentille mince définie par sa distance focale f
// Matrice ABCD associée (document section 4.2) :
// [ 1      0 ]
// [ -1/f   1 ]
public class Lens : MonoBehaviour
{
    [Header("Propriétés optiques")]
    public float focalLength = 3f; // distance focale f (en unités Unity)

    // Retourne la matrice ABCD de la lentille mince
    public ABCDMatrix GetMatrix()
    {
        return new ABCDMatrix(
            1f,
            0f,
            -1f / focalLength,
            1f
        );
    }

    // Applique la lentille à un rayon entrant → rayon sortant
    public RayData ApplyToRay(RayData rayIn)
    {
        return GetMatrix().Apply(rayIn);
    }

    // Axe optique = axe X du monde (indépendant de la rotation du mesh)
    public Vector3 GetOpticalAxis()
    {
        return Vector3.right;
    }

    public Vector3 GetFocalPointImage()
    {
        return transform.position + Vector3.right * focalLength;
    }

    public Vector3 GetFocalPointObject()
    {
        return transform.position - Vector3.right * focalLength;
    }

    // Relation de conjugaison de Descartes (découle de la matrice ABCD)
    // OA' = (OA * f) / (OA + f)
    public float GetImageDistance(float objectDistance)
    {
        if (Mathf.Abs(objectDistance + focalLength) < 0.001f)
            return float.PositiveInfinity;

        return (objectDistance * focalLength) / (objectDistance + focalLength);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(GetFocalPointImage(), 0.1f);

        Gizmos.color = new Color(1f, 0.5f, 0f);
        Gizmos.DrawSphere(GetFocalPointObject(), 0.1f);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(
            transform.position - Vector3.right * focalLength * 2f,
            transform.position + Vector3.right * focalLength * 2f
        );
    }
}