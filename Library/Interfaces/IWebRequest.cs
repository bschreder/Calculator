using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IWebRequest<T> where T : class
    {
        Task<BResult<WebRequestResponse>> Request(WebRequestRequest<T> wrr);
    }
}
