using UnityEngine;
/// <summary>
/// add empty object
/// </summary>
public class BreakCube : MonoBehaviour
{
    public int numberOfFragments = 5; // 碎片數量
    public float explosionForce = 5f; // 爆炸力
    public GameObject fragmentsContainer; // 碎片容器

    void Start()
    {
        fragmentsContainer = this.gameObject;
        //BreakIntoFragments();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            BreakIntoFragments();
        }
    }

    void BreakIntoFragments()
    {
        Vector3 cubeSize = transform.localScale;
        Vector3 fragmentSize = cubeSize / numberOfFragments;

        for (int x = 0; x < numberOfFragments; x++)
        {
            for (int y = 0; y < numberOfFragments; y++)
            {
                for (int z = 0; z < numberOfFragments; z++)
                {
                    CreateFragment(new Vector3(fragmentSize.x * x, fragmentSize.y * y, fragmentSize.z * z), fragmentSize);
                }
            }
        }

        //Destroy(gameObject);
    }

    void CreateFragment(Vector3 position, Vector3 size)
    {
        GameObject fragment = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fragment.transform.position = transform.position + position;
        fragment.transform.localScale = size;
        fragment.transform.parent = fragmentsContainer.transform;
        fragment.AddComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, 1f);
    }
}
