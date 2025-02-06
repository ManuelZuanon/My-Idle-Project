using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Collections;
using static UI_Animation_Edge_Selection;


public class UI_Operation : MonoBehaviour
{
    public GameObject advanced_Production_Interface;

    private RectTransform _interface_Rect;

    public bool Interface_Is_Open = false; 

    public float base_height;

    public float high_height; 

    public float opening_Speed;

    public UI_Animation_Edge_Selection chooseEdgeForIncreaseAnimation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _interface_Rect = advanced_Production_Interface.GetComponent<RectTransform>();

        
    }

    // Update is called once per frame
    void Update()
    {
       //test UnityEngine.UI.Image image = advanced_Production_Interface.GetComponent<UnityEngine.UI.Image>();

        
    }

    // définit si Sprite_Animation_Direction peut être éviter pour passer à Sprite_Size_Animation

    
    public void Verticale_Open_Close_Interface()
    {
        if (Interface_Is_Open)
        {
            StartCoroutine(UI_Animation_Coroutine(_interface_Rect, high_height, opening_Speed));
        }
    }

    

    public IEnumerator UI_Animation_Coroutine(RectTransform rect_Transform, float height_Objectif, float animation_Speed,UI_Animation_Edge_Selection uI_Animation )
    {

        // A faire : Mise en place de l'orientation de l'animation 
        
        

        while (rect_Transform.rect.height != height_Objectif) // tant que l'objectif en hauteur n'est pas atteint 
        {
            if(rect_Transform.rect.height + animation_Speed * Time.deltaTime > height_Objectif ) // Si l'objectif visée n'est dépassé par l'addition de la hauteur actuel et de la vitesse, 
            {
                Debug.Log(" A - première partie prise en compte");
                Rect_Operation.Move_Top_Edge(_interface_Rect, animation_Speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            else
            {
                Debug.Log("B - première partie pas prise en compte");
                rect_Transform.sizeDelta = new Vector2(height_Objectif, rect_Transform.rect.y);
                break;
            }

            
        }

        yield return 0; 
    }
}

public enum UI_Animation_Edge_Selection
{
    topIncrease,
    downIncrease,
    leftIncrease,
    rightIncrease
    
}

public class Orientation
{
    protected Vector2 top = new Vector2 (0,1); 
   
}



public static class Rect_Operation
{

    public static void Move_Top_Edge(RectTransform rect, float delta_Y) // permet d'étendre un rectransform que d'un coté en Y
    {

        float operation_Pivot = (delta_Y == 1) ? 1 : 0; //variable avec operateur conditonnel ternaire pour savoir si le pivot est bien placé pour un déplacement négatif ou positif du coté


        if (rect.pivot.x != operation_Pivot)
        {
            float origin_PivotY = rect.pivot.y;

            rect.position = new Vector3(rect.position.x, rect.position.y - (rect.sizeDelta.y * rect.pivot.y));

            rect.pivot = new Vector2(rect.pivot.x, operation_Pivot);

            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + delta_Y);

            rect.position = new Vector3(rect.position.x, rect.position.y + (rect.sizeDelta.y * origin_PivotY));

            rect.pivot = new Vector2(rect.pivot.x, origin_PivotY);

        }
        else
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + delta_Y);
        }
    }

    public static void Move_Down_Edge(RectTransform rect, float delta_Y) // permet d'étendre un rectransform que d'un coté en Y
    {

        float operation_Pivot = (delta_Y == 1) ? 0 : 1; //variable avec operateur conditonnel ternaire pour savoir si le pivot est bien placé pour un déplacement négatif ou positif du coté


        if (rect.pivot.x != operation_Pivot)
        {
            float origin_PivotY = rect.pivot.y;

            rect.position = new Vector3(rect.position.x, rect.position.y - (rect.sizeDelta.y * rect.pivot.y));

            rect.pivot = new Vector2(rect.pivot.x, operation_Pivot);

            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + delta_Y);

            rect.position = new Vector3(rect.position.x, rect.position.y + (rect.sizeDelta.y * origin_PivotY));

            rect.pivot = new Vector2(rect.pivot.x, origin_PivotY);

        }
        else
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + delta_Y);
        }
    }

    public static void Move_Right_Edge(RectTransform rect, float delta_X) // permet d'étendre un rectransform que d'un coté en X
    {

        float operation_Pivot = (delta_X == 1) ? 1 : 0; //variable avec operateur conditonnel ternaire pour savoir si le pivot est bien placé pour un déplacement négatif ou positif du coté


        if (rect.pivot.y != operation_Pivot)
        {
            float origin_PivotX = rect.pivot.x;

            rect.position = new Vector3(rect.position.x - (rect.sizeDelta.x * rect.pivot.x), rect.position.y);

            rect.pivot = new Vector2(operation_Pivot, rect.pivot.y);

            rect.sizeDelta = new Vector2(rect.sizeDelta.x + delta_X, rect.sizeDelta.y);

            rect.position = new Vector3(rect.position.x + (rect.sizeDelta.x * origin_PivotX), rect.position.y);

            rect.pivot = new Vector2(origin_PivotX, rect.pivot.y);

        }
        else
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x + delta_X, rect.sizeDelta.y);
        }
    }

    public static void Move_Left_Edge(RectTransform rect, float delta_X) // permet d'étendre un rectransform que d'un coté en X
    {

        float operation_Pivot = (delta_X == 1) ? 0 : 1; //variable avec operateur conditonnel ternaire pour savoir si le pivot est bien placé pour un déplacement négatif ou positif du coté


        if (rect.pivot.y != operation_Pivot)
        {
            float origin_PivotX = rect.pivot.x;

            rect.position = new Vector3(rect.position.x - (rect.sizeDelta.x * rect.pivot.x), rect.position.y);

            rect.pivot = new Vector2(operation_Pivot, rect.pivot.y);

            rect.sizeDelta = new Vector2(rect.sizeDelta.x + delta_X, rect.sizeDelta.y);

            rect.position = new Vector3(rect.position.x + (rect.sizeDelta.x * origin_PivotX), rect.position.y);

            rect.pivot = new Vector2(origin_PivotX, rect.pivot.y);

        }
        else
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x + delta_X, rect.sizeDelta.y);
        }
    }


}


