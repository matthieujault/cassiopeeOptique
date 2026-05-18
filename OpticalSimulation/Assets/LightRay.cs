using UnityEngine;

// Trace visuellement le rayon dans Unity en utilisant
// le formalisme ABCD pour calculer la déviation
public class LightRay : MonoBehaviour
{
    public float maxDistance = 100f;

    void Update()
    {
        ShootRay(transform.position, transform.right.normalized);
    }

    void ShootRay(Vector3 origin, Vector3 dir)
    {
        RaycastHit hit;

        if (Physics.Raycast(origin, dir, out hit, maxDistance))
        {
            Debug.DrawLine(origin, hit.point, Color.red);

            Lens lens = hit.collider.GetComponentInParent<Lens>();

            if (lens != null)
            {
                Vector3 O       = lens.transform.position;
                Vector3 axisDir = Vector3.right;
                Vector3 vertDir = Vector3.up;

                // Hauteur r = position du point d'impact par rapport à l'axe
                float r = Vector3.Dot(hit.point - O, vertDir);

                // Angle theta du rayon incident par rapport à l'axe optique
                // theta = arctan(dir.y / dir.x) ≈ dir.y / dir.x (approx paraxiale)
                float theta = Mathf.Atan2(dir.y, dir.x);

                // Construction du rayon ABCD entrant
                RayData rayIn = new RayData(r, theta);

                // Application de la matrice ABCD de la lentille
                RayData rayOut = lens.ApplyToRay(rayIn);

                Debug.Log($"Rayon entrant  : {rayIn}");
                Debug.Log($"Rayon sortant  : {rayOut}");
                Debug.Log($"Matrice lentille :\n{lens.GetMatrix()}");

                // CAS PARTICULIER : rayon passant par O (r ≈ 0)
                if (Mathf.Abs(r) < 0.01f)
                {
                    Debug.DrawRay(hit.point, dir * maxDistance, Color.green);
                    return;
                }

                // Direction 3D du rayon sortant à partir de theta'
                // theta' = angle de sortie calculé par la matrice ABCD
                Vector3 newDir = new Vector3(
                    Mathf.Cos(rayOut.theta),
                    Mathf.Sin(rayOut.theta),
                    0f
                ).normalized;

                // Si le rayon repart vers la gauche (image virtuelle)
                // on s'assure qu'il va bien vers la droite
                if (newDir.x < 0) newDir = -newDir;

                Debug.DrawRay(hit.point, newDir * maxDistance, Color.green);

                // Debug : foyers en jaune/orange
                Debug.DrawRay(lens.GetFocalPointImage(),  Vector3.up * 0.3f, Color.yellow);
                Debug.DrawRay(lens.GetFocalPointObject(), Vector3.up * 0.3f, Color.yellow);
            }
        }
        else
        {
            Debug.DrawRay(origin, dir * maxDistance, Color.red);
        }
    }
}