import React, { Component } from 'react';
import Catalog from '../components/home/Catalog.tsx';
import Header from '../components/home/Header.tsx';
import About from '../components/home/About.tsx';
import Footer from '../components/home/Footer.tsx';
import Error from './Error.tsx';
import Description from '../components/home/Description.tsx';

export default class Home extends Component<any, any> {
    static displayName: string = Home.name;


    constructor(props) {
        super(props);

        this.state = { isServerOk: true };
    }


    render(): React.ReactNode {
        if (this.state.isServerOk) {
            return (
                <div>
                    <Header />
                    <About />
                    <Description />
                    <Catalog />
                    <Footer />
                </div>
            );
        }
        else {
            return <Error statusCode={500} />
        }
    }
}