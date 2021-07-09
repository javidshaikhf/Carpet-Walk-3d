using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Transition;
using UnityEngine;
using UnityEngine.Serialization;

public class Carpet : SingleOnScene<Carpet>
{

   public Transform[] modelFollowPositions;

   [SerializeField] private List<Model> mCurrentFollowingModelsList;
   [SerializeField] private Transform cameraEndTransform;
   
   public static int modelCount;
   
   public void AddModel(Model model)
   {
      if (model != null)
      {
         mCurrentFollowingModelsList.Add(model);
         modelCount = mCurrentFollowingModelsList.Count;
         model.followPosition = modelFollowPositions[modelCount - 1];
      }
   }

   public void RemoveModel()
   {
      Model model = mCurrentFollowingModelsList[mCurrentFollowingModelsList.Count - 1];
      
      model.StopWalking();
      
      mCurrentFollowingModelsList.Remove(model);
      modelCount = mCurrentFollowingModelsList.Count;
      
      if (mCurrentFollowingModelsList.Count == 0)
      {
         DoCameraEndTransistion();
         
         GameController.Instance.GameOver();
         Debug.Log("No Models Left,   **** GAME OVER ****");
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Blocker")
      {
         RemoveModel();
      }else if (other.tag == "EndLine")
      {
         Debug.Log("**** Game Won ****");
         GameController.Instance.GameWin();

         DoCameraEndTransistion();
      }
   }

   private void DoCameraEndTransistion()
   {
      Camera.main.transform.localPositionTransition(cameraEndTransform.localPosition, 2.0f);
      Camera.main.transform.localRotationTransition(cameraEndTransform.localRotation, 2.0f);
   }

}
