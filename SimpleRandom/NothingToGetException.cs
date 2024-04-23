namespace SimpleRandom;

public sealed class NothingToGetException : Exception {
    public NothingToGetException() : base("모든 숫자를 뽑았습니다.") { }
    public NothingToGetException(string message) : base(message) { }
    public NothingToGetException(string message, Exception inner) : base(message, inner) { }
}
