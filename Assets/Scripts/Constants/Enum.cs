public enum AttackMode {
	LightAttack = 0,
	MiddleAttack = 1,
	StrongAttack = 2,
}

public enum WrappedLayer {
	// pre-set layers
	Default = 0,
	TransparentFX = 1,
	Ignore_Raycast = 2,
	Water = 4,
	UI = 5,

	// customize layers
	Weapon_Layer = 8,
	Hitable_Layer = 9,
}