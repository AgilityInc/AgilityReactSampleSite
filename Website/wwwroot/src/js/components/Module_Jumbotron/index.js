﻿import React from 'react';
import style from './styles.css';
import sharedStyle from '../../../css/shared.css'

class Module_Jumbotron extends React.Component {
    rawMarkup() {
        const rawMarkup = this.props.summary.toString();
        return { __html: rawMarkup };
    }
    render() {
        return (
            <div className="jumbotron">
                <h1 className={sharedStyle.thing}>
                    {this.props.title}
                </h1>
                <span dangerouslySetInnerHTML={this.rawMarkup()} />
                <a className="btn btn-primary btn-lg" role="button" target="_self" href="/" title={this.props.learnMoreLabel}>
                    {this.props.learnMoreLabel}
                </a>
            </div>
        );
    }
}

export default Module_Jumbotron;