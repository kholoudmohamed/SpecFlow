using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlow.Utilities;

namespace SpecFlow.BaseFramework
{
    public class BasePage<M>
        where M : BasePageElementMap, new()
    {
        public virtual string Url { get; }

        protected M Map => new M();

        public virtual void Navigate()
        {
            Driver.Browser.Navigate().GoToUrl(string.Concat(GetData.BaseAddress, Url));
        }

        public string GetLoggedInUserNameFromHeader()
        {
            return Map.HeaderLoggedInUserName.Text;
        }
    }

    public class BasePage<M, V> : BasePage<M> where M : BasePageElementMap, new() where V : BasePageValidator<M>, new()
    {
        public V Validate()
        {
            return new V();
        }
    }
}
