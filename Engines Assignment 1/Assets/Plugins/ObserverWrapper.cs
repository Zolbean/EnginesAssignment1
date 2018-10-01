using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace Observing
{

    public class ObserverWrapper : MonoBehaviour
    {

        const string DLLname = "ObserverDLL";

        [DllImport(DLLname)]
        public static extern void reset();

        [DllImport(DLLname)]
        public static extern int Increment();

        [DllImport(DLLname)]
        public static extern void decrement();
        
    }
}
