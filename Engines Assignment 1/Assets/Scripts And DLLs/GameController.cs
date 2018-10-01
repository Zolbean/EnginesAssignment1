using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputHandler;

namespace ObserverPattern
{
    public class GameController : MonoBehaviour
    {
        Controls controlAccess = new Controls();

        public GameObject playerobj;

        public GameObject horseobj;

        //Will send notifications that something has happened to whoever is interested
        Subject subject = new Subject();

        void Start()
        {
            //Create boxes that can observe events and give them an event to do
            //Box box1 = new Box(horseobj, new JumpLittle());
            WinCon condition = new WinCon();

            //Add box to list of subjects
            subject.AddObserver(condition);
        }


        void Update()
        {
            //if (playerobj.transform.position.y < 10)
            //{
            //    subject.Notify();
            //}
            //print(controlAccess.isExecuted);
            if (controlAccess.isExecuted == true)
            {
                print("on");
                controlAccess.isExecuted = false;
                print("off");
                subject.Notify();
            }
        }
    }

    public class Subject
    {
        //A list with observers that are waiting for something to happen
        List<Observer> observers = new List<Observer>();

        //Send notifications if something has happened
        public void Notify()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                //Notify all observers even though some may not be interested in what has happened
                //Each observer should check if it is interested in this event
                observers[i].OnNotify();
            }
        }

        //Add observer to the list
        public void AddObserver(Observer observer)
        {
            observers.Add(observer);
        }

        //Remove observer from the list
        public void RemoveObserver(Observer observer)
        {
        }
    }
}