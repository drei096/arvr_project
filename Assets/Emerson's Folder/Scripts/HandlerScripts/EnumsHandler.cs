using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//General Identification of the pool type
public enum PoolType
{
    NONE = -1,
    POKEMON,
    POKEBALL,
    TRAINER

};

public enum PokemonCode
{
    // Write here Pokemon Names
    NONE = -1,
    BULBASAUR,
    CHARMANDER,
    SQUIRTLE,
    PIDGEY,
    PIKACHU,
    NIDORANF,
    VULPIX,
    ODDISH,
    PSYDUCK,
    GROWLITHE,
    POLIWAG,
    MACHOP,
    FARFETCHD,
    SEEL,
    CUEBONE,
    EEVEE
};

public enum TypeCode
{
    // Write here Type Names
    NONE = -1,
    NORMAL,
    FIRE,
    WATER,
    ELECTRIC,
    GRASS,
    FIGHTING,
    POISON,
    GROUND,
    FLYING,
    PSYCHIC
};

public enum PokeballCode
{
    // Write here Pokeball Names
    NONE = -1,
    GREATBALL
};

public enum MoveCode
{
    // Write here Move Names
    NONE = -1,
    SCRATCH,
    EMBER,
    TACKLE,
    WATER_GUN,
    VINE_WHIP,
    GUST,
    THUNDER_SHOCK,
    QUICK_ATTACK,
    POISON_STING,
    ABSORB,
    ACID,
    CONFUSION,
    BITE,
    POUND,
    KARATE_CHOP,
    LOW_KICK,
    PECK,
    FURY_ATTACK,
    HEADBUTT,
    BONE_CLUB
};

public enum TrainerCode
{
    // Write here Trainer Names
    NONE = -1,
    CYRUS, AQUA, SERENA, GIOVANNI, CALEM
};

public enum EncounterType
{
    
    NONE = -1,
    POKEMON_ENCOUNTER,
    TRAINER_ENCOUNTER
};

public class EnumsHandler
{
    // Singleton
    private static EnumsHandler instance = null;
    private static int HP_MULTIPLIER = 5;

