using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForFinish : MonoBehaviour
{
    public String PlayerTag;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals(PlayerTag))
            SceneManager.LoadScene("GameWinScene");
    }
}
