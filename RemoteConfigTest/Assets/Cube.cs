using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

public class Cube : MonoBehaviour
{
  public struct userAttributes { }
  public struct appAttributes { }

  [SerializeField] private bool isBlue;

  [SerializeField] private Material blueMaterial;
  [SerializeField] private Material redMaterial;
  [SerializeField] private Renderer rend;

  void Awake()
  {
    ConfigManager.FetchCompleted += SetColor;
    ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
  }

  private void SetColor(ConfigResponse response)
  {
    isBlue = ConfigManager.appConfig.GetBool("cubeIsBlue");
    Debug.Log(isBlue);
    if (isBlue)
    {
      rend.material = blueMaterial;
    }
    else
    {
      rend.material = redMaterial;
    }
  }

  void Update()
  {
    //Debug.Log(isBlue);
  }
}
