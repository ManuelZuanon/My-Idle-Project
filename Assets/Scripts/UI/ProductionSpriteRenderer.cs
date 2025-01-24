using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI; 

public class ProductionSpriteRenderer : MonoBehaviour
{
    public GameObject advanced_Production_Interface;

    private RectTransform _interface_Rect;

    public bool Interface_Is_Open = false; 

    public float base_height;

    public float high_height; 

    public float opening_Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _interface_Rect = advanced_Production_Interface.GetComponent<RectTransform>();

        

    }

    // Update is called once per frame
    void Update()
    {
        Sprite_Height_Changer(_interface_Rect, opening_Speed, high_height);
    }

    public void Sprite_Height_Changer(RectTransform rect, float speed,float requiredHeight)
    {
        speed = speed / Time.deltaTime;


        if (requiredHeight < rect.sizeDelta.y)
        {
            if (rect.sizeDelta.y - speed >= requiredHeight)
            {
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y - speed);


            }
            else
            {
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, requiredHeight);


            }
        }
        else if(requiredHeight > rect.sizeDelta.y)
        {

            if (rect.sizeDelta.y + speed <= requiredHeight)
            {
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + speed);


            }
            else
            {
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, requiredHeight);


            }
        }

        

       
    }

    public void Sprite_Open_Or_Close()
    {
        
       Sprite_Height_Changer(_interface_Rect, 100, 1);
    }
}
