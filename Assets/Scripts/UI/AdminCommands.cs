using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminCommands : MonoBehaviour
{
    private clickerScript score;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<clickerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            score.score += 100;
        }
    }
}
