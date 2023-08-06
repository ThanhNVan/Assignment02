using Assignment02.LogicProviders;

namespace Assignment02.LogicProviders;

public class LogicContext
{
    #region [ CTor ]
    public LogicContext(IAuthorLogicProvider author) {
        Author = author;
    }

    #endregion

    #region [ Properties ]
    public IAuthorLogicProvider Author { get; }

    #endregion
}
