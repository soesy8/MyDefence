using UnityEngine;

namespace MyDefence
{
    public class TileUI : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }
        public void Upgrade()
        {
            Tile tile = BuildManager.Instance.SelectedTile;

            if (tile != null) tile.UpgradeTower();
            Hide();
        }
        public void Show(Tile tile)
        {
            gameObject.SetActive(true);
            transform.position = tile.transform.position + new Vector3(0, 0, 0);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}