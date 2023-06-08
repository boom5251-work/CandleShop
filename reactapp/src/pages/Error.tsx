import React, { Component } from 'react';
import '../resources/styles/Error.css';

export default class Error extends Component<any, any> {
    static displayName: string = Error.name;


    render(): React.ReactNode {
        return (
            <div className="content-container error">
                <img src={"https://http.cat/" + this.props.statusCode} alt={this.props.statusCode} />
            </div>
        );
    }
}