import React from 'react';

class SiteNameNoLogo extends React.Component {
    render() {
        return (
            <a className="navbar-brand" href="/">
                {this.props.globalHeader.siteName}
            </a>
        );
    }
}
export default SiteNameNoLogo;
