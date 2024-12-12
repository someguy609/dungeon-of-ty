namespace dungeon_of_ty;

public class NegativeNumberException : Exception
{
	public NegativeNumberException(string variable) : base($"{variable} cannot be negative!") {}
}

public class EmptyStringException : Exception
{
	public EmptyStringException(string variable) : base($"{variable} cannot be empty!") {}
}

public class EmptyNameException : Exception
{
	public EmptyNameException() : base("Name") {}
}

public class EmptyDescriptionException : Exception
{
	public EmptyDescriptionException() : base ("Description") {}
}

public class NegativeHealthException : NegativeNumberException
{
	public NegativeHealthException() : base("Health") {}
}

public class NegativeAttackException : NegativeNumberException
{
	public NegativeAttackException() : base("Attack") {}
}

public class NegativeDefenseException : NegativeNumberException
{
	public NegativeDefenseException() : base("Defense") {}
}

public class MoveNotFoundException : Exception
{
	public MoveNotFoundException() : base("Move not found") {}
}