using UnityEngine;

namespace MyDefence
{
    public class MainMenuTower : MonoBehaviour
    {
        #region Var
        public GameObject rotatePart;
        public GameObject laserEffect;
        public GameObject firePoint;
        [SerializeField] private float rotationValue = 90f;
        
        #endregion

        #region Unity Event Method
        private void Start()
        {
            InvokeRepeating(nameof(PlayEffect), 5f, 5f);
        }

        private void Update()
        {
            rotatePart.transform.Rotate(0f, rotationValue * Time.deltaTime, 0f);
        }
        #endregion

        #region Custom Method
        private void PlayEffect()
        {
            GameObject effectGo = Instantiate(laserEffect, firePoint.transform.position, firePoint.transform.rotation);
            Destroy(effectGo, 1f);
        }
        #endregion
    }
}