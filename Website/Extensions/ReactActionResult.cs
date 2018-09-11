using System;
using System.Web.Mvc;
using React;
using React.Web;
using System.Linq;

namespace Website.Extensions
{
    public class ReactActionResult : ActionResult
    {
        public ReactActionResult(string componentName)
        {
            this.ComponentName = componentName;
            this.ContainerTag = "div";
        }
        public ReactActionResult(string componentName, object props)
: this(componentName)
        {
            this.Props = props;
        }

        public string ComponentName { get; set; }

        public string ContainerTag { get; set; }

        public string ContainerCssClass { get; set; }

        public object Props { get; set; }

        public bool ClientOnly { get; set; }

        public bool ServerOnly { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var httpContextBase = context.HttpContext;

            var component = React.ReactEnvironment.Current.CreateComponent(this.ComponentName, this.Props, clientOnly: this.ClientOnly, serverOnly: this.ServerOnly);

            component.ContainerTag = !string.IsNullOrWhiteSpace(this.ContainerTag) ? this.ContainerTag : "div";
            component.ContainerClass = this.ContainerCssClass;

            httpContextBase.Response.Write(component.RenderHtml(this.ClientOnly, this.ServerOnly));
        }
    }
}
