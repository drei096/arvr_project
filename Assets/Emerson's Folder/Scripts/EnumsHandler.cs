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
    ODDISH, VULPIX, GROWLITHE, CHARMANDER, NIDORANF, CUEBONE, SEEL, NIDORANM, MACHOP,
    FARFETCHD, PSYDUCK, SQUIRTLE, PIDGEY, EEVEE, PIKACHU, POLIWAG
};

public enum TypeCode
{
    // Write here Type Names
    NONE = -1,
    GRASS, FIRE, POISON, GROUND, WATER, FIGHTING, FLYING, ELECTRIC, NORMAL, PSYCHIC
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
    SCRATCH, SAND_ATTACK, HEADBUTT, TACKLE, TAIL_WHIP, POISON_STING, LEER, GROWL,
    EMBER, WATER_GUN, PECK, LOW_KICK, ABSORB, GROWTH, THUNDER_SHOCK, HYPNOSIS, MUD_SLAP
};

public enum TrainerCode
{
    // Write here Trainer Names
    NONE = -1,
    Joey
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
            name = "Oddish", pokemonCode = PokemonCode.ODDISH, 
            type = "Grass", typeCode = TypeCode.GRASS, 
            healthPoints = 100, 
            description = "During the day, it keeps its face buried in the ground. At night, it wanders around sowing its seeds.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.ABSORB],
            move2 = Pokedex.Instance.moveInfo[MoveCode.POISON_STING]
        };
        pokemonInfo.Add(PokemonCode.ODDISH, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Vulpix", pokemonCode = PokemonCode.VULPIX, 
            type = "Fire", typeCode = TypeCode.FIRE, 
            healthPoints = 38, 
            description = "At the time of birth, it has just one tail. The tail splits from its tip as it grows older.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.EMBER],
            move2 = Pokedex.Instance.moveInfo[MoveCode.GROWL]
        };
        pokemonInfo.Add(PokemonCode.VULPIX, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Growlithe", pokemonCode = PokemonCode.GROWLITHE, 
            type = "Fire", typeCode = TypeCode.FIRE, 
            healthPoints = 55, 
            description = "Very protective of its territory. It will bark and bite to repel intruders from its space.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.EMBER],
            move2 = Pokedex.Instance.moveInfo[MoveCode.SAND_ATTACK]
        };
        pokemonInfo.Add(PokemonCode.GROWLITHE, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Charmander", pokemonCode = PokemonCode.CHARMANDER, 
            type = "Fire", typeCode = TypeCode.FIRE, 
            healthPoints = 45, 
            description = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.GROWL],
            move2 = Pokedex.Instance.moveInfo[MoveCode.GROWTH]
        };
        pokemonInfo.Add(PokemonCode.CHARMANDER, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "NidoranF", pokemonCode = PokemonCode.NIDORANF, 
            type = "Poison", typeCode = TypeCode.POISON, 
            healthPoints = 55, 
            description = "Although small, its venomous barbs render this POKÈMON dangerous. The female has smaller horns.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.GROWL],
            move2 = Pokedex.Instance.moveInfo[MoveCode.POISON_STING]
        };
        pokemonInfo.Add(PokemonCode.NIDORANF, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Cuebone", pokemonCode = PokemonCode.CUEBONE, 
            type = "Ground", typeCode = TypeCode.GROUND, 
            healthPoints = 50, 
            description = "Because it never removes its skull helmet, no one has ever seen this POKÈMONís real face.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.GROWL],
            move2 = Pokedex.Instance.moveInfo[MoveCode.MUD_SLAP]
        };
        pokemonInfo.Add(PokemonCode.CUEBONE, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Seel", pokemonCode = PokemonCode.SEEL, 
            type = "Water", typeCode = TypeCode.WATER, 
            healthPoints = 62, 
            description = "The protruding horn on its head is very hard. It is used for bashing through thick ice.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.HEADBUTT],
            move2 = Pokedex.Instance.moveInfo[MoveCode.TAIL_WHIP]
        };
        pokemonInfo.Add(PokemonCode.SEEL, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "NidoranM", pokemonCode = PokemonCode.NIDORANM, 
            type = "Poison", typeCode = TypeCode.POISON, 
            healthPoints = 46, 
            description = "Stiffens its ears to sense danger. The larger its horns, the more powerful its secreted venom.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.LEER],
            move2 = Pokedex.Instance.moveInfo[MoveCode.MUD_SLAP]
        };
        pokemonInfo.Add(PokemonCode.NIDORANM, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Machop", pokemonCode = PokemonCode.MACHOP, 
            type = "Fighting", typeCode = TypeCode.FIGHTING, 
            healthPoints = 70, 
            description = "Loves to build its muscles. It trains in all styles of martial arts to become even stronger.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.LEER],
            move2 = Pokedex.Instance.moveInfo[MoveCode.LOW_KICK]
        };
        pokemonInfo.Add(PokemonCode.MACHOP, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Farfetch'd", pokemonCode = PokemonCode.FARFETCHD, 
            type = "Flying", typeCode = TypeCode.FLYING, 
            healthPoints = 52, 
            description = "The sprig of green onions it holds is its weapon. It is used much like a metal sword.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.PECK],
            move2 = Pokedex.Instance.moveInfo[MoveCode.SAND_ATTACK]
        };
        pokemonInfo.Add(PokemonCode.FARFETCHD, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Psyduck", pokemonCode = PokemonCode.PSYDUCK, 
            type = "Water", typeCode = TypeCode.WATER, 
            healthPoints = 50, 
            description = "While lulling its enemies with its vacant look, this wily POKÈMON will use psychokinetic powers.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.SCRATCH],
            move2 = Pokedex.Instance.moveInfo[MoveCode.TAIL_WHIP]
        };
        pokemonInfo.Add(PokemonCode.PSYDUCK, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Squirtle", pokemonCode = PokemonCode.SQUIRTLE, 
            type = "Water", typeCode = TypeCode.WATER, 
            healthPoints = 44, 
            description = "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.TACKLE],
            move2 = Pokedex.Instance.moveInfo[MoveCode.TAIL_WHIP]
        };
        pokemonInfo.Add(PokemonCode.SQUIRTLE, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Pidgey", pokemonCode = PokemonCode.PIDGEY, 
            type = "Flying", typeCode = TypeCode.FLYING, 
            healthPoints = 40, 
            description = "A common sight in forests and woods. It flaps its wings at ground level to kick up blinding sand.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.TACKLE],
            move2 = Pokedex.Instance.moveInfo[MoveCode.LEER]
        };
        pokemonInfo.Add(PokemonCode.PIDGEY, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Eevee", pokemonCode = PokemonCode.EEVEE, 
            type = "Normal", typeCode = TypeCode.NORMAL, 
            healthPoints = 55, 
            description = "Its genetic code is irregular. It may mutate if it is exposed to radiation from element STONEs.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.TACKLE],
            move2 = Pokedex.Instance.moveInfo[MoveCode.HYPNOSIS]
        };
        pokemonInfo.Add(PokemonCode.EEVEE, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Pikachu", pokemonCode = PokemonCode.PIKACHU, 
            type = "Electric", typeCode = TypeCode.ELECTRIC, 
            healthPoints = 35, 
            description = "When several of these POKÈMON gather, their electricity could build and cause lightning storms.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.THUNDER_SHOCK],
            move2 = Pokedex.Instance.moveInfo[MoveCode.SCRATCH]
        };
        pokemonInfo.Add(PokemonCode.PIKACHU, temp);
        temp = new StructHandler.PokemonInfo()
        {
            name = "Poliwag", pokemonCode = PokemonCode.POLIWAG, 
            type = "Water", typeCode = TypeCode.WATER, 
            healthPoints = 40, 
            description = "For Poliwag, swimming is easier than walking. The swirl pattern on its belly is actually part of the PokÈmonís innards showing through the skin.",
            move1 = Pokedex.Instance.moveInfo[MoveCode.WATER_GUN],
            move2 = Pokedex.Instance.moveInfo[MoveCode.TAIL_WHIP]
        };
        pokemonInfo.Add(PokemonCode.POLIWAG, temp);
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
        StructHandler.MoveInfo temp = new StructHandler.MoveInfo()
        {
            name = "Scratch", type = "Normal",
            typeCode = TypeCode.NORMAL, 
            damage = 40, description = ""
        };
        moveInfo.Add(MoveCode.SCRATCH, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Sand Attack", type = "Normal",
            typeCode = TypeCode.NORMAL, 
            damage = 0, description = ""
        };
        moveInfo.Add(MoveCode.SAND_ATTACK, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Headbutt", type = "Normal",
            typeCode = TypeCode.NORMAL, 
            damage = 70, description = ""
        };
        moveInfo.Add(MoveCode.HEADBUTT, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Tackle", type = "Normal",
            typeCode = TypeCode.NORMAL, 
            damage = 40, description = ""
        };
        moveInfo.Add(MoveCode.TACKLE, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Tail Whip", type = "Normal",
            typeCode = TypeCode.NORMAL, 
            damage = 0, description = ""
        };
        moveInfo.Add(MoveCode.TAIL_WHIP, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Poison Sting", type = "Poison",
            typeCode = TypeCode.POISON, 
            damage = 0, description = ""
        };
        moveInfo.Add(MoveCode.POISON_STING, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Leer", type = "Normal",
            typeCode = TypeCode.NORMAL, 
            damage = 0, description = ""
        };
        moveInfo.Add(MoveCode.LEER, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Growl", type = "Normal",
            typeCode = TypeCode.NORMAL, 
            damage = 0, description = ""
        };
        moveInfo.Add(MoveCode.GROWL, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Ember", type = "Fire",
            typeCode = TypeCode.FIRE, 
            damage = 40, description = ""
        };
        moveInfo.Add(MoveCode.EMBER, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Water Gun", type = "Water",
            typeCode = TypeCode.WATER, 
            damage = 40, description = ""
        };
        moveInfo.Add(MoveCode.WATER_GUN, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Peck", type = "Flying",
            typeCode = TypeCode.FLYING, 
            damage = 35, description = ""
        };
        moveInfo.Add(MoveCode.PECK, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Low Kick", type = "Fighting",
            typeCode = TypeCode.FIGHTING, 
            damage = 0, description = ""
        };
        moveInfo.Add(MoveCode.LOW_KICK, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Absorb", type = "Grass",
            typeCode = TypeCode.GRASS, 
            damage = 20, description = ""
        };
        moveInfo.Add(MoveCode.ABSORB, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Growth", type = "Normal",
            typeCode = TypeCode.NORMAL, 
            damage = 0, description = ""
        };
        moveInfo.Add(MoveCode.GROWTH, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Thunder Shock", type = "Electric",
            typeCode = TypeCode.ELECTRIC, 
            damage = 40, description = ""
        };
        moveInfo.Add(MoveCode.THUNDER_SHOCK, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Hypnosis", type = "Psychic",
            typeCode = TypeCode.PSYCHIC, 
            damage = 0, description = ""
        };
        moveInfo.Add(MoveCode.HYPNOSIS, temp);
        temp = new StructHandler.MoveInfo()
        {
            name = "Mud Slap", type = "Ground",
            typeCode = TypeCode.GROUND, 
            damage = 20, description = ""
        };
        moveInfo.Add(MoveCode.MUD_SLAP, temp);
    }
    // Write here the permanent data info
    public static void AddTrainerData(ref Dictionary<TrainerCode, StructHandler.TrainerInfo> trainerInfo)
    {
        StructHandler.TrainerInfo temp = new StructHandler.TrainerInfo()
        {
            name = "Joey", description = "Normal Kid, very good!@", trainerCode = TrainerCode.Joey
        };
        trainerInfo.Add(TrainerCode.Joey, temp);
    }
}
