using System;

// level -1 because level 1 has 0 bonus
[Serializable]
public struct LevelBasedInt
{
    public int baseValue;
    public int bonusPerLevel;
    public int Get(int level) { return baseValue + bonusPerLevel * (level - 1); }
}

[Serializable]
public struct LevelBasedLong
{
    public int baseValue;
    public int bonusPerLevel;
    public int Get(int level) { return baseValue + bonusPerLevel * (level - 1); }
}

[Serializable]
public struct LevelBasedFloat
{
    public int baseValue;
    public int bonusPerLevel;
    public int Get(int level) { return baseValue + bonusPerLevel * (level - 1); }
}
