import React, { Component } from 'react';
import '../../resources/styles/Home.css'

export default class About extends Component<any, any> {
    static displayName: string = About.name;


    render(): React.ReactNode {
        return (
            <section className="about-section">
                <div className="content-container">
                    <h2 className="title">Только для вас</h2>
                    <p className="about-text">
                        ваших уютных моментов и&nbsp;близких вам&nbsp;людей. Мы&nbsp;придумали свечи,
                        которые можно подарить ценному другу или&nbsp;зажечь в&nbsp;минуты вдохновения,
                        во&nbsp;время романтического свидания или&nbsp;дождливого сентябрьского вечера.
                        Создаем настроение для&nbsp;вас.
                    </p>
                </div>
            </section>
        );
    }
}