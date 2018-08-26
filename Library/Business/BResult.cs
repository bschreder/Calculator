using Library.Interfaces;
using Library.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Business
{
    /// <summary>
    /// BusinessResult that returns an object plus errors
    /// </summary>
    /// <typeparam name="TResult">Result to return</typeparam>
    public class BResult<TResult> where TResult : class, new()
    {
        [JsonProperty(PropertyName = "result", Required = Required.Always)]
        public TResult Result;

        [JsonProperty(PropertyName = "error", Required = Required.Always)]
        public List<HError> Error = new List<HError>();

        public static implicit operator BResult<dynamic>(BResult<TResult> brT)
        {
            BResult<dynamic> br = new BResult<dynamic>() { Result = default(dynamic) };
            br.Error.AddRange(brT.Error);
            br.Result = brT.Result;
            return br;
        }

        public static implicit operator BResult<TResult>(BResult<dynamic> brT)
        {
            BResult<dynamic> br = new BResult<TResult>() { Result = new TResult() };
            br.Error.AddRange(brT.Error);
            br.Result = brT.Result as TResult;
            return br;
        }
    }

    /// <summary>
    /// BusinessResult that returns errors
    /// </summary>
    public class BResult
    {
        [JsonProperty(PropertyName = "error", Required = Required.Always)]
        public List<HError> Error = new List<HError>();

        public static implicit operator BResult<dynamic>(BResult brT)
        {
            BResult<dynamic> br = new BResult<dynamic>() { Result = default(dynamic) };
            br.Error.AddRange(brT.Error);
            //br.Result = default(dynamic);
            return br;
        }

        public static explicit operator BResult(BResult<dynamic> brT)
        {
            BResult<dynamic> br = new BResult();
            br.Error.AddRange(brT.Error);
            //br.Result = brT.Result as TResult;
            return (BResult)br;
        }
    }
}