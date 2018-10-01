using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public abstract class Observer
    {
        public abstract void OnNotify();
    }

    //public class Box : Observer
    //{
    //    //The box gameobject which will do something
    //    GameObject horseobj;
    //    //What will happen when this box gets an event
    //    BoxEvents boxEvent;
    //
    //    public Box(GameObject horseobj, BoxEvents boxEvent)
    //    {
    //        this.horseobj = horseobj;
    //        this.boxEvent = boxEvent;
    //    }
    //
    //    //What the box will do if the event fits it (will always fit but you will probably change that on your own)
    //    public override void OnNotify()
    //    {
    //        Jump(boxEvent.GetJumpForce());
    //    }
    //
    //    //The box will always jump in this case
    //    void Jump(float jumpForce)
    //    {
    //        //If the box is close to the ground
    //        if (horseobj.transform.position.y < 0.70f)
    //        {
    //            horseobj.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
    //        }
    //    }
    //}

    public class WinCon : Observer
    {
        int horseNum;

        WinCon winEvent;

        public WinCon()
        {
        }

        public override void OnNotify()
        {
            horseNum++;
            Debug.Log(horseNum);
            if (horseNum >= 100)
            {
                WinGame();
            }
        }

        void WinGame()
        {
            //Debug.Log("YOU WIN");
            //Application.Quit();
        }
    }

    //public abstract class BoxEvents
    //{
    //    public abstract float GetJumpForce();
    //}
    //
    //public class JumpLittle : BoxEvents
    //{
    //    public override float GetJumpForce()
    //    {
    //        return 30f;
    //    }
    //}
}