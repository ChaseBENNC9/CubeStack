using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private List<Powerup> powerups;
    void Start()
    {
        powerups = GameObject.FindObjectsOfType<Powerup>().ToList<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Powerup powerup in powerups)
        {
            powerup.UpdateButton();
        }
    }
}
