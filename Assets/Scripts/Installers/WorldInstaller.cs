using TT.Core.Chanels;
using UnityEngine;
using Zenject;

namespace TT.Core.Installers
{
    public class WorldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputChanel>().AsSingle();
        }
    }
}