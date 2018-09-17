import React from 'react';
import ReactDOM from 'react-dom';
global['React'] = React;
global['ReactDOM'] = ReactDOM;

//how to reference vendor libraries???
import $ from 'jquery';


//React Components
import Global_Header from './components/Global_Header'
import Module_FeaturedContent from './components/Module_FeaturedContent'
import Module_Jumbotron from './components/Module_Jumbotron'

global['Components'] = {
    Global_Header,
    Module_FeaturedContent,
    Module_Jumbotron
}

