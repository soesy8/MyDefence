using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyDefence
{
    public class TileUI : MonoBehaviour
    {
        //var
        public TextMeshProUGUI upgradeCostText;
        public TextMeshProUGUI sellCostText;

        private Tile selectedTile;

        public Button upgradeButton;

        //Unity Event Method
        private void Start()
        {
            gameObject.SetActive(false);
        }

        //Custom Method
        public void Upgrade()
        {
            Tile tile = BuildManager.Instance.SelectedTile;

            if (tile != null) tile.UpgradeTower();
            Hide();
        }
        public void Sell()
        {
            Tile tile = BuildManager.Instance.SelectedTile;
            
            if(tile != null) tile.SellTower();
            Hide();
        }
        
        public void Show(Tile tile)
        {
            selectedTile = tile;

            transform.position = tile.transform.position;

            if (tile.IsUpgrade == true)
            {
                upgradeCostText.text = "DONE";
                upgradeButton.interactable = false;
            }
            else
            {
                upgradeCostText.text = selectedTile.towerBlueprint.upgradeCost.ToString() + "G";
                upgradeButton.interactable = true;
            }

            sellCostText.text = selectedTile.towerBlueprint.GetSellCost().ToString() + "G";

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            BuildManager.Instance.SelectedTile = null;
            gameObject.SetActive(false);
        }
    }
}