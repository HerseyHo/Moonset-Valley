using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonsetValley.Inventory
{
    public class Item : MonoBehaviour
    {
        public string itemID;

        private SpriteRenderer spriteRenderer;

        private BoxCollider2D coll;

        public ItemDetails itemDetails;  //存储一份物体信息

        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            coll = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            if (itemID != "")
            {
                Init(itemID);
            }
                
        }

        public void Init(string ID)
        {
            itemID = ID;

            //Inventory获取当前数据
            itemDetails = InventoryManager.Instance.GetItemDetails(itemID);

            if (itemDetails != null) {
                spriteRenderer.sprite = itemDetails.itemOnWorldSprite != null? itemDetails.itemOnWorldSprite : itemDetails.itemIcon;

                //修改碰撞体尺寸
                Vector2 newSize = new Vector2(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y);
                coll.size = newSize;
                coll.offset = new Vector2(0, spriteRenderer.sprite.bounds.center.y);
            }
        }
    }
}

