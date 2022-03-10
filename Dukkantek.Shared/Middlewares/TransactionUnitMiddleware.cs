using Dukkantek.Shared.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Shared.Middlewares
{
    public class TransactionUnitMiddleware
    {
        private readonly RequestDelegate _next;

        public TransactionUnitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUnitOfWorkManager unitOfWork)
        {
            string httpVerb = httpContext.Request.Method.ToUpper();

            if (httpVerb == "POST" || httpVerb == "PUT" || httpVerb == "DELETE")
            {

                await unitOfWork.ExecuteStrategy(async () =>
                {
                    // start the transaction
                    await unitOfWork.BeginTransaction();

                    // invoke next middleware 
                    await _next(httpContext);

                    if (httpContext.Response.StatusCode >= 200 && httpContext.Response.StatusCode < 300)
                    {
                        // commit the transaction
                        await unitOfWork.Commit();
                    }
                    else
                    {
                        await unitOfWork.RollBack();
                    }
                });

            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}
