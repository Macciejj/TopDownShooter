using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] float attackSpeed;
    [SerializeField][Range(0,2)] int weaponIdex;

    public abstract void Shoot();


    private void Awake()
    {

    }

}
