using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSizeManager : MonoBehaviour
{
    public TextMeshProUGUI[] TextObjects;

    void Awake() {
        // Check for valid object reference
        if (TextObjects == null || TextObjects.Length == 0) return;

        // Find the best candidate for auto sizing
        int candidateIndex = 0;
        float maxPreferredWidth = 0f;
        for (int i = 0; i < TextObjects.Length; i++) {
            float preferredWidth = TextObjects[i].preferredWidth;
            if (preferredWidth > maxPreferredWidth) {
                maxPreferredWidth = preferredWidth;
                candidateIndex = i;
            }
        }

        // Force an update of the candidate text object so we can retrieve its optimum point size.
        TextObjects[candidateIndex].enableAutoSizing = true;
        TextObjects[candidateIndex].ForceMeshUpdate();
        float optimumPointSize = TextObjects[candidateIndex].fontSize;
 
        // Disable auto size on our test candidate
        TextObjects[candidateIndex].enableAutoSizing = false;
 
        // Iterate over all other text objects to set the point size
        for (int i = 0; i < TextObjects.Length; i++) {
            TextObjects[i].fontSize = optimumPointSize;
        }
    }
}
