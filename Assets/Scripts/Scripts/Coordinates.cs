using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))] //auto add text mesh pro elements 

[ExecuteAlways] //in play and edit mode 
public class Coordinates : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.red; //change color of numbers 
    [SerializeField] Color blockedColor = Color.gray; //color player cant use 

    TextMeshPro label; //text variable
    Vector2Int coordinates = new Vector2Int(); // tile coordinate 
    Waypoint waypoint;//access waypoint

    void Awake()
    {
        label = GetComponent<TextMeshPro>(); // get text 
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();//displays coordinates within class/label
    }
    
    void Update()
    {
        if(!Application.isPlaying) //code run only in edit mode  
        {
          DisplayCoordinates();//displays coordinates within class/label
          UpdateObjectName();//give tile coordinate name 
          label.enabled = true;
        }

        SetLabelColor();
        toggleLabels();
        
    }

    void toggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
           label.enabled = !label.enabled; //turn numbers off / opposite of current active state 
        }
    }

    void SetLabelColor()
    {
        if(waypoint.IsPlacable) //if IsPlacable = true
        {
          label.color = defaultColor; // make numbers red
        }
        else
        {
          label.color = blockedColor; // make numbers gray
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x); //get tile coordinate rounded up to whole number 
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); //get tile coordinate rounded up to whole number
        label.text = coordinates.x + "," + " " + coordinates.y; // display coords
    }

    void UpdateObjectName() //name tile after its coordinate
    {
        transform.parent.name = coordinates.ToString(); // turn coordinate into string for name 
    }  
}
