using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02.LogicProviders;

public class AuthorLogicProvider : BaseEntityLogicProvider<Author, IAuthorDataProvider>, IAuthorLogicProvider
{
    #region [ CTor ]
    public AuthorLogicProvider(ILogger<BaseEntityLogicProvider<Author, IAuthorDataProvider>> logger, 
                        IAuthorDataProvider dataProvider) : base(logger, dataProvider) {
    }
    #endregion
}
