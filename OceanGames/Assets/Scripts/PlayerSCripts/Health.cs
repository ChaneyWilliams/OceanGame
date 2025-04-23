using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] heart;
    public Sprite fullHeart;


    void Update()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < health)
            {
                heart[i].sprite = fullHeart;
            }
            else
            {
                heart[i].gameObject.GetComponent<Image>().color = Color.red;
            }
            if (i < numOfHearts)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
        }
    }
}
