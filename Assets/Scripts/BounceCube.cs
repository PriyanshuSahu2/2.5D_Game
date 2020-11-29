using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCube : MonoBehaviour
{
    #region --Variables--
    private Mesh mesh, mesh1;
    private MeshRenderer meshRenderer;
    public float Mass = 1f;
    public float Stifness = 1f;
    public float damping = 0.75f;
    private BounceDeform[] bv;
    private Vector3[] vertexArr;
    [SerializeField] float Intensity;
    #endregion
    void Start()
    {
        mesh = GetComponent<MeshFilter>().sharedMesh;
        mesh1 = Instantiate(mesh);
        GetComponent<MeshFilter>().sharedMesh = mesh1;
        meshRenderer = GetComponent<MeshRenderer>();
        bv = new BounceDeform[mesh1.vertices.Length];
        for (int i = 0; i < mesh1.vertices.Length; i++)
            bv[i] = new BounceDeform(i, transform.TransformPoint(mesh1.vertices[i]));
        
    }
    void FixedUpdate()
    {
        vertexArr = mesh.vertices;
        for(int i =0;i<bv.Length;i++)
        {
            Vector3 target = transform.TransformPoint(vertexArr[bv[i].ID]);
            float intensity = (1 - (meshRenderer.bounds.max.y - target.y) / meshRenderer.bounds.size.y) * Intensity;
            bv[i].Shake(target, Mass, Stifness, damping);
            target = transform.InverseTransformDirection(bv[i].position);
            vertexArr[bv[i].ID] = Vector3.Lerp(vertexArr[bv[i].ID], target, intensity);

        }
        mesh1.vertices = vertexArr;
    }
    public class BounceDeform
    {
        public int ID;
        public Vector3 position;
        public Vector3 velocity, force;

        public BounceDeform(int _id,Vector3 _pos)
        {
            ID = _id;
            position = _pos;
        }
        public void Shake(Vector3 target, float m, float s, float d)
        {
            force = (target - position) * s;
            velocity = (velocity + force / m) * d;
            position += velocity;
            if ((velocity + force + force / m).magnitude < 0.001f)
                position = target;


        }
    }
}
