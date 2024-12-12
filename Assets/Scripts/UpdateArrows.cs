using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateArrows : MonoBehaviour
{
    Material mt;
    public float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer ms = GetComponent<MeshRenderer>();
        if(ms != null) {
            mt = ms.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mt) {
            Vector2 offset = mt.GetTextureOffset("_MainTex");
            offset.y += speed * Time.deltaTime;
            mt.SetTextureOffset("_MainTex", offset);
        }
    }
}
