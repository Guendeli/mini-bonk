using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Characters.Enemies;
using Code.Gameplay.Characters.Enemies.Configs;
using Code.Gameplay.Characters.Heroes.Configs;
using Code.Gameplay.PickUps;
using Code.Gameplay.PickUps.Configs;
using Code.Infrastructure.AssetManagement;

namespace Code.Infrastructure.ConfigsManagement
{
	public class ConfigsService : IConfigsService
	{
		private readonly IAssetsService _assets;

		private Dictionary<EnemyId, EnemyConfig> _enemiesById = new();
		private Dictionary<PickUpId, PickUpConfig> _pickupsById = new();

		public HeroConfig HeroConfig { get; private set; }
		
		public ProgressionConfig ProgressionConfig { get; private set; }

		public ConfigsService(IAssetsService assets)
		{
			_assets = assets;
		}
		
		public void Load()
		{
			LoadHeroConfig();
			LoadEnemyConfigs();
			LoadPickUpConfigs();
			LoadProgressionConfig();
		}

		private void LoadPickUpConfigs()
		{
			var pickUpConfigs = _assets.LoadAssetsFromResources<PickUpConfig>(Constants.CONFIG_PICKUPS_PATH);
			_pickupsById = pickUpConfigs.ToList().ToDictionary(x => x.Id, x => x);
		}

		private void LoadHeroConfig()
		{
			HeroConfig = _assets.LoadAssetFromResources<HeroConfig>(Constants.CONFIG_HERO_PATH);
		}

		private void LoadEnemyConfigs()
		{
			var enemyConfigs = _assets.LoadAssetsFromResources<EnemyConfig>(Constants.CONFIG_ENEMIES_PATH);
			_enemiesById = enemyConfigs.ToList().ToDictionary(x => x.Id, x => x);
		}

		private void LoadProgressionConfig()
		{
			ProgressionConfig = _assets.LoadAssetFromResources<ProgressionConfig>(Constants.CONFIG_PROGRESSION_PATH);
		}

		public EnemyConfig GetEnemyConfig(EnemyId id)
		{
			if (_enemiesById.TryGetValue(id, out EnemyConfig enemyConfig))
				return enemyConfig;

			throw new KeyNotFoundException($"Enemy config with id {id} not found");
		}
		
		public PickUpConfig GetPickUpConfig(PickUpId id)
		{
			if (_pickupsById.TryGetValue(id, out PickUpConfig pickUpConfig))
				return pickUpConfig;

			throw new KeyNotFoundException($"PickUp config with id {id} not found");
		}
	}
}