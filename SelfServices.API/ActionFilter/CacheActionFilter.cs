using System;
using System.Net;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MOE.WebAPI.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CacheActionFilter : ActionFilterAttribute
    {

        #region :: Configuration Keys

        private int Seconds = 0;

        private string CachingKey = "";

        private static IMemoryCache memoryCache;

        // read more about it -- maxiumn
        //private static SemaphoreSlim semaphore = new SemaphoreSlim(1);

        #endregion

        public CacheActionFilter(string cachingKey)
        {
            this.CachingKey = cachingKey;
        }

        public CacheActionFilter(string cachingKey, int seconds)
        {
            this.CachingKey = cachingKey;
            this.Seconds = seconds;
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // read configuration
            var config = filterContext.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;
            bool isEnable = config.GetValue<bool>("Caching:EnableCaching");
            if (isEnable)
            {
                // read if have caching data
                memoryCache = filterContext.HttpContext.RequestServices.GetService(typeof(IMemoryCache)) as IMemoryCache;
                var isCached = memoryCache.TryGetValue(CachingKey, out var result);
                if (isCached)
                {
                    ContentResult content = new ContentResult();
                    content.ContentType = "application/json";
                    content.StatusCode = (int)HttpStatusCode.OK;
                    content.Content = JsonConvert.SerializeObject(result);
                    filterContext.Result = content;
                    return;
                }
            }



            base.OnActionExecuting(filterContext);
        }


        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // read configuration
            var config = context.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;
            bool isEnable = config.GetValue<bool>("Caching:EnableCaching");
            if (isEnable)
            {
                var result = context.Result as ObjectResult;
                if (result != null)
                {
                    // validation if result.value is null
                    if (result.Value != null)
                    {
                        // read second default if not pass second on same action
                        int second = this.Seconds;
                        if (second == 0)
                        {
                            second = config.GetValue<int>("Caching:CacheSeconds");
                        }

                        //setting up cache options
                        var cacheExpiryOptions = new MemoryCacheEntryOptions
                        {
                            AbsoluteExpiration = DateTime.Now.AddSeconds((second == 0 ? 60 : second)),
                            Priority = CacheItemPriority.High,
                            SlidingExpiration = TimeSpan.FromSeconds((second == 0 ? 60 : second))
                        };

                        //setting cache entries
                        memoryCache.Set(CachingKey, result.Value, cacheExpiryOptions);
                    }
                }
            }

            base.OnResultExecuted(context);
        }
    }
}
