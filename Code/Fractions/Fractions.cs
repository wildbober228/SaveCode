using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fractions : MonoBehaviour
{
    [Header("Main Vars")]
    public int id;
    public int relations;
    public int x;
    public int y;   
    public string NameFraction;
    public string TypeSystem;
    [Header("Help Vars")]
    bool help;
    [Header("Refs to scripts")]
    public SceneManager scenemanager;
    [Header("Refs to Obj")]
    public GameObject gameObjectOfFractions;
    public Text x_text;
    public Text y_text;
    public Text NameFraction_text;
    public Text TypeSystem_text;
    Color color;
    private void Start()
    {

        x_text.text = x.ToString();
        y_text.text = y.ToString();
     
        NameFraction_text.text = NameFraction;
       
        TypeSystem_text.text = TypeSystem;
        //if (help == false)
        //{
        //    color = scenemanager.UpdateColor(relations);
        color = NameFraction_text.GetComponent<Text>().color;
        //    NameFraction_text.GetComponent<Text>().color = color;
        //}

        help = true;
    }

    private void OnEnable()
    {
        if (help == true)
        {
            //
            //  relations = scenemanager.reputation_get();

            //
            NameFraction_text.GetComponent<Text>().color = color;
            x_text.text = x.ToString();
            y_text.text = y.ToString();
            NameFraction_text.text = NameFraction;
            TypeSystem_text.text = TypeSystem;
        }
    }
}
