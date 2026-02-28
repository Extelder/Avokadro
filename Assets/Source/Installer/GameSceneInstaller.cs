using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;

    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(_camera);
    }
}