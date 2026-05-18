using UnityEngine;

// Matrice ABCD 2x2 qui transforme un rayon entrant en rayon sortant
// [ r' ]   [ A  B ] [ r     ]
// [ θ' ] = [ C  D ] [ theta ]
public class ABCDMatrix
{
    public float A, B, C, D;

    public ABCDMatrix(float a, float b, float c, float d)
    {
        A = a; B = b; C = c; D = d;
    }

    // Applique la transformation ABCD au rayon entrant
    // r'     = A*r + B*theta
    // theta' = C*r + D*theta
    public RayData Apply(RayData rayIn)
    {
        float rOut     = A * rayIn.r + B * rayIn.theta;
        float thetaOut = C * rayIn.r + D * rayIn.theta;
        return new RayData(rOut, thetaOut);
    }

    // Composition de deux matrices : this * other
    // Utile pour cascader plusieurs éléments optiques
    public ABCDMatrix Multiply(ABCDMatrix other)
    {
        return new ABCDMatrix(
            A * other.A + B * other.C,
            A * other.B + B * other.D,
            C * other.A + D * other.C,
            C * other.B + D * other.D
        );
    }

    // Vérifie que le déterminant = 1 (milieu homogène)
    // AD - BC = 1 selon le document
    public float Determinant()
    {
        return A * D - B * C;
    }

    public override string ToString()
    {
        return $"[{A:F3}  {B:F3}]\n[{C:F3}  {D:F3}]  det={Determinant():F4}";
    }
}