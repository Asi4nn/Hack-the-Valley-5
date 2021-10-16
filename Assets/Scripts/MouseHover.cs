using System.Collections;
using UnityEngine;

public class MouseHover : MonoBehaviour {
  void Start() {
    GetComponent<Renderer>().material.color = Color.white;
  }

  void onMouseEnter() {
    GetComponent<Renderer>().material.color = Color.black;
  }

  void onMouseExit() {
    GetComponent<Renderer>().material.color = Color.white;
  }
}
