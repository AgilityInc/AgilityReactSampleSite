import React from 'react';
import ReactDom from 'react-dom';

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
export default MenuItem;