import React from 'react';
import ReactDom from 'react-dom';
import FeaturedContentItem from './FeaturedContentItem.js';
import style from '../../../css/shared.css'

class Module_FeaturedContent extends React.Component {
    render() {
        const featuredContentItemsNodes = this.props.items.map(featuredContentItem => (
            <FeaturedContentItem key={featuredContentItem.key} data={featuredContentItem}></FeaturedContentItem>
        ));
        return (
            <div className={style.thing}>
                <div className="featured-content-module row">
                    {featuredContentItemsNodes}
                </div>
            </div>
        );
    }
}
export default Module_FeaturedContent;

