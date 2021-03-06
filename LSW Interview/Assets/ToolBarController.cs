using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarController : MonoBehaviour {
    [SerializeField] int toolbarSize = 12;
    int selectedTool = 0;

    public Action<int> onChange;

    void Update () {
        float delta = Input.mouseScrollDelta.y;
        if (delta != 0) {
            if (delta > 0) {
                selectedTool += 1;
                selectedTool = (selectedTool >= toolbarSize ? 0 : selectedTool);
            } else {

                selectedTool -= 1;
                selectedTool = (selectedTool <= 0 ? toolbarSize - 1 : selectedTool);
            }
            Debug.Log (selectedTool);
            onChange?.Invoke (selectedTool);
        }
    }

    internal void Set (int id) {
        selectedTool = id;

    }
}