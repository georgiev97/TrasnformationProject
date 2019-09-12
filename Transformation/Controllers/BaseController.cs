using Data.DataContext;
using Data.Entity;
using Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transformation.Controllers
{
    public abstract class BaseController : Controller
    {
        private bool _disposed = false;

        protected TransformationContext Context { get; private set; }
        protected Repository Repository { get; private set; }

        public BaseController()
        {
            Context = new TransformationContext();
            Repository = new Repository(Context);
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Context.Dispose();
            }

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}