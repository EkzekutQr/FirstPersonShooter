using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPCounter : MonoBehaviour
{
    public void UpdateHPCounter(int count)
    {
        gameObject.GetComponent<Text>().text = count.ToString();

        if(count <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
