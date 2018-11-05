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

## Issues
See [Issues](https://github.com/AgilityInc/AgilityReactSampleSite/issues) for a list of features to be implemented and any related bugs.

## How to Contribute
We use the *fork and pull model* so you can fork this repository and push changes to your personal fork. Then, open a pull request and it will be merged into this repository.

