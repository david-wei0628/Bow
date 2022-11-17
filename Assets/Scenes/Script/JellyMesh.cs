using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMesh : MonoBehaviour
{
    public float Intensity = 1f; //強度預設值
    public float Mass = 1f;  //質量預設值
    public float stiffness = 1f; //剛性預設值
    public float damping = 0.75f;//彈性預設值
    private Mesh OriginalMesh, MeshClone;
    private MeshRenderer renderer;
    private JellyVertex[] jv;
    private Vector3[] vertexArray;

    void Start()
    {
        OriginalMesh = GetComponent<MeshFilter>().sharedMesh;
        MeshClone = Instantiate(OriginalMesh); // 網格克隆實際化
        GetComponent<MeshFilter>().sharedMesh = MeshClone;
        renderer = GetComponent<MeshRenderer>();
        jv = new JellyVertex[MeshClone.vertices.Length];
        for (int i = 0; i < MeshClone.vertices.Length; i++)
            jv[i] = new JellyVertex(i, transform.TransformPoint(MeshClone.vertices[i])); // MeshClone頂點長度轉換
    }

    void FixedUpdate()
    {
        vertexArray = OriginalMesh.vertices;
        for (int i = 0; i < jv.Length; i++)//依據長度得到其他的point
        {
            Vector3 target = transform.TransformPoint(vertexArray[jv[i].ID]);
            float intensity = (1 - (renderer.bounds.max.y - target.y) / renderer.bounds.size.y) * Intensity;//讓強度使用render bounds max
            jv[i].Shake(target, Mass, stiffness, damping);
            target = transform.InverseTransformPoint(jv[i].Position);
            vertexArray[jv[i].ID] = Vector3.Lerp(vertexArray[jv[i].ID], target, intensity);
        }
        MeshClone.vertices = vertexArray;
    }

    public class JellyVertex // 宣告果凍的位置、速度、力量
    {
        public int ID;
        public Vector3 Position;
        public Vector3 velocity, Force;

        public JellyVertex(int _id, Vector3 _pos)
        {
            ID = _id;
            Position = _pos;

        }

        public void Shake(Vector3 target, float m, float s, float d)// multiply力量、速度位置等等控制mesh的shake
        {
            Force = (target - Position) * s;
            velocity = (velocity + Force / m) * d;
            Position += velocity;
            if ((velocity + Force + Force / m).magnitude < 0.001f)
                Position = target;
        }

    }


}