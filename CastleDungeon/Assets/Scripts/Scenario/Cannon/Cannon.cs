using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
   public Transform firePoint;
   public GameObject bullet;
   private float _timeBetween;
   public float time;
   private Animator _anim;

   private void Start()
   {
      _anim = GetComponent<Animator>();
      _timeBetween = time;
   }

   private void Update()
   {
      if (_timeBetween <= 0)
      {
         _anim.SetTrigger("fired");
         Instantiate(bullet, firePoint.position, firePoint.rotation);
         _timeBetween = time;
      }
      else
      {
         _timeBetween -= Time.deltaTime;
      }
   }
}
