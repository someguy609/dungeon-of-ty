namespace dungeon_of_ty;

public static class Vocabulary
{
	public static Random _random = new();
	public static readonly List<string> Words = new() 
	{ 
		"nap", "sap", "pat", "hat", "ate", "bat", "cat", "sat", "pan",
		"punch", "kick", "talk", "walk", "slap", "trap", "tomb",
		"should", "would", "could", 
		"aardvark", 
		"serendipity"
	};

	public static string GetWord() { return Words[_random.Next(Words.Count)]; }
}