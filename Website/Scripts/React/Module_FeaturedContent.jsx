class Module_FeaturedContent extends React.Component {
    render() {
        const featuredContentItemsNodes = this.props.items.map(featuredContentItem => (
            <FeaturedContentItem key={featuredContentItem.key} data={featuredContentItem}></FeaturedContentItem>
        ));
        return (
            <div className="featured-content-module row">
                {featuredContentItemsNodes}
            </div>
        );
    }
}

class FeaturedContentItem extends React.Component {
    rawMarkup(propName) {
        const rawMarkup = this.props.data[propName].toString();
        return { __html: rawMarkup };
    }
    render() {
        return (
            <div className="col-md-4 featured-content">
                <h2>{this.props.data.title}</h2>
                <span dangerouslySetInnerHTML={this.rawMarkup('summary')} />
                <a href={this.props.data.viewDetailsURL.url} target={this.props.data.viewDetailsURL.target}>
                    {this.props.data.viewDetailsLabel}
                </a>
            </div>
        );
        
    }

}