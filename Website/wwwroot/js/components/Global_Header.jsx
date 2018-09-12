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

class MenuItem extends React.Component {
    render() {
        return (
            <li>
                <a href={this.props.menuItem.Url} target={this.props.menuItem.Target}>
                    {this.props.menuItem.Title}
                </a>
            </li>
        );
    }
}

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

class SiteNameNoLogo extends React.Component {
    render() {
        return (
            <a className="navbar-brand" href="/">
                {this.props.GlobalHeader.SiteName}
            </a>
        );
    }
}

