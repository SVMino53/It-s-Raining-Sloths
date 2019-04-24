﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothDestroyer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            if (transform.position.y < player.GetComponent<Move>().getCurPosY())
                Destroy(gameObject);
    }
}
