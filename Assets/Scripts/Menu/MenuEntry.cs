using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/**
 * A simple text menu entry.
 */
public class MenuEntry : MonoBehaviour {

    [Header("Settings")]
    [SerializeField] private bool isSelected = false;
    [SerializeField] private Color highlightColour;
    [SerializeField] private Color dullColour;
    [SerializeField] private UnityEvent onSelect;

    [Header("References")]
    [SerializeField] private Text textRef;

    // Start is called before the first frame update
    void Start() {
        // Set whether or not this should be selected.
        Highlight(this.isSelected);
    }

    /**
     * Make our selection and call our event.
     */
    public void Select() {
        onSelect?.Invoke();
    }

    /**
     * Highlight our menu entry.
     */
    public void Highlight(bool isSelected = true) {
        this.textRef.color = (isSelected ? highlightColour : dullColour);
    }
}
