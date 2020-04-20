﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject[] interactObjects;
    public bool opensPermanently = false;
    private Animator anim;
    bool isPowered = false;

    void Start() {
        anim = GetComponent<Animator>();
    }

    public void Press()
    {
        if (!isPowered) {
            foreach (GameObject i in interactObjects) {
                Door d;
                LoopingPlatform p;
                if (i.TryGetComponent<Door>(out d)) {
                    d.Move();
                }
                if (i.TryGetComponent<LoopingPlatform>(out p)) {
                    p.Move();
                }
            }
            isPowered = true;
            anim.SetBool("isPowered", isPowered);
        }
    }

    public void Reset() {
        foreach (GameObject i in interactObjects) {
            Door d;
            LoopingPlatform p;
            if (i.TryGetComponent<Door>(out d) && !opensPermanently) {
                d.Reset();
            }
            if (i.TryGetComponent<LoopingPlatform>(out p) && !opensPermanently) {
                p.Reset();
            }
        }
        isPowered = false;
        anim.SetBool("isPowered", isPowered);
    }
}
