import React from 'react';

import style from './styles.css';

class Module_Heading extends React.Component {
    render() {
        return (
            <div className="container">
                <h1 className={style.big}>{this.props.title}</h1>
            </div>
        );
    }
}
export default Module_Heading;

