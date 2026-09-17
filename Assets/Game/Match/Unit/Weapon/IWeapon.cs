public interface IWeapon
{
	string Name { get; }
	WeaponClass Class { get; }
	int MinRange { get; } // 1 = solo adyacente
	int MaxRange { get; } // 1 = solo adyacente; >1 = indirecto
	int BaseDamage { get; }
	int? AmmoCost { get; } // null = munición infinita (arma secundaria débil típica)

	bool IsUsableAgainst(Unit target);
}