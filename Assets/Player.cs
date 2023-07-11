using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player i;
    [HideInInspector] public UnityEvent onBirdEat = new UnityEvent();
    [HideInInspector] public int birdsEaten;

    private void Awake()
    {
        i = this;
    }

    public void BirdHit()
    {
        birdsEaten += 1;
        onBirdEat.Invoke();
    }

    public void ObstacleHit()
    {
        SceneManager.LoadScene(0);
    }
}
