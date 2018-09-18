import React from 'react'
import ReactDOM from 'react-dom'
import ReactDOMServer from 'react-dom/server'
global['React'] = React;
global['ReactDOM'] = ReactDOM;
global['ReactDOMServer'] = ReactDOMServer;


//React Components
import Global_Header from './components/Global_Header'
import Module_FeaturedContent from './components/Module_FeaturedContent'
import Module_Jumbotron from './components/Module_Jumbotron'
import Module_Banner from './components/Module_Banner'

global['Components'] = {
    Global_Header,
    Module_FeaturedContent,
    Module_Jumbotron,
    Module_Banner
}