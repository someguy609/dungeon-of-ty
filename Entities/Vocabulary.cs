namespace dungeon_of_ty;

public static class Vocabulary
{
	public static Random _random = new();
	public static readonly List<string> Words = new() 
	{ 
		"do", "it", "he", "be", "we", "to", "go", "no", 
		//"so", "up", "us", "as", "at", "an", "in", "on", "of", "if", "is", "it", "by", "my", "me", "am", "an", "as", "at", "to", "do", "go", "so", "no", "on", "in", "up", "us", "we", "he", "be", "it", "is", "if", "by", "my", "me", "am", "an", "as", "at", "to", "do", "go", "so", "no", "on", "in", "up", "us", "we", "he", "be", "it", "is", "if", "by", "my", "me", "am", "an", "as", "at", "to", "do", "go", "so", "no", "on", "in", "up", "us", "we", "he", "be", "it", "is", "if", "by", "my", "me", "am", "an", "as", "at", "to", "do", "go", "so", "no", "on", "in", "up", "us", "we", "he", "be", "it", "is", "if", "by", "my", "me", "am", "an", "as", "at", "to", "do", "go", "so", "no", "on", "in", "up", "us", "we", "he", "be", "it", "is", "if", "by", "my", "me", "am", "an", "as", "at", "to", "do", "go", "so", "no", "on", "in", "up", "us", "we", "he", "be", "it", "is", "if", "by", "my", "me", "am", "an", "as", "at", "to", "do", "go", "so", "no", "on", "in", "up", "us", "we", "he", "be", "it",
		"nap", "sap", "pat", "hat", "ate", "bat", "cat", 
		"sat", "pan", "ran", "tan", "van", 
		// "ban", "can", "fan", "may", "ray", "say", "pay", "way", "lay", "day", "ask", "all", "any", "and", "are", "art", "act", "add", "age", "air", "aim", "bag", "bad", "bar", "bat", "bed", "bet", "big", "bit",
		"punch", "kick", "talk", "walk", "slap", "trap", "tomb", 
		"word", "same", "very", "tell", "long", 
		"should", "would", "could", "small",  "under", "water", 
		"where", "which", "while", "white", "large", 
		"aardvark",
		"serendipity",
		// "pneumonoultramicroscopicsilicovolcanoconiosis"
	};

	public static string GetWord() { return Words[_random.Next(Words.Count)]; }
}