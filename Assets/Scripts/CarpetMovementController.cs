using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class CarpetMovementController : MonoBehaviour
{
    public float speed;

    private LeanDragTranslate mLeanDragTranslate;
    
    private void FixedUpdate() {
        
        if (GameController.Instance.GameState == GameStates.Playing)
        {
            if (mLeanDragTranslate != null)
            {
                mLeanDragTranslate.enabled = true;
            }
            else
            {
                mLeanDragTranslate = GetComponent<LeanDragTranslate>();
            }

            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        }
        else
        {
            if (mLeanDragTranslate != null)
            {
                mLeanDragTranslate.enabled = false;
            }
            else
            {
                mLeanDragTranslate = GetComponent<LeanDragTranslate>();
            }
        }
    } 
    
}
