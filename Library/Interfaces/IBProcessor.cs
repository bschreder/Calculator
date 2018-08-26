using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IBProcessor<TResult, TInput>
        where TResult : class, new()
        where TInput : class
    {
        Task<TResult> ExecuteAsync(TInput input);
    }

    public interface IBProcessor<TResult> where TResult : class, new()
    {
        Task<TResult> ExecuteAsync();
    }

    public interface IBProcessor
    {
        Task ExecuteAsync();
    }
}
