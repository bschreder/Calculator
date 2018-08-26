using Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Interfaces
{
    public interface IBResult<TResult> : IBResult where TResult : class
    {
        TResult Result { get; set; }
    }

    public interface IBResult
    {
        List<HError> Error { get; set; }
    }


}
