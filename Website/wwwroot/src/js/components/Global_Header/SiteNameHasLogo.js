import React from 'react';
import ReactDom from 'react-dom';

class SiteNameHasLogo extends React.Component {
    render() {
        return (
            <a className="navbar-brand" href="/">
                <img src={this.props.GlobalHeader.SiteLogo.Url} title={this.props.GlobalHeader.SiteName} />
                {this.props.GlobalHeader.SiteName}
            </a>
        );
    }
}

export default SiteNameHasLogo;