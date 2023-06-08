import React, { Component } from 'react';
import '../../resources/styles/Home.css'

export default class Footer extends Component {
    static displayName: string = Footer.name;


    constructor(props) {
        super(props);
        this.state = { authorized: false };
    }


    render(): React.ReactNode {
        return (
            <footer className="main-footer">
                <div className="content-container">
                    <nav className="footer-navigation">
                        <div className="navigation-cell">
                            <h3 className="title">ma belle</h3>
                            <a href="" className="link">Свечи для дома</a>
                            <a href="" className="link">Свечи для особого случая</a>
                            <a href="" className="link">Наборы свечей</a>
                        </div>
                        <div className="navigation-cell">
                            <span className="head">Каталог</span>
                            <a href="" className="link">Свечи</a>
                            <a href="" className="link">Наборы</a>
                        </div>
                        <div className="navigation-cell">
                            <span className="head">Для клиента</span>
                            <a href="" className="link">О нас</a>
                            <a href="" className="link">Уход</a>
                            <a href="" className="link">Доставка и оплата</a>
                            <a href="" className="link">Сотрудничество</a>
                        </div>
                        <div className="navigation-cell">
                            <span className="head">Контакты</span>
                            <a href="tel:+79523164486" className="link">+7 952 316 44 86</a>
                            <a href="mailto:contact@mabelle.ru" className="link">contact@mabelle.ru</a>
                        </div>
                    </nav>
                </div>
            </footer>
        );
    }
}