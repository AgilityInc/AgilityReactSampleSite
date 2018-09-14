import React from 'react';
import ReactDom from 'react-dom';

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

export default FeaturedContentItem;