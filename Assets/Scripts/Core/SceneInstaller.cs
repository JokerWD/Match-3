using Dythervin.AutoAttach;
using Match3;
using UnityEngine;
using Zenject;

namespace Core
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField, Attach(Attach.Scene)] private ScoreCounter _scoreCounter;
        [SerializeField, Attach(Attach.Scene)] private Board _board;


        public override void InstallBindings()
        {
            Container.Bind<ScoreCounter>().FromInstance(_scoreCounter).AsSingle();
            Container.Bind<Board>().FromInstance(_board).AsSingle();
        }

    }
}
