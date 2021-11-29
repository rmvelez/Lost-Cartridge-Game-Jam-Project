using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public static RaycastHit hit;
    public GameObject reticle;
    public float range;
    public Transform origin;
    private Camera cam;
    private LineRenderer lr;
    private Vector3[] line = new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        //LinePresets();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SetPoints();
        lr.SetPositions(line);
    }

    private void SetPoints()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        reticle.transform.position = hit.point + Vector3.up * 0.51f;
        Debug.DrawRay(ray.origin, ray.direction);
        line[0] = origin.position;
        line[1] = hit.collider == null ? origin.position + ray.direction * range : origin.position + ray.direction * hit.distance;
    }

    private void LinePresets()
    {
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.red;
        lr.endColor = Color.red;

        lr.startWidth = .1f;
        lr.endWidth = .1f;
    }
}
