using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScript : MonoBehaviour
{
  private float span;
   private Material material;
   private Color color;
   public Scoreboard scoreboard;
   private bool On_off;
   void Start()
   {
       material = gameObject.GetComponent<Renderer>().material;
        material.SetColor("_BeforeColor", new Color(1,1,1,1));
        material.SetFloat("_BeforeColorAmount",1f);
        On_off = true;
       
       //最初の色を青に設定

   }
   void Update()
   {
Debug.Log(On_off);
    if(scoreboard.score % 8 == 7)
    {
        if(On_off == true)
        {
        span = 0;
        color = Color();
        StartCoroutine(ChangeColor(color));  
        On_off = false;
        } 
    }
    
    span += Time.deltaTime;
  
    if(material.GetFloat("_BeforeColorAmount") <= -1)
    {
        material.SetColor("_BeforeColor", color);
         On_off = true;
        material.SetFloat("_BeforeColorAmount",1f);
    }
   }
   Color Color()
   {
   int R = Random.Range(0,7);
   if(R == 1)
   {
    return new Color(0.5f,0,0,1);
   }
   else if(R == 2)
   return new Color(0,0,0.5f,1);
   else if(R == 3)
   {
    return new Color(0,0.5f,0,1);
   }
   else if (R==4)
   {
    return new Color(0.5f,0.5f,0,1);
   }
   else if(R == 5){
    return new Color(0.5f,0,0.5f,1);
   }
   else
   {
    return new Color(0,0.5f,0.5f,1);
   }
   }
   public IEnumerator ChangeColor(Color _color)
   {
       material.SetColor("_AfterColor", _color);

       while (material.GetFloat("_BeforeColorAmount") > -1f)
       {
           material.SetFloat("_BeforeColorAmount", material.GetFloat("_BeforeColorAmount") - 0.01f);
           yield return new WaitForSeconds(0.01f);
       }
   }

}