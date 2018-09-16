import React from 'react';
import ReactDom from 'react-dom';

class SiteNameNoLogo extends React.Component {
    render() {
        return (
            <a className="navbar-brand" href="/">
                {this.props.GlobalHeader.SiteName}
            </a>
        );
    }
}
export default SiteNameNoLogo;
