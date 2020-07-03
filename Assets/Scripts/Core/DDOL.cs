using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Don't destroy this object, ever.
 */
public class DDOL : MonoBehaviour {
    // Start is called before the first frame update
    void Awake() { 
        DontDestroyOnLoad(gameObject);
    }
}
