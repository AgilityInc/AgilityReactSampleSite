import React from 'react';
import FeaturedContentItem from './FeaturedContentItem.js';
import style from './styles.css';
import sharedStyle from '../../../css/shared.css'

class Module_FeaturedContent extends React.Component {
    render() {
        const featuredContentItemsNodes = this.props.items.map(featuredContentItem => (
            <FeaturedContentItem key={featuredContentItem.key} data={featuredContentItem}></FeaturedContentItem>
        ));
        return (
            <div className={sharedStyle.thing}>
                <div className="featured-content-module row">
                    {featuredContentItemsNodes}
                </div>
            </div>
        );
    }
}
export default Module_FeaturedContent;

