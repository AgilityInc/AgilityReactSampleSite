import React from 'react';
import ReactDom from 'react-dom';

import style from './styles.css';

class Module_FeaturedContent extends React.Component {
    render() {
        let bannerImage;
        if (this.props.bannerImage) {
            bannerImage = <img className={style.img} src={this.props.bannerImage.url} alt={this.props.bannerImage.label} />
        }
        return (
            <div className="container">
                {bannerImage}
            </div>
        );
    }
}
export default Module_FeaturedContent;

