import React from 'react';
import ReactDom from 'react-dom';
import FeaturedContentItem from './Module_FeaturedContent_FeaturedContentItem';

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
export default Module_FeaturedContent;

