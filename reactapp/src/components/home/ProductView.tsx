import React, {Component} from 'react';
import '../../resources/styles/ProductView.css';

export default class ProductView extends Component {
    static displayName: string = ProductView.name;


    render(): React.ReactNode {
        return (
            <div className="product-view">
                <img className="preview-image"
                     src={this.props.imageSource}
                     alt={`Фото: ${this.props.name}`} />

                <span className="text">{this.props.name}</span>
                <span className="text">{this.props.description}</span>
                <span className="text">{this.props.price} р.</span>
            </div>
        );
    }
}