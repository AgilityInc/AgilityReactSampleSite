import React from 'react'
import ReactDOM from 'react-dom'
import ReactDOMServer from 'react-dom/server'
global['React'] = React;
global['ReactDOM'] = ReactDOM;
global['ReactDOMServer'] = ReactDOMServer;


//React Components
import Global_Header from './components/Global_Header/Global_Header.js'
import Module_FeaturedContent from './components/Module_FeaturedContent/Module_FeaturedContent.js'
import Module_Jumbotron from './components/Module_Jumbotron/Module_Jumbotron.js'

global['Components'] = {
    Global_Header,
    Module_FeaturedContent,
    Module_Jumbotron
}