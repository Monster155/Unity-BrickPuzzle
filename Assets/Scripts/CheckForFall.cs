using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckForFall : MonoBehaviour
{
    public String GameOverTag;
    public Canvas Canvas;

    private void Start()
    {
        Canvas.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals(GameOverTag))
            Canvas.enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}