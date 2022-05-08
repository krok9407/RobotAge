using System.Linq;
using UnityEngine;
 
public class ObjectController : MonoBehaviour
{
    public Transform[] WayPoints;
    public float speed = 1;
    public float tolerance = 1;
 
    void Start()
    {
        var points = WayPoints.Select(tr => tr.position).ToArray();
        StartCoroutine(Bezier.MoveAlong(transform, points, tolerance, speed));
    }
}