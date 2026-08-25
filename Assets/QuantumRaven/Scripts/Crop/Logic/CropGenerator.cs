using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonsetValley.Map;


namespace MoonsetValley.CropPlant
{
    public class CropGenerator : MonoBehaviour
    {
        private Grid currentGrid;

        public string seedItemID;

        public int growthDays;

        private void Awake()
        {
            currentGrid = FindObjectOfType<Grid>();
        }

        private void OnEnable()
        {
            EventHandler.GenerateCropEvent += GenerateCrop;
        }

        private void OnDisable()
        {
            EventHandler.GenerateCropEvent -= GenerateCrop;
        }

        private void GenerateCrop()
        {
            if (seedItemID == "") return;

            if (currentGrid == null)
            {
                currentGrid = FindObjectOfType<Grid>();
            }

            if (currentGrid == null) return;

            Vector3Int cropGridPos = currentGrid.WorldToCell(transform.position);
            var tile = GridMapManager.Instance.GetTileDetailsOnMousePosition(cropGridPos);

            if(tile == null)
            {
                tile = new TileDetails();
            }

            tile.gridX = cropGridPos.x;
            tile.gridY = cropGridPos.y;
            tile.daysSinceWatered = -1;
            tile.seedItemID = seedItemID;
            tile.growthDays = growthDays;
            tile.hasFixedCropWorldPosition = true;
            tile.fixedCropWorldPosition = transform.position;

            GridMapManager.Instance.UpdateTileDetails(tile);
        }
    }
}
