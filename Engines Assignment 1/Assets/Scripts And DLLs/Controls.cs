using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputHandler
{
    // Command Design Patern
    public abstract class Command
    {
        protected static Controls ControlAccess;
        public abstract void Execute(GameObject obj);
    }
    public class Nothing : Command
    {
        public override void Execute(GameObject obj)
        { }
    }
    public class MoveForward : Command
    {
        public override void Execute(GameObject obj)
        {
            obj.transform.Translate(Time.deltaTime * 2 * -1.0f, 0, 0);
        }
    }
    public class MoveBackward : Command
    {
        public override void Execute(GameObject obj)
        {
            obj.transform.Translate(Time.deltaTime * 2 * 1.0f, 0, 0);

        }
    }
    public class TurnLeft : Command
    {
        public override void Execute(GameObject obj)
        {
            obj.transform.Rotate(0, Time.deltaTime * -150f, 0);

        }
    }
    public class TurnRight : Command
    {
        public override void Execute(GameObject obj)
        {
            obj.transform.Rotate(0, Time.deltaTime * 150f, 0);
        }
    }
    public class CreateHorse : Command
    {
        GameObject dummy;
        public override void Execute(GameObject obj)
        {
            dummy = GameObject.Instantiate(obj, obj.transform.position, obj.transform.rotation) as GameObject;
        }
    }

    public class Controls : MonoBehaviour
    {
        public GameObject player;
        public GameObject spawn1;

        private Stack<Command> undoStack;
        //~Player Movement~//
        public float speed = 2.0f;
        // Input information
        private Command CurrMove = new Nothing();
        private bool forwardPressed = false;
        private bool backwardPressed = false;
        private bool leftPressed = false;
        private bool rightPressed = false;
        ///Keybindings
        public KeyCode forwardButton = KeyCode.W;
        public KeyCode backwardButton = KeyCode.S;
        public KeyCode leftButton = KeyCode.A;
        public KeyCode rightButton = KeyCode.D;
        public KeyCode makeHorse = KeyCode.Q;

        public void handleInput()
        {
            // Toggle movement On
            if (Input.GetKeyDown(forwardButton))
                forwardPressed = true;
            if (Input.GetKeyDown(backwardButton))
                backwardPressed = true;
            if (Input.GetKeyDown(leftButton))
                leftPressed = true;
            if (Input.GetKeyDown(rightButton))
                rightPressed = true;

            // Toggle movement Off
            if (Input.GetKeyUp(forwardButton))
                forwardPressed = false;
            if (Input.GetKeyUp(backwardButton))
                backwardPressed = false;
            if (Input.GetKeyUp(leftButton))
                leftPressed = false;
            if (Input.GetKeyUp(rightButton))
                rightPressed = false;

            // Other Actions
            if (Input.GetKeyDown(makeHorse))
            {
                spawn1.transform.SetPositionAndRotation(player.transform.position, player.transform.rotation);
                Command tempHorse = new CreateHorse();
                print("madeHorse\n");
                //undoStack.Push(tempHorse);
                print("spawnedHorse\n");
                tempHorse.Execute(spawn1);
                print("madeHorseEnd\n");
            }

        }

        private void Move()
        {
            // Execute forward or backward movement
            if (forwardPressed)
                CurrMove = new MoveForward();
            else if (backwardPressed)
                CurrMove = new MoveBackward();
            CurrMove.Execute(player);
            CurrMove = new Nothing();

            // Execute left or right turning
            if (leftPressed)
                CurrMove = new TurnLeft();
            else if (rightPressed)
                CurrMove = new TurnRight();
            CurrMove.Execute(player);
            CurrMove = new Nothing();
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            handleInput();
            Move();
        }
    }

}