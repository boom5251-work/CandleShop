import React, { Component } from 'react';
import deleteImageIcon from '../../resources/images/delete-photo-icon.svg';
import '../../resources/styles/Admin.css';

export default class FileEntryView extends Component<any, any> {
    static displayName: string = FileEntryView.name;


    render(): React.ReactNode {
        return (
            <div className="image-entry-view" key={this.props.entry.id}>
                <span className="info-text">
                    <span className="text">id: </span>
                    <span className="value">{this.props.entry.id}</span>
                </span>
                <span className="info-text">
                    <span className="text">name: </span>
                    <span className="value">{this.props.entry.name}</span>
                </span>
                <button className="delete-button" onClick={() => this.deleteImage()}>
                    <img src={deleteImageIcon} alt="Удалить" />
                </button>
            </div>
        );
    }


    async deleteImage(): Promise<void> {
        if (window.confirm(`Удалить изображение ${this.props.entry.name}?`)) {
            const response = await fetch(`api/files/images?id=${this.props.entry.id}`, {
                method: 'DELETE'
            });

            const data = await response.json();
            window.alert(data.message);
            window.location.reload();
        }
    }
}