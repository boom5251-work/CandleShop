import React, { Component } from 'react';
import '../resources/styles/Admin.css'
import FileEntryView from "../components/admin/FileEntryView.tsx";

export default class Admin extends Component<any, any> {
    static displayName: string = Admin.name;


    constructor(props) {
        super(props);
        this.state = { imageEntries: [] };
    }


    render(): React.ReactNode {
        return (
            <div className="content-container">
                <h2>Выгрузка изображений</h2>
                <form>
                    <div className="form-part">
                        <label className="hidden" htmlFor="file">Выбирите файл изображения</label>

                        <input ref={c => this.fileInput = c}
                               onChange={() => this.setFileName()}
                               className="hidden"
                               type="file"
                               id="file"
                               name="file"
                               accept="image/png" />

                        <input onClick={() => this.openBrowser()}
                               type="button"
                               value="Выбрать файл" />
                    </div>
                    <div className="form-part">
                        <label htmlFor="save-as">Новое название файла</label>

                        <input ref={c => this.fileNameInput = c}
                               type="text"
                               id="save-as"
                               name="save-as"
                               placeholder="image.png" />
                    </div>
                    <input onClick={() => this.sendImage()} type="button" value="Отправить" />
                </form>

                <h2>Текущие изображения</h2>
                <div className="image-entries-container">
                    {this.state.imageEntries.map(entry => <FileEntryView key={entry.id} entry={entry} />)}
                </div>
            </div>
        );
    }


    componentDidMount(): void {
        this.getImageEntries()
            .then(data => this.setState({ imageEntries: data }));
    }


    // Асинхронно выполняет GET-запрос на сервер.<br />
    // Получает вхождения изображений.
    async getImageEntries(): Promise<any> {
        const response = await fetch('/api/files/images/entries');
        return response.json();
    }


    // Устанавливает название файла в поле ввода названия.
    setFileName(): void {
        if (this.fileInput.files.length === 1) {
            this.fileNameInput.value = this.fileInput.files[0].name;
        }
    }


    // Открывает окно выбора файла изображения.
    openBrowser(): void {
        this.fileInput.click();
        this.setState({ fileName: this.fileInput.files[0] })
    }


    // Асинхронно выполняет POST-запрос на сервер.<br />
    // Отправляет название и файл изображения.
    async sendImage(): Promise<any | void> {
        const formData: FormData = new FormData();
        formData.append('saveAs', this.fileNameInput.value);
        formData.append('file', this.fileInput.files[0]);

        const response = await fetch('/api/files/images', {
            method: 'POST',
            body: formData
        });

        if (response.ok) {
            const data = await response.json();
            window.alert(data.message);
        }
        else {
            window.alert('Ошибка: не удалось внести изменения');
        }

        window.location.reload();
    }
}