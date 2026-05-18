using UnityEngine;

// Propagation dans l'espace libre sur une distance d
// Matrice ABCD associée (document section 4.1) :
// [ 1  d ]
// [ 0  1 ]
public class FreeSpace
{
    public float distance; // d

    public FreeSpace(float d)
    {
        this.distance = d;
    }

    public ABCDMatrix GetMatrix()
    {
        return new ABCDMatrix(1f, distance, 0f, 1f);
    }

    public RayData ApplyToRay(RayData rayIn)
    {
        return GetMatrix().Apply(rayIn);
    }
}