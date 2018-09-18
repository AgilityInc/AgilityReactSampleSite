import React from 'react';

class MenuItem extends React.Component {
    render() {
        return (
            <li>
                <a href={this.props.menuItem.url} target={this.props.menuItem.target}>
                    {this.props.menuItem.title}
                </a>
            </li>
        );
    }
}
export default MenuItem;