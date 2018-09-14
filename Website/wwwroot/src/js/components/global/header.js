import React from 'react';
import ReactDom from 'react-dom';
import MenuItem from './menuItem';
import SiteNameNoLogo from './siteNameNoLogo';
import SiteNameHasLogo from './siteNameHasLogo';

class Global_Header extends React.Component {
    render() {
        const menuItems = this.props.Menu.map(menuItem => (
            <MenuItem key={menuItem.Url} menuItem={menuItem}></MenuItem>
        ));
        let siteName;

        if (this.props.GlobalHeader.SiteLogo) {
            siteName = <SiteNameHasLogo GlobalHeader={this.props.GlobalHeader} />;
        } else {
            siteName = <SiteNameNoLogo GlobalHeader={this.props.GlobalHeader} />;
        }

        return (
            <div className="navbar navbar-inverse" role="navigation">
                <div className="container">
                    <div className="navbar-header">
                        <button type="button" className="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                        </button>
                        {siteName}
                    </div>
                    <div className="navbar-collapse collapse">
                        <ul className="nav navbar-nav">
                            {menuItems}
                        </ul>
                    </div>
                </div>
            </div>
        );
    }
}

export default Global_Header;






