namespace HearthstoneCollections;

public enum Class
{
    Priest  = 1 << 0,
    Druid   = 1 << 1,
    Mage    = 1 << 2,
    Shaman  = 1 << 3,
    Warlock = 1 << 4,
    Rogue   = 1 << 5,
    Hunter  = 1 << 6,
    Paladin = 1 << 7,
    Warrior = 1 << 8,
    Neutral = 1 << 9,
}