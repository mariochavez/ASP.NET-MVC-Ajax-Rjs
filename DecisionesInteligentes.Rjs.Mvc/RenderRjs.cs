/* 
The MIT License

Copyright (c) <year> <copyright holders>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System.IO;
using System.Web.Mvc;

namespace DecisionesInteligentes.Rjs.Mvc
{
    class RenderRjs
    {
        public static string RenderPartialToString(Controller controller, string partialView, ViewDataDictionary viewData, TempDataDictionary tempData)
        {
            ControllerContext controllerContext = controller.ControllerContext;
            var viewEngines = ViewEngines.Engines;
            var viewEngineResult = viewEngines.FindPartialView(controllerContext, partialView + ".js");

            ViewContext viewContext = new ViewContext(controllerContext, viewEngineResult.View, viewData,
                                                      tempData);

            var response = viewContext.HttpContext.Response;
            response.Flush();
            var oldFilter = response.Filter;
            Stream filter = null;
            try
            {
                filter = new MemoryStream();
                response.Filter = filter;
                viewContext.View.Render(viewContext, viewContext.HttpContext.Response.Output);
                response.Flush();
                filter.Position = 0;
                var reader = new StreamReader(filter, response.ContentEncoding);
                return reader.ReadToEnd();
            }
            finally
            {
                if (filter != null)
                {
                    filter.Dispose();
                }
                response.Filter = oldFilter;
            }
        }

        public static string RenderPartialToString(Controller controller, string partialView, ViewDataDictionary viewData)
        {
            return RenderPartialToString(controller, partialView, viewData, new TempDataDictionary());
        }

        public static string RenderPartialToString(Controller controller, string partialView)
        {
            return RenderPartialToString(controller, partialView, new ViewDataDictionary(), new TempDataDictionary());
        }

        public static string RenderPartialToString(Controller controller, string partialView, object model)
        {
            return RenderPartialToString(controller, partialView, new ViewDataDictionary(model), new TempDataDictionary());
        }
    }
}
