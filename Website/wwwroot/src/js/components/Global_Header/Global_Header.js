import React from 'react';
import ReactDom from 'react-dom';
import MenuItem from './MenuItem.js';
import SiteNameNoLogo from './SiteNameNoLogo.js';
import SiteNameHasLogo from './SiteNameHasLogo.js';

class Global_Header extends React.Component {
    render() {
        const menuItems = this.props.menu.map(menuItem => (
            <MenuItem key={menuItem.url} menuItem={menuItem}></MenuItem>
        ));
        let siteName;

        if (this.props.globalHeader.siteLogo) {
            siteName = <SiteNameHasLogo globalHeader={this.props.globalHeader} />;
        } else {
            siteName = <SiteNameNoLogo globalHeader={this.props.globalHeader} />;
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






