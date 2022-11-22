using ParanoidMann.Core;
using ParanoidMann.Core.PLog;

namespace ParanoidMann.Survivors.Game
{
	public class GameInstaller : SceneInstaller<GameInstaller>
	{
		protected override string SceneName => SceneNames.Game;

		public override void InstallBindings()
		{
			PLog.Info($"Started binding {GetType()}");

			SubscribeSceneLoading();

			PLog.Info($"Completed binding {GetType()}");
		}

		protected override void OnSceneLoaded()
		{
			Container.BindInterfacesAndSelfTo<GameSystemsBinder>().AsSingle();
			Container.Resolve<GameSystemsBinder>();
		}

		protected override void OnSceneUnloaded()
		{
			Container.Resolve<GameSystemsBinder>().Dispose();
			Container.Unbind<GameSystemsBinder>();
		}
	}
}