using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agricultura : MonoBehaviour
{
    public void tradicional() {
        mainManager.Instance.agricultura = false;
        print("Agricultura tradicional: " + mainManager.Instance.agricultura);
    }

    public void regenerativa() {
        mainManager.Instance.agricultura = true;
        print("Agricultura regenerativa: " + mainManager.Instance.agricultura);
    }
}
