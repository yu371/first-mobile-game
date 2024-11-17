using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Change_Scene : MonoBehaviour
{
    public void To_Sample()
    {
    SceneManager.LoadScene("SampleScene 1");
    }
    public void To_Ranking()
    {
    SceneManager.LoadScene("Ranking");
    }
}
