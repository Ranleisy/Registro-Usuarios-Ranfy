namespace RedSocial.Infrastructure.Exceptions;

public class UsuarioException : Exception
{
    public UsuarioException(string message) : base(message) { }
}

public class PostException : Exception
{
    public PostException(string message) : base(message) { }
}

public class ComentarioException : Exception
{
    public ComentarioException(string message) : base(message) { }
}

public class LikeException : Exception
{
    public LikeException(string message) : base(message) { }
}

public class SeguidorException : Exception
{
    public SeguidorException(string message) : base(message) { }
}
