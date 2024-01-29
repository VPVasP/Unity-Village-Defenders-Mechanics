using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public List< ScriptableVegetables> vegetables;
    [SerializeField] Button button;
    private bool isClicked = false;

    private void Start()
    {
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(UseVegetable);
    }
    public void UseVegetable()
    {
        if (vegetables.Count > 0)
        {
            Inventory.instance.UseVegetable();
            isClicked = true;
            Debug.Log("Vegetable clicked");
        }
        
    }
    private void Update()
    {
        if(isClicked)
        {
            Sprite invIcon = vegetables[0].spriteImage;
            Texture2D texture = textureFromSprite(invIcon);
            Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
        }
    }
    public static Texture2D textureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
          newText.Apply();
            newText.Apply(false);
            return newText;
        }
        else
            return sprite.texture;
    }
}
