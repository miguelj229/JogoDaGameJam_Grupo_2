using UnityEngine;

public class OrderBubble : MonoBehaviour
{
    public SpriteRenderer icon;

    public void SetRecipe(Recipe recipe)
    {
        icon.sprite = recipe.icon;
    }
}
