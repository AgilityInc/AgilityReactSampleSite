import React from 'react';

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
                <a href={this.props.data.viewDetailsURL.href} target={this.props.data.viewDetailsURL.target} title={this.props.data.viewDetailsURL.text}>
                    {this.props.data.viewDetailsLabel}
                </a>
            </div>
        );

    }

}

export default FeaturedContentItem;