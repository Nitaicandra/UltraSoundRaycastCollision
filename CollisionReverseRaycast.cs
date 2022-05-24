using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReverseRaycast : MonoBehaviour
{
    void Start()
    {
      
    }
    public Vector3 default_origin = new Vector3(0f, 0f, -1f);
    public Vector3 default_lookat = new Vector3(0f, 0f, 0.5f);
    public float compression_ratio = 1;
    public LayerMask layer;
    public GameObject lastHit;
    public Vector3 collision = Vector3.zero;
    public Vector3 ray_origin = Vector3.zero;
    public Vector3 ray_lookat = Vector3.zero;
    public float ray_length = 0;
    public float ray_distance = 0;
    public float pressure = 0;

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(this.name + " Collided with " + other.name);
        
        //ray_origin = this.transform.TransformPoint(Vector3.back);
        raycast();
    }
    private void OnTriggerExit(Collider other)
    {
        ray_length = 0;
        ray_distance = 0;
        pressure = 0;
            
    }
    /*
    void Update()
    {
        raycast();
    }
    */
    void raycast()
    {

        ray_origin = this.transform.TransformPoint(default_origin);
        ray_lookat = this.transform.TransformPoint(default_lookat);
        ray_length = Vector3.Distance(ray_origin, ray_lookat);
        RaycastHit hit;
        Color color = Color.red;
        if (Physics.Raycast(ray_origin, ray_lookat-ray_origin, out hit, ray_length, layer))
        {

            lastHit = hit.transform.gameObject;
            Debug.DrawLine(ray_origin, collision, color);
            collision = hit.point;
            ray_distance = Vector3.Distance(ray_lookat, collision);
            Debug.Log("RAYCASTDISTANCE " + ray_distance);
            pressure = compression_ratio * ray_distance;

        }
        else { Debug.DrawLine(ray_origin, ray_lookat, color); }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }

}
