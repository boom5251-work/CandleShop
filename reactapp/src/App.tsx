import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from "./pages/Home.tsx";
import Error from "./pages/Error.tsx";
import Admin from "./pages/Admin.tsx";

export default class App extends Component<any, any> {
    static displayName: string = App.name;


    render(): React.ReactNode {
        return (
            <Router>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/admin" element={<Admin />} />
                    <Route path="*" element={<Error statusCode={404} />} />
                </Routes>
            </Router>
        );
    }
}
