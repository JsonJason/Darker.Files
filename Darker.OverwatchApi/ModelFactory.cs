using System;

namespace Darker.OverwatchApi
{
    public class ModelFactory
    {
        public static HeroSummary CreateHeroSummary(dynamic item)
        {
            return new HeroSummary
            {
                Id = item.id == null ? 0 : Int32.Parse(item.id.ToString()),
                Name = item.name,
                Description = item.description,
                Health = item.health == null ? 0 : Int32.Parse(item.health.ToString()),
                Armour = item.armour == null ? 0 : Int32.Parse(item.armour.ToString()),
                Shield = item.shield == null ? 0 : Int32.Parse(item.shield.ToString()),
                RealName = item.real_name,
                Age = item.age == null ? 0 : Int32.Parse(item.age.ToString()),
                Height = item.height,
                Affiliation = item.affiliation,
                Location = item.base_of_operations,
                DIfficulty = item.difficulty == null ? 0 : Int32.Parse(item.difficulty.ToString())
            };
        }
    }
}