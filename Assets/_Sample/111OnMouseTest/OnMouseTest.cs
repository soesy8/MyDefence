using UnityEngine;
using System.Collections;

namespace MySample
{
    public class OnMouseTest : MonoBehaviour
    {
        public GameObject obj;
        public Renderer rend;
        public Collider col;

        void Start()
        {
            obj = GetComponent<GameObject>();
            rend = GetComponent<Renderer>();
            col = GetComponent<Collider>();
        }
        public void OnMouseEnter()
        {
            Debug.Log("Enter");
        }

        public void OnMouseExit()
        {
            Debug.Log("Exit");
        }
    }
}