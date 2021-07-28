using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class MenuFeedbacks : MonoBehaviour
{
    [SerializeField] private MMFeedbacks menuFeedbacks;

    private void Awake() {
        menuFeedbacks.PlayFeedbacks();
    }
}
