# Agility React Sample Site

This is a sample website using [.NET MVC 5](https://docs.microsoft.com/en-us/aspnet/mvc/mvc5) for the backend, [Agility](https://agilitycms.com) as the CMS, [ReactJS.NET](http://reactjs.net/) as the frontend, [NPM](https://www.npmjs.com/) as the package manager, and [Webpack 4](https://webpack.js.org/) as the module bundler.

## Goal
The purpose of this repository is to have a sample site setup to demonstrate how React developers can work in an Agility .NET website, and enable them to use their favorite front-end tools such as VS Code, NPM and Webpack.

## Features
- Build your entire front-end using React JS components - does not require knowledge of .NET or Razor syntax
- Use ES6 *imports* and *exports*
- Integrates with Agility.Web and the Content Repository to use content from your Agility instance
- Server-side rendering support enabled by ReactJS.NET
- Take advantage of NPM and Webpack support to customize your frontend dev experience

## Backend: Visual Studio + ASP.NET
This project is based on the .NET framework (not .NET Core), therefore you still need to use Visual Studio 2015/2017 to restore nuget packages, and build the project after changes to C# code. You'll also need a development server that supports running an ASP.NET website such as IIS or IIS express. This is also important if you want to implement the webpack-dev-server proxy.

This solution only supports Windows with Visual Studio installed.

## Frontend: VS Code + NPM + Webpack
Once you've got the project running in local IIS or IIS Express, you can then open the /Website folder in VS Code and use npm and webpack to build and compile your JS bundles, and run your site locally using the webpack-dev-server which will proxy your requests to the site running in IIS/IIS Express.


## Try it Out
1. Download the source code by downloading as a Zip or clone the repository
2. Rename the Web.config.sample file in the root of the /Website folder to Web.config
3. Contact [support@agilitycms.com](mailTo:support@agilitycms.com) to get a CMS WebsiteName and SecurityKey, UGC Base Url, UGC API Key, and UGC API Password
4. Set your WebsiteName and SecurityKey in the agility.web section of the web.config
5. Set your UGC details in the app settings
6. Open the .sln file and build the project - you can do this by opening it in Visual Studio 2015/2017
7. Run the site using IIS or IIS Express and take note the IIS port number (i.e. https://localhost:**28799**)
8. Open the folder /Website in VS Code
9. Navigate to **/wwwroot** and open the **webpack.config.js file** and update the *iisPortNumber* variable

```javascript
const iisPortNumber = 28799 //update this to the port number your site is running in IIS/IIS Express
```

10. Open a terminal command line and perform the following commands in the **/wwwroot** directory

Restore missing npm packages
```
npm install
```

Ensure you can build JS modules using webpack
```
npm run build:dev
```

Start the site using webpack-dev-server
```
npm run start
```

11. The site should open in your default browser using a port number assigned by the webpack-dev-server

## Implemented Modules
At this time of writing, only several modules and components on this sample site have been converted to using ReactJS. This includes:
- Global Header
- Jumbotron Module
- Featured Content Module

## How Modules Work
Modules work exactly the same way they do in a regular Agility site. They have a corresponding PartialView or ControllerActionResult. In this sample site, the implemented modules have a ControllerActionResult just as normal, however instead of returning a PartialView, the result is a ReactActionResult.

Default: Server and Client rendered:
``` csharp
//This will Server-Side-Render (SSR) the component, as well as instruct the client application to pick-up where the server left off
return new ReactActionResult("Components.Jumbotron", viewModel);
```

The ReactActionResult accepts a string representing a ReactJS component, and an object that will be serialzied to JSON and passed as a property to the React component. You can decide whether this React component should be rendererd on the server only, the client only, or both. SSR is important if the content must be SEO friendly, or you want to pre-load complex listings before they are sent to the client. Client only outputs are recommended when the content is not required to be SEO friendly. A server-only rendering would be benficial if the output does not require any client interactivity and you are simply using React as a view engine.

Server Only:
``` csharp
return new ReactActionResult("Components.Jumbotron", viewModel)
{ 
  ClientOnly = false,
  ServerOnly = true
};
```

Client Only:
``` csharp
return new ReactActionResult("Components.Jumbotron", viewModel)
{ 
  ClientOnly = true,
  ServerOnly = false
};
```

## How Global Content Works
Often you will have a Global Header or Global Footer that is invoked either in the main Layout.cshtml file or a page template. This can be a React component as well. In this sample site, the Global Header is setup to be a React component. It is invoked from the main Layout file as a child ControllerActionResult and ultimately returns a ReactActionResult just like a Module.

In **Layout.cshtml**:
```
@Html.Action("GlobalHeader", "Global")
```

In **GlobalController.cs**:
``` csharp
public ActionResult GlobalHeader()
{

    var header = new AgilityContentRepository<GlobalHeader>("GlobalHeader").Item("");

    var viewModel = new GlobalHeaderViewModel();
    viewModel.GlobalHeader = header.ToFrontendProps();
    viewModel.Menu = new List<Link>();

    if (SiteMap.Provider.RootNode != null)
    {
        foreach(AgilitySiteMapNode node in SiteMap.Provider.RootNode.ChildNodes)
        {
            if(node.IsVisibleInMenu())
            {
                viewModel.Menu.Add(new Link() { Url = node.Url.Replace("~", ""), Title = node.Title, Target = node.Target });
            }
        }
    }

    return new ReactActionResult("Components.Global_Header", viewModel)
    { 
        ServerOnly = true
    };
}
```

## Issues
See [Issues](https://github.com/AgilityInc/AgilityReactSampleSite/issues) for a list of features to be implemented and any related bugs.

## How to Contribute
We use the *fork and pull model* so you can fork this repository and push changes to your personal fork. Then, open a pull request and it will be merged into this repository.

