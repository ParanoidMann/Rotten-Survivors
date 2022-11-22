using Zenject;
using Leopotam.Ecs;

using ParanoidMann.Core;
using ParanoidMann.Survivors.Game;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

namespace ParanoidMann.Survivors
{
	public class ProjectInstaller : MonoInstaller
	{
		private EcsWorld _ecsWorld;

		public override void InstallBindings()
		{
			Addressables.InitializeAsync().WaitForCompletion();

			_ecsWorld = new EcsWorld();
			Container.Bind<EcsWorld>().FromInstance(_ecsWorld).AsSingle();

			CoreInstaller.Install(Container);
			GameInstaller.Install(Container);

			SceneManager.LoadSceneAsync(SceneNames.Game, LoadSceneMode.Additive).completed += OnSceneLoaded;
		}

		private void OnSceneLoaded(AsyncOperation b)
		{
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneNames.Game));
		}

		private void OnDestroy()
		{
			_ecsWorld.Destroy();
		}
	}
}