    public static EnumsHandler Instance
    {
        get
        {
            if (instance == null)
                instance = new EnumsHandler();
            return instance;
        }
    }
    // Write here the permanent data info
    public static void AddPokemonData(ref Dictionary<PokemonCode, StructHandler.PokemonInfo> pokemonInfo)
    {
        StructHandler.PokemonInfo temp = new StructHandler.PokemonInfo()
        {
            name = "Bulbasaur",
            pokemonCode = PokemonCode.BULBASAUR,
            type = "Grass",
            typeCode = TypeCode.GRASS,
            healthPoints = 45 * HP_MULTIPLIER,
            description = "A strange seed was planted on its back at birth. The plant sprouts and grows with this POKÈMON.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.TACKLE].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.VINE_WHIP]
        };
        pokemonInfo.Add(PokemonCode.BULBASAUR, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Charmander",
            pokemonCode = PokemonCode.CHARMANDER,
            type = "Fire",
            typeCode = TypeCode.FIRE,
            healthPoints = 45 * HP_MULTIPLIER,
            description = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.SCRATCH].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.EMBER].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.CHARMANDER, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Squirtle",
            pokemonCode = PokemonCode.SQUIRTLE,
            type = "Water",
            typeCode = TypeCode.WATER,
            healthPoints = 44 * HP_MULTIPLIER,
            description = "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.TACKLE].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.WATER_GUN].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.SQUIRTLE, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Pidgey",
            pokemonCode = PokemonCode.PIDGEY,
            type = "Flying",
            typeCode = TypeCode.FLYING,
            healthPoints = 40 * HP_MULTIPLIER,
            description = "A common sight in forests and woods. It flaps its wings at ground level to kick up blinding sand",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.TACKLE].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.GUST].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.PIDGEY, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Pikachu",
            pokemonCode = PokemonCode.PIKACHU,
            type = "Electric",
            typeCode = TypeCode.ELECTRIC,
            healthPoints = 40 * HP_MULTIPLIER,
            description = "When several of these POKÈMON gather, their electricity could build and cause lightning storms.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.THUNDER_SHOCK].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.QUICK_ATTACK].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.PIKACHU, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Nidoran",
            pokemonCode = PokemonCode.NIDORANF,
            type = "Poison",
            typeCode = TypeCode.POISON,
            healthPoints = 55 * HP_MULTIPLIER,
            description = "Although small, its venomous barbs render this POKÈMON dangerous. The female has smaller horns.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.POISON_STING].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.LOW_KICK].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.NIDORANF, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Vulpix",
            pokemonCode = PokemonCode.VULPIX,
            type = "Fire",
            typeCode = TypeCode.FIRE,
            healthPoints = 38 * HP_MULTIPLIER,
            description = "At the time of birth, it has just one tail. The tail splits from its tip as it grows older.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.EMBER].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.QUICK_ATTACK].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.VULPIX, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Oddish",
            pokemonCode = PokemonCode.ODDISH,
            type = "Grass",
            typeCode = TypeCode.GRASS,
            healthPoints = 45 * HP_MULTIPLIER,
            description = "During the day, it keeps its face buried in the ground. At night, it wanders around sowing its seeds.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.ABSORB].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.ACID].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.ODDISH, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Psyduck",
            pokemonCode = PokemonCode.PSYDUCK,
            type = "Water",
            typeCode = TypeCode.WATER,
            healthPoints = 50 * HP_MULTIPLIER,
            description = "While lulling its enemies with its vacant look, this wily POKÈMON will use psychokinetic powers.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.SCRATCH].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.CONFUSION].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.PSYDUCK, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Growlithe",
            pokemonCode = PokemonCode.GROWLITHE,
            type = "Fire",
            typeCode = TypeCode.FIRE,
            healthPoints = 55 * HP_MULTIPLIER,
            description = "Very protective of its territory. It will bark and bite to repel intruders from its space.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.EMBER].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.BITE].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.GROWLITHE, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Poliwag",
            pokemonCode = PokemonCode.POLIWAG,
            type = "Water",
            typeCode = TypeCode.WATER,
            healthPoints = 40 * HP_MULTIPLIER,
            description = "For Poliwag, swimming is easier than walking. The swirl pattern on its belly is actually part of the PokÈmonís innards showing through the skin. ",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.WATER_GUN].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.POUND].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.POLIWAG, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Machop",
            pokemonCode = PokemonCode.MACHOP,
            type = "Fighting",
            typeCode = TypeCode.FIGHTING,
            healthPoints = 70 * HP_MULTIPLIER,
            description = "Loves to build its muscles. It trains in all styles of martial arts to become even stronger.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.KARATE_CHOP].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.LOW_KICK].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.MACHOP, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Farfetch'd",
            pokemonCode = PokemonCode.FARFETCHD,
            type = "Flying",
            typeCode = TypeCode.FLYING,
            healthPoints = 52 * HP_MULTIPLIER,
            description = "The sprig of green onions it holds is its weapon. It is used much like a metal sword.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.PECK].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.FURY_ATTACK].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.FARFETCHD, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Seel",
            pokemonCode = PokemonCode.SEEL,
            type = "Water",
            typeCode = TypeCode.WATER,
            healthPoints = 62 * HP_MULTIPLIER,
            description = "The protruding horn on its head is very hard. It is used for bashing through thick ice.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.HEADBUTT].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.WATER_GUN].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.SEEL, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Cuebone",
            pokemonCode = PokemonCode.CUEBONE,
            type = "Ground",
            typeCode = TypeCode.GROUND,
            healthPoints = 50 * HP_MULTIPLIER,
            description = "Because it never removes its skull helmet, no one has ever seen this POKÈMONís real face.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.HEADBUTT].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.BONE_CLUB].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.CUEBONE, temp);

        temp = new StructHandler.PokemonInfo()
        {
            name = "Eevee",
            pokemonCode = PokemonCode.EEVEE,
            type = "Normal",
            typeCode = TypeCode.NORMAL,
            healthPoints = 55 * HP_MULTIPLIER,
            description = "Its genetic code is irregular. It may mutate if it is exposed to radiation from element STONEs.",
            move1 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.TACKLE].ShallowCopy(),
            move2 = (StructHandler.MoveInfo)Pokedex.Instance.moveInfo[MoveCode.QUICK_ATTACK].ShallowCopy()
        };
        pokemonInfo.Add(PokemonCode.EEVEE, temp);
    }

    // Write here the permanent data info
    
    public static void AddPokeballData(ref Dictionary<PokeballCode, StructHandler.PokeballInfo> pokeballInfo)
    {
        StructHandler.PokeballInfo temp = new StructHandler.PokeballInfo()
        {
            name = "Great Ball", pokeballCode = PokeballCode.GREATBALL, 
            successRate = 0.75f, typeSpecialty = TypeCode.NONE,
            description = "What a ball!"
        };
        pokeballInfo.Add(PokeballCode.GREATBALL, temp);
    }
    // Write here the permanent data info
    public static void AddMoveData(ref Dictionary<MoveCode, StructHandler.MoveInfo> moveInfo)
    {
        StructHandler.MoveInfo temp;
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Scratch", type = "Normal",
            typeCode = TypeCode.NORMAL, 
            damage = 40, description = "Scratches with sharp claws."
        };
        moveInfo.Add(MoveCode.SCRATCH, temp);
        moveInfo[MoveCode.SCRATCH].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.SCRATCH].damage);
        };

        temp = new StructHandler.MoveInfo()
        {
            name = "Ember",
            type = "Fire",
            typeCode = TypeCode.FIRE,
            damage = 40,
            description = "An attack that may inflict a burn."
        };
        moveInfo.Add(MoveCode.EMBER, temp);
        moveInfo[MoveCode.EMBER].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.EMBER].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Tackle",
            type = "Normal",
            typeCode = TypeCode.NORMAL,
            damage = 40,
            description = "A full-body charge attack."
        };
        moveInfo.Add(MoveCode.TACKLE, temp);
        moveInfo[MoveCode.TACKLE].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.TACKLE].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Water Gun",
            type = "Water",
            typeCode = TypeCode.WATER,
            damage = 40,
            description = "Squirts water to attack."
        };
        moveInfo.Add(MoveCode.WATER_GUN, temp);
        moveInfo[MoveCode.WATER_GUN].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.WATER_GUN].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Vine Whip",
            type = "Grass",
            typeCode = TypeCode.GRASS,
            damage = 45,
            description = "Whips the foe with slender vines."
        };
        moveInfo.Add(MoveCode.VINE_WHIP, temp);
        moveInfo[MoveCode.VINE_WHIP].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.VINE_WHIP].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Gust",
            type = "Flying",
            typeCode = TypeCode.FLYING,
            damage = 40,
            description = "Whips up a strong gust of wind."
        };
        moveInfo.Add(MoveCode.GUST, temp);
        moveInfo[MoveCode.GUST].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.GUST].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Thunder Shock",
            type = "Electric",
            typeCode = TypeCode.ELECTRIC,
            damage = 80,
            description = "A jolt of electricity is hurled at the foe.",
        };
        moveInfo.Add(MoveCode.THUNDER_SHOCK, temp);
        moveInfo[MoveCode.THUNDER_SHOCK].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.THUNDER_SHOCK].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Quick Attack",
            type = "Normal",
            typeCode = TypeCode.NORMAL,
            damage = 40,
            description = "Lets the user get in the first hit."
        };
        moveInfo.Add(MoveCode.QUICK_ATTACK, temp);
        moveInfo[MoveCode.QUICK_ATTACK].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.QUICK_ATTACK].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Poison Sting",
            type = "Poison",
            typeCode = TypeCode.POISON,
            damage = 25,
            description = "An attack that poisons the target."
        };
        moveInfo.Add(MoveCode.POISON_STING, temp);
        moveInfo[MoveCode.POISON_STING].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.POISON_STING].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Absorb",
            type = "Grass",
            typeCode = TypeCode.GRASS,
            damage = 20,
            description = "An attack that absorbs half the damage inflicted."
        };
        moveInfo.Add(MoveCode.ABSORB, temp);
        moveInfo[MoveCode.ABSORB].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.ABSORB].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Acid",
            type = "Poison",
            typeCode = TypeCode.POISON,
            damage = 40,
            description = "Sprays a hide-melting acid."
        };
        moveInfo.Add(MoveCode.ACID, temp);
        moveInfo[MoveCode.ACID].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.ACID].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Confusion",
            type = "Psychic",
            typeCode = TypeCode.PSYCHIC,
            damage = 40,
            description = "An attack that may cause confusion."
        };
        moveInfo.Add(MoveCode.CONFUSION, temp);
        moveInfo[MoveCode.CONFUSION].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.CONFUSION].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Bite",
            type = "Normal",
            typeCode = TypeCode.NORMAL,
            damage = 60,
            description = "The user bites with vicious fangs."
        };
        moveInfo.Add(MoveCode.BITE, temp);
        moveInfo[MoveCode.BITE].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.BITE].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Pound",
            type = "Normal",
            typeCode = TypeCode.NORMAL,
            damage = 40,
            description = "Pounds with forelegs or tail."
        };
        moveInfo.Add(MoveCode.POUND, temp);
        moveInfo[MoveCode.POUND].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.POUND].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Karate Chop",
            type = "50",
            typeCode = TypeCode.NORMAL,
            damage = 50,
            description = "The foe is attacked with a sharp chop."
        };
        moveInfo.Add(MoveCode.KARATE_CHOP, temp);
        moveInfo[MoveCode.KARATE_CHOP].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.KARATE_CHOP].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Low Kick",
            type = "Fighting",
            typeCode = TypeCode.FIGHTING,
            damage = 50,
            description = "A low, tripping kick"
        };
        moveInfo.Add(MoveCode.LOW_KICK, temp);
        moveInfo[MoveCode.LOW_KICK].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.LOW_KICK].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Peck", type = "Flying",
            typeCode = TypeCode.FLYING, 
            damage = 35, description = "The foe is jabbed with a sharply pointed beak or horn."
        };
        moveInfo.Add(MoveCode.PECK, temp);
        moveInfo[MoveCode.PECK].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.PECK].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Fury Attack",
            type = "Normal",
            typeCode = TypeCode.NORMAL,
            damage = 15,
            description = "The foe is jabbed repeatedly with a horn or beak."
        };
        moveInfo.Add(MoveCode.FURY_ATTACK, temp);
        moveInfo[MoveCode.FURY_ATTACK].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.FURY_ATTACK].damage);
        };
        
        temp = new StructHandler.MoveInfo()
        {
            name = "Headbutt",
            type = "Normal",
            typeCode = TypeCode.NORMAL,
            damage = 70,
            description = "The user sticks its head out and rams."
        };
        moveInfo.Add(MoveCode.HEADBUTT, temp);
        moveInfo[MoveCode.HEADBUTT].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.HEADBUTT].damage);
        };

        temp = new StructHandler.MoveInfo()
        {
            name = "Bone Club",
            type = "Ground",
            typeCode = TypeCode.GROUND,
            damage = 65,
            description = "Clubs the foe with a bone."
        };
        moveInfo.Add(MoveCode.BONE_CLUB, temp);
        moveInfo[MoveCode.BONE_CLUB].PerformMove += delegate(ref List<StructHandler.PokemonInfo> x, int index)
        {
            x[index].SetHealth(Pokedex.Instance.moveInfo[MoveCode.BONE_CLUB].damage);
        };

    }
    // Write here the permanent data info
    public static void AddTrainerData(ref Dictionary<TrainerCode, StructHandler.TrainerInfo> trainerInfo)
    {
        StructHandler.TrainerInfo temp = new StructHandler.TrainerInfo()
        {
            name = "Calem", description = "Normal Kid, very good!@", trainerCode = TrainerCode.CALEM,
            pokemonParty = new List<StructHandler.PokemonInfo>()
        };
        trainerInfo.Add(TrainerCode.CALEM, temp);
        
        temp = new StructHandler.TrainerInfo()

        {
            name = "Giovanni", description = "Normal Kid, very good!@", trainerCode = TrainerCode.GIOVANNI,
            pokemonParty = new List<StructHandler.PokemonInfo>()
        };
        trainerInfo.Add(TrainerCode.GIOVANNI, temp);

        temp = new StructHandler.TrainerInfo()
        {
            name = "Serena", description = "Normal Kid, very good!@", trainerCode = TrainerCode.SERENA,
            pokemonParty = new List<StructHandler.PokemonInfo>()
        };
        trainerInfo.Add(TrainerCode.SERENA, temp);

        temp = new StructHandler.TrainerInfo()
        {
            name = "Cyrus", description = "Normal Kid, very good!@", trainerCode = TrainerCode.CYRUS,
            pokemonParty = new List<StructHandler.PokemonInfo>()
        };
        trainerInfo.Add(TrainerCode.CYRUS, temp);

        temp = new StructHandler.TrainerInfo()
        {
            name = "Aqua", description = "Normal Kid, very good!@", trainerCode = TrainerCode.AQUA,
            pokemonParty = new List<StructHandler.PokemonInfo>()
        };
        trainerInfo.Add(TrainerCode.AQUA, temp);
    }
}
