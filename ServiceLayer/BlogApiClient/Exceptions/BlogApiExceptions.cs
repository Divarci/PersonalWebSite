using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BlogApiClient.Exceptions
{
    public class BlogApiExceptions : Exception
    {
        public BlogApiExceptions(string? message) : base(message)
        {
        }
    }
}